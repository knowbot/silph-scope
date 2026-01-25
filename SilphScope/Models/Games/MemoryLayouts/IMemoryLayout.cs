namespace SilphScope.Models.Games.MemoryLayouts
{
    public interface IMemoryLayout
    {
        int RamStart { get; }
        int RamEnd { get; }
        int SaveSize { get; }
        string AnchorString { get; }
        int Anchor { get; }
        int SavePointer { get; }
        int TrainerName { get; }
        int TrainerID { get; }
        int PartyCount { get; }
        int Party { get; }
        int BoxNames { get; }
        int Money { get; }
        int BigBlock { get; }
        int Badges { get; }
        int Gender { get; }
        int Skip { get; }
        int BoxPokemon { get; }

        public nint GetSaveAddr(nint baseAddr, nint localSaveAddr) => localSaveAddr - RamStart + baseAddr + Skip;
    }
}
