import pymem
import pymem.pattern
import struct
import re
import json

type GameInfo = dict[str, list[str], int, int]
process_name: str= "DeSmuME_0.9.13_x64.exe"
ram_start_addr: int = 0x02000000
game_versions: dict = json.load(open("data/version-ram-data.json"))

def byte_pattern(words: list[str]) -> bytes:
    byte_array = bytearray()
    for w in words:
        byte_array.extend(struct.pack('<I', int(w, 16)))
    return bytes(byte_array)

def get_addresses(pm: pymem.Pymem, version: str) -> tuple[int, int]:
    game = game_versions[version]
    pattern = re.escape(byte_pattern(game["anchor"]))
    print(f"Scanning process memory for anchor for game version {version}.")
    res = pymem.pattern.pattern_scan_all(pm.process_handle, pattern, return_multiple=True)
    if not res:
        print("Anchor not found. Exiting.")
        return 0, 0
    
    for anchor_addr in res:
        base_addr = anchor_addr - int(game["anchor_offset"], 16)
        raw_save_addr = pm.read_int(base_addr + int(game["save_pointer_offset"], 16))
        if raw_save_addr != 0:
            print("Save data address found.")
            save_addr = (raw_save_addr - ram_start_addr) + base_addr
            return base_addr, save_addr
    print('No valid addresses found. Returning.')
    return 0, 0

def get_trainer_name(pm: pymem.Pymem, save_addr: int, char_set: dict) -> str:
    return decode_string(pm, save_addr + 0x7C, char_set, 16)
    
def get_money(pm: pymem.Pymem, save_addr: int) -> int:
    return pm.read_uint(save_addr + 0x90)

def get_trainer_id(pm: pymem.Pymem, save_addr: int) -> int:
    return pm.read_ushort(save_addr + 0x8C)

def get_party_size(pm: pymem.Pymem, save_addr: int) -> int:
   return int.from_bytes(pm.read_bytes(save_addr + 0xB0, 1), 'little')

def parse_party_pokemon(pm: pymem.Pymem, save_addr: int, pos: int):
    # get address of data start
    # 1. Read unencrypted data (PID, checksum)
    pkmn_addr = save_addr + 0xB4 + 236 * pos
    pid = pm.read_uint(pkmn_addr)
    checksum = pm.read_ushort(pkmn_addr + 0x6)
    
    # 2. Decrypt remaining data (128 bytes)
    encrypted_data = pm.read_bytes(pkmn_addr + 0x8, 128)
    decrypted_data = bytearray(128)
    prng = checksum
    for i in range(0, 128, 2):
        prng = (0x41C64E6D * prng + 0x6073) & 0xFFFFFFFF
        decrypted_value = struct.unpack('<H', encrypted_data[i:i+2])[0]
        decrypted_value ^= (prng >> 16) & 0xFFFF
        decrypted_data[i:i+2] = struct.pack('<H', decrypted_value)
    
    # # 3. Determine block order from PID
    shift = ((pid & 0x3E000) >> 0xD) % 24
    print(f"Block shift: {shift}")
    blocks = [0x00, 0x20, 0x40, 0x60]
    
    
    # pass

def print_box_names(pm: pymem.Pymem, save_addr: int, char_set: dict):
    # get box names
    box_names: list[str] = []
    start_addr = save_addr + 0xCF40 + 0x11EE4
    for i in range(0,18):
        addr = start_addr + 40*i
        box_names.append(decode_string(pm, addr, char_set, 40))
    return box_names

def decode_string(pm: pymem.Pymem, addr: int, char_set: dict, length: int) -> str:
    # decode string from memory using char set
    res = ""
    for i in range(0, length, 2):
        code = "0x{:04X}".format(pm.read_ushort(addr + i))
        if code == "0xFFFF":
            break
        res += char_set.get(code, "")
    return res

pm = pymem.Pymem(process_name)
print(f"Attached to {process_name}")

base_addr, save_addr = get_addresses(pm, "CPUE")
with open("data/gen4-char-set.json", encoding="utf-8") as f:
    char_set = json.load(f)
print("Money: " + str(get_money(pm, save_addr)))
print("Trainer ID: " + str(get_trainer_id(pm, save_addr)))
print("Trainer Name: " + get_trainer_name(pm, save_addr, char_set))
print("Party Size: " + str(get_party_size(pm, save_addr)))
print("Box Names: " + str(print_box_names(pm, save_addr, char_set)))
parse_party_pokemon(pm, save_addr, 0)


