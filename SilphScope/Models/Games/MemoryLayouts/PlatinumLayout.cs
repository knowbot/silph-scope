namespace SilphScope.Models.Games.MemoryLayouts
{
    public record PlatinumLayout : IMemoryLayout
    {
        public int MemorySize => 0x400000;
        public string AnchorString => "5B 53 44 4B 2B 4E 49 4E 54 45 4E 44 4F 3A 42 41 43 4B 55 50";
        public int Anchor => 0xBFC;
        public int SavePointer => 0x101D40;
        public int Canary => 0x01;
        public int TrainerName => 0x7C;
        public int TrainerID => 0x8C;
        public int Money => 0x90;
        public int PartySize => 0xB0;
        public int BoxData => 0x11EE4;
        public int BigBlock => 0xCF40;
    }
}
