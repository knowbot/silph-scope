namespace SilphScope.Models.GameData
{
    public interface IMemoryLayout
    {
        string AnchorString { get; }
        int Anchor { get; }
        int SavePointer { get; }
        int TrainerName { get; }
        int TrainerID { get; }
        int PartySize { get; }
        int BoxData { get; }
        int Money { get; }
        int BigBlock { get; }
    }
}
