# SilphScope

> Real-time game state inspector for Pokémon emulators.

SilphScope attaches to a running emulator and reads its memory live — no save files, no plugins, no ROM patches required. It presents the game's internal state in a clean desktop UI: your party, your PC boxes, your trainer profile, and more, all updating as you play.

---

## What it shows

| Panel | Details |
|---|---|
| **Party** | All 6 party slots with species, level, nature, held item, and current HP |
| **Pokémon details** | Moves with PP, base stats, IVs, EVs, types |
| **PC Boxes** | Full box carousel — browse every stored Pokémon without opening the in-game PC |
| **Trainer** | Name, TID/SID, money, badges, play time |
| **Log** | Timestamped event feed for debugging and curiosity |

---

## How it works

SilphScope polls the emulator process in the background. It locates the game's save RAM inside the emulator's memory space, parses the binary structs that the game engine writes there, and decodes them into readable data — handling things like the Gen 4 Pokémon encryption (XOR + personality-value-based block shuffle) transparently.

No emulator configuration is needed. SilphScope scans for known emulator processes automatically and reconnects if the process restarts.

---

## Supported games

| Game | Generation | Status |
|---|---|---|
| Pokémon Platinum | Gen IV (DS) | Supported |

Support for additional games can be added by implementing a memory layout for the target game.

---

## Requirements

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or later
- A supported emulator (e.g. [DeSmuME](https://desmume.org/)) running a supported game
- Windows or Linux

---

## Running

```bash
dotnet run --project SilphScope
```

Launch your emulator and load your game — SilphScope will detect it automatically.

---

## License

[MIT](LICENSE)
