namespace SilphScope.Models.Games.MemoryLayouts
{
    public record PlatinumLayout : IMemoryLayout
    {
        public int RamStart => 0x02000000;
        public int SaveSize => 0x10000;
        public int Skip => 0x14;
        public string AnchorString => "5B 53 44 4B 2B 4E 49 4E 54 45 4E 44 4F 3A 42 41 43 4B 55 50";
        public int Anchor => 0xBFC;
        public int SavePointer => 0x101D40;
        public int Canary => 0x10;
        public int TrainerName => 0x68;
        public int TrainerID => 0x78;
        public int Money => 0x7C;
        public int Gender => 0x80;
        public int Badges => 0x82;
        public int PartySize => 0x9C;
        public int BigBlock => 0x0CF2C;
        public int BoxNames => 0x11EE4;
    }
}
