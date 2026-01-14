namespace SilphScope.Models.Games.MemoryLayouts
{
    public interface IMemoryLayout
    {
        string AnchorString { get; }
        int Anchor { get; }
        int SavePointer { get; }
        int Canary { get; }
        int TrainerName { get; }
        int TrainerID { get; }
        int PartySize { get; }
        int BoxData { get; }
        int Money { get; }
        int BigBlock { get; }
    }
}
