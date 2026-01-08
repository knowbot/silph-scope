import pymem
import pymem.pattern
import struct
import re
import json

type GameInfo = dict[str, list[str], int, int]
process_name: str= "DeSmuME_0.9.13_x64.exe"
ram_start_addr: int = 0x02000000
game_versions: dict = json.load(open("json/game-data.json"))

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
    
    
def get_money(pm: pymem.Pymem, save_addr: int) -> int:
    return pm.read_uint(save_addr + 0x90)

def get_trainer_id(pm: pymem.Pymem, save_addr: int) -> int:
    return pm.read_ushort(save_addr + 0x8C)

def get_party_size(pm: pymem.Pymem, save_addr: int) -> int:
   return int.from_bytes(pm.read_bytes(save_addr + 0xB0, 1), 'little')

pm = pymem.Pymem(process_name)
print(f"Attached to {process_name}")

base_addr, save_addr = get_addresses(pm, "CPUE")
print(get_money(pm, save_addr))
print(get_trainer_id(pm, save_addr))
print(get_party_size(pm, save_addr))


