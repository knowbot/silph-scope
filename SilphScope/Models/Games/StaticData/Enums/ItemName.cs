using System.ComponentModel;

namespace SilphScope.Models.Games.StaticData.Enums
{
    /// <summary>
    /// This is a collection of all items for which we have data.
    /// Refer to ItemTables for immediate conversions between in-game ushort ids and an enum entry.
    /// </summary>
    public enum ItemName
    {
        [Description("Unknown")]
        Unknown = -1,
        [Description("None")]
        None = 0,
        [Description("Master Ball")]
        MasterBall = 1,
        [Description("Ultra Ball")]
        UltraBall = 2,
        [Description("Great Ball")]
        GreatBall = 3,
        [Description("Poké Ball")]
        PokeBall = 4,
        [Description("Safari Ball")]
        SafariBall = 5,
        [Description("Net Ball")]
        NetBall = 6,
        [Description("Dive Ball")]
        DiveBall = 7,
        [Description("Nest Ball")]
        NestBall = 8,
        [Description("Repeat Ball")]
        RepeatBall = 9,
        [Description("Timer Ball")]
        TimerBall = 10,
        [Description("Luxury Ball")]
        LuxuryBall = 11,
        [Description("Premier Ball")]
        PremierBall = 12,
        [Description("Dusk Ball")]
        DuskBall = 13,
        [Description("Heal Ball")]
        HealBall = 14,
        [Description("Quick Ball")]
        QuickBall = 15,
        [Description("Cherish Ball")]
        CherishBall = 16,
        [Description("Potion")]
        Potion = 17,
        [Description("Antidote")]
        Antidote = 18,
        [Description("Burn Heal")]
        BurnHeal = 19,
        [Description("Ice Heal")]
        IceHeal = 20,
        [Description("Awakening")]
        Awakening = 21,
        [Description("Paralyze Heal")]
        ParalyzeHeal = 22,
        [Description("Full Restore")]
        FullRestore = 23,
        [Description("Max Potion")]
        MaxPotion = 24,
        [Description("Hyper Potion")]
        HyperPotion = 25,
        [Description("Super Potion")]
        SuperPotion = 26,
        [Description("Full Heal")]
        FullHeal = 27,
        [Description("Revive")]
        Revive = 28,
        [Description("Max Revive")]
        MaxRevive = 29,
        [Description("Fresh Water")]
        FreshWater = 30,
        [Description("Soda Pop")]
        SodaPop = 31,
        [Description("Lemonade")]
        Lemonade = 32,
        [Description("Moomoo Milk")]
        MoomooMilk = 33,
        [Description("Energy Powder")]
        EnergyPowder = 34,
        [Description("Energy Root")]
        EnergyRoot = 35,
        [Description("Heal Powder")]
        HealPowder = 36,
        [Description("Revival Herb")]
        RevivalHerb = 37,
        [Description("Ether")]
        Ether = 38,
        [Description("Max Ether")]
        MaxEther = 39,
        [Description("Elixir")]
        Elixir = 40,
        [Description("Max Elixir")]
        MaxElixir = 41,
        [Description("Lava Cookie")]
        LavaCookie = 42,
        [Description("Berry Juice")]
        BerryJuice = 43,
        [Description("Sacred Ash")]
        SacredAsh = 44,
        [Description("HP Up")]
        HpUp = 45,
        [Description("Protein")]
        Protein = 46,
        [Description("Iron")]
        Iron = 47,
        [Description("Carbos")]
        Carbos = 48,
        [Description("Calcium")]
        Calcium = 49,
        [Description("Rare Candy")]
        RareCandy = 50,
        [Description("PP Up")]
        PpUp = 51,
        [Description("Zinc")]
        Zinc = 52,
        [Description("PP Max")]
        PpMax = 53,
        [Description("Old Gateau")]
        OldGateau = 54,
        [Description("Guard Spec.")]
        GuardSpec = 55,
        [Description("Dire Hit")]
        DireHit = 56,
        [Description("X Attack")]
        XAttack = 57,
        [Description("X Defense")]
        XDefense = 58,
        [Description("X Speed")]
        XSpeed = 59,
        [Description("X Accuracy")]
        XAccuracy = 60,
        [Description("X Sp. Atk")]
        XSpAtk = 61,
        [Description("X Sp. Def")]
        XSpDef = 62,
        [Description("Poké Doll")]
        PokeDoll = 63,
        [Description("Fluffy Tail")]
        FluffyTail = 64,
        [Description("Blue Flute")]
        BlueFlute = 65,
        [Description("Yellow Flute")]
        YellowFlute = 66,
        [Description("Red Flute")]
        RedFlute = 67,
        [Description("Black Flute")]
        BlackFlute = 68,
        [Description("White Flute")]
        WhiteFlute = 69,
        [Description("Shoal Salt")]
        ShoalSalt = 70,
        [Description("Shoal Shell")]
        ShoalShell = 71,
        [Description("Red Shard")]
        RedShard = 72,
        [Description("Blue Shard")]
        BlueShard = 73,
        [Description("Yellow Shard")]
        YellowShard = 74,
        [Description("Green Shard")]
        GreenShard = 75,
        [Description("Super Repel")]
        SuperRepel = 76,
        [Description("Max Repel")]
        MaxRepel = 77,
        [Description("Escape Rope")]
        EscapeRope = 78,
        [Description("Repel")]
        Repel = 79,
        [Description("Sun Stone")]
        SunStone = 80,
        [Description("Moon Stone")]
        MoonStone = 81,
        [Description("Fire Stone")]
        FireStone = 82,
        [Description("Thunder Stone")]
        ThunderStone = 83,
        [Description("Water Stone")]
        WaterStone = 84,
        [Description("Leaf Stone")]
        LeafStone = 85,
        [Description("Tiny Mushroom")]
        TinyMushroom = 86,
        [Description("Big Mushroom")]
        BigMushroom = 87,
        [Description("Pearl")]
        Pearl = 88,
        [Description("Big Pearl")]
        BigPearl = 89,
        [Description("Stardust")]
        Stardust = 90,
        [Description("Star Piece")]
        StarPiece = 91,
        [Description("Nugget")]
        Nugget = 92,
        [Description("Heart Scale")]
        HeartScale = 93,
        [Description("Honey")]
        Honey = 94,
        [Description("Growth Mulch")]
        GrowthMulch = 95,
        [Description("Damp Mulch")]
        DampMulch = 96,
        [Description("Stable Mulch")]
        StableMulch = 97,
        [Description("Gooey Mulch")]
        GooeyMulch = 98,
        [Description("Root Fossil")]
        RootFossil = 99,
        [Description("Claw Fossil")]
        ClawFossil = 100,
        [Description("Helix Fossil")]
        HelixFossil = 101,
        [Description("Dome Fossil")]
        DomeFossil = 102,
        [Description("Old Amber")]
        OldAmber = 103,
        [Description("Armor Fossil")]
        ArmorFossil = 104,
        [Description("Skull Fossil")]
        SkullFossil = 105,
        [Description("Rare Bone")]
        RareBone = 106,
        [Description("Shiny Stone")]
        ShinyStone = 107,
        [Description("Dusk Stone")]
        DuskStone = 108,
        [Description("Dawn Stone")]
        DawnStone = 109,
        [Description("Oval Stone")]
        OvalStone = 110,
        [Description("Odd Keystone")]
        OddKeystone = 111,
        [Description("Adamant Orb")]
        AdamantOrb = 112,
        [Description("Lustrous Orb")]
        LustrousOrb = 113,
        [Description("Grass Mail")]
        GrassMail = 114,
        [Description("Flame Mail")]
        FlameMail = 115,
        [Description("Bubble Mail")]
        BubbleMail = 116,
        [Description("Bloom Mail")]
        BloomMail = 117,
        [Description("Tunnel Mail")]
        TunnelMail = 118,
        [Description("Steel Mail")]
        SteelMail = 119,
        [Description("Heart Mail")]
        HeartMail = 120,
        [Description("Snow Mail")]
        SnowMail = 121,
        [Description("Space Mail")]
        SpaceMail = 122,
        [Description("Air Mail")]
        AirMail = 123,
        [Description("Mosaic Mail")]
        MosaicMail = 124,
        [Description("Brick Mail")]
        BrickMail = 125,
        [Description("Cheri Berry")]
        CheriBerry = 126,
        [Description("Chesto Berry")]
        ChestoBerry = 127,
        [Description("Pecha Berry")]
        PechaBerry = 128,
        [Description("Rawst Berry")]
        RawstBerry = 129,
        [Description("Aspear Berry")]
        AspearBerry = 130,
        [Description("Leppa Berry")]
        LeppaBerry = 131,
        [Description("Oran Berry")]
        OranBerry = 132,
        [Description("Persim Berry")]
        PersimBerry = 133,
        [Description("Lum Berry")]
        LumBerry = 134,
        [Description("Sitrus Berry")]
        SitrusBerry = 135,
        [Description("Figy Berry")]
        FigyBerry = 136,
        [Description("Wiki Berry")]
        WikiBerry = 137,
        [Description("Mago Berry")]
        MagoBerry = 138,
        [Description("Aguav Berry")]
        AguavBerry = 139,
        [Description("Iapapa Berry")]
        IapapaBerry = 140,
        [Description("Razz Berry")]
        RazzBerry = 141,
        [Description("Bluk Berry")]
        BlukBerry = 142,
        [Description("Nanab Berry")]
        NanabBerry = 143,
        [Description("Wepear Berry")]
        WepearBerry = 144,
        [Description("Pinap Berry")]
        PinapBerry = 145,
        [Description("Pomeg Berry")]
        PomegBerry = 146,
        [Description("Kelpsy Berry")]
        KelpsyBerry = 147,
        [Description("Qualot Berry")]
        QualotBerry = 148,
        [Description("Hondew Berry")]
        HondewBerry = 149,
        [Description("Grepa Berry")]
        GrepaBerry = 150,
        [Description("Tamato Berry")]
        TamatoBerry = 151,
        [Description("Cornn Berry")]
        CornnBerry = 152,
        [Description("Magost Berry")]
        MagostBerry = 153,
        [Description("Rabuta Berry")]
        RabutaBerry = 154,
        [Description("Nomel Berry")]
        NomelBerry = 155,
        [Description("Spelon Berry")]
        SpelonBerry = 156,
        [Description("Pamtre Berry")]
        PamtreBerry = 157,
        [Description("Watmel Berry")]
        WatmelBerry = 158,
        [Description("Durin Berry")]
        DurinBerry = 159,
        [Description("Belue Berry")]
        BelueBerry = 160,
        [Description("Occa Berry")]
        OccaBerry = 161,
        [Description("Passho Berry")]
        PasshoBerry = 162,
        [Description("Wacan Berry")]
        WacanBerry = 163,
        [Description("Rindo Berry")]
        RindoBerry = 164,
        [Description("Yache Berry")]
        YacheBerry = 165,
        [Description("Chople Berry")]
        ChopleBerry = 166,
        [Description("Kebia Berry")]
        KebiaBerry = 167,
        [Description("Shuca Berry")]
        ShucaBerry = 168,
        [Description("Coba Berry")]
        CobaBerry = 169,
        [Description("Payapa Berry")]
        PayapaBerry = 170,
        [Description("Tanga Berry")]
        TangaBerry = 171,
        [Description("Charti Berry")]
        ChartiBerry = 172,
        [Description("Kasib Berry")]
        KasibBerry = 173,
        [Description("Haban Berry")]
        HabanBerry = 174,
        [Description("Colbur Berry")]
        ColburBerry = 175,
        [Description("Babiri Berry")]
        BabiriBerry = 176,
        [Description("Chilan Berry")]
        ChilanBerry = 177,
        [Description("Liechi Berry")]
        LiechiBerry = 178,
        [Description("Ganlon Berry")]
        GanlonBerry = 179,
        [Description("Salac Berry")]
        SalacBerry = 180,
        [Description("Petaya Berry")]
        PetayaBerry = 181,
        [Description("Apicot Berry")]
        ApicotBerry = 182,
        [Description("Lansat Berry")]
        LansatBerry = 183,
        [Description("Starf Berry")]
        StarfBerry = 184,
        [Description("Enigma Berry")]
        EnigmaBerry = 185,
        [Description("Micle Berry")]
        MicleBerry = 186,
        [Description("Custap Berry")]
        CustapBerry = 187,
        [Description("Jaboca Berry")]
        JabocaBerry = 188,
        [Description("Rowap Berry")]
        RowapBerry = 189,
        [Description("Bright Powder")]
        BrightPowder = 190,
        [Description("White Herb")]
        WhiteHerb = 191,
        [Description("Macho Brace")]
        MachoBrace = 192,
        [Description("Exp. Share")]
        ExpShare = 193,
        [Description("Quick Claw")]
        QuickClaw = 194,
        [Description("Soothe Bell")]
        SootheBell = 195,
        [Description("Mental Herb")]
        MentalHerb = 196,
        [Description("Choice Band")]
        ChoiceBand = 197,
        [Description("King’s Rock")]
        KingsRock = 198,
        [Description("Silver Powder")]
        SilverPowder = 199,
        [Description("Amulet Coin")]
        AmuletCoin = 200,
        [Description("Cleanse Tag")]
        CleanseTag = 201,
        [Description("Soul Dew")]
        SoulDew = 202,
        [Description("Deep Sea Tooth")]
        DeepSeaTooth = 203,
        [Description("Deep Sea Scale")]
        DeepSeaScale = 204,
        [Description("Smoke Ball")]
        SmokeBall = 205,
        [Description("Everstone")]
        Everstone = 206,
        [Description("Focus Band")]
        FocusBand = 207,
        [Description("Lucky Egg")]
        LuckyEgg = 208,
        [Description("Scope Lens")]
        ScopeLens = 209,
        [Description("Metal Coat")]
        MetalCoat = 210,
        [Description("Leftovers")]
        Leftovers = 211,
        [Description("Dragon Scale")]
        DragonScale = 212,
        [Description("Light Ball")]
        LightBall = 213,
        [Description("Soft Sand")]
        SoftSand = 214,
        [Description("Hard Stone")]
        HardStone = 215,
        [Description("Miracle Seed")]
        MiracleSeed = 216,
        [Description("Black Glasses")]
        BlackGlasses = 217,
        [Description("Black Belt")]
        BlackBelt = 218,
        [Description("Magnet")]
        Magnet = 219,
        [Description("Mystic Water")]
        MysticWater = 220,
        [Description("Sharp Beak")]
        SharpBeak = 221,
        [Description("Poison Barb")]
        PoisonBarb = 222,
        [Description("Never-Melt Ice")]
        NeverMeltIce = 223,
        [Description("Spell Tag")]
        SpellTag = 224,
        [Description("Twisted Spoon")]
        TwistedSpoon = 225,
        [Description("Charcoal")]
        Charcoal = 226,
        [Description("Dragon Fang")]
        DragonFang = 227,
        [Description("Silk Scarf")]
        SilkScarf = 228,
        [Description("Upgrade")]
        UpGrade = 229,
        [Description("Shell Bell")]
        ShellBell = 230,
        [Description("Sea Incense")]
        SeaIncense = 231,
        [Description("Lax Incense")]
        LaxIncense = 232,
        [Description("Lucky Punch")]
        LuckyPunch = 233,
        [Description("Metal Powder")]
        MetalPowder = 234,
        [Description("Thick Club")]
        ThickClub = 235,
        [Description("Leek")]
        Stick = 236,
        [Description("Red Scarf")]
        RedScarf = 237,
        [Description("Blue Scarf")]
        BlueScarf = 238,
        [Description("Pink Scarf")]
        PinkScarf = 239,
        [Description("Green Scarf")]
        GreenScarf = 240,
        [Description("Yellow Scarf")]
        YellowScarf = 241,
        [Description("Wide Lens")]
        WideLens = 242,
        [Description("Muscle Band")]
        MuscleBand = 243,
        [Description("Wise Glasses")]
        WiseGlasses = 244,
        [Description("Expert Belt")]
        ExpertBelt = 245,
        [Description("Light Clay")]
        LightClay = 246,
        [Description("Life Orb")]
        LifeOrb = 247,
        [Description("Power Herb")]
        PowerHerb = 248,
        [Description("Toxic Orb")]
        ToxicOrb = 249,
        [Description("Flame Orb")]
        FlameOrb = 250,
        [Description("Quick Powder")]
        QuickPowder = 251,
        [Description("Focus Sash")]
        FocusSash = 252,
        [Description("Zoom Lens")]
        ZoomLens = 253,
        [Description("Metronome")]
        Metronome = 254,
        [Description("Iron Ball")]
        IronBall = 255,
        [Description("Lagging Tail")]
        LaggingTail = 256,
        [Description("Destiny Knot")]
        DestinyKnot = 257,
        [Description("Black Sludge")]
        BlackSludge = 258,
        [Description("Icy Rock")]
        IcyRock = 259,
        [Description("Smooth Rock")]
        SmoothRock = 260,
        [Description("Heat Rock")]
        HeatRock = 261,
        [Description("Damp Rock")]
        DampRock = 262,
        [Description("Grip Claw")]
        GripClaw = 263,
        [Description("Choice Scarf")]
        ChoiceScarf = 264,
        [Description("Sticky Barb")]
        StickyBarb = 265,
        [Description("Power Bracer")]
        PowerBracer = 266,
        [Description("Power Belt")]
        PowerBelt = 267,
        [Description("Power Lens")]
        PowerLens = 268,
        [Description("Power Band")]
        PowerBand = 269,
        [Description("Power Anklet")]
        PowerAnklet = 270,
        [Description("Power Weight")]
        PowerWeight = 271,
        [Description("Shed Shell")]
        ShedShell = 272,
        [Description("Big Root")]
        BigRoot = 273,
        [Description("Choice Specs")]
        ChoiceSpecs = 274,
        [Description("Flame Plate")]
        FlamePlate = 275,
        [Description("Splash Plate")]
        SplashPlate = 276,
        [Description("Zap Plate")]
        ZapPlate = 277,
        [Description("Meadow Plate")]
        MeadowPlate = 278,
        [Description("Icicle Plate")]
        IciclePlate = 279,
        [Description("Fist Plate")]
        FistPlate = 280,
        [Description("Toxic Plate")]
        ToxicPlate = 281,
        [Description("Earth Plate")]
        EarthPlate = 282,
        [Description("Sky Plate")]
        SkyPlate = 283,
        [Description("Mind Plate")]
        MindPlate = 284,
        [Description("Insect Plate")]
        InsectPlate = 285,
        [Description("Stone Plate")]
        StonePlate = 286,
        [Description("Spooky Plate")]
        SpookyPlate = 287,
        [Description("Draco Plate")]
        DracoPlate = 288,
        [Description("Dread Plate")]
        DreadPlate = 289,
        [Description("Iron Plate")]
        IronPlate = 290,
        [Description("Odd Incense")]
        OddIncense = 291,
        [Description("Rock Incense")]
        RockIncense = 292,
        [Description("Full Incense")]
        FullIncense = 293,
        [Description("Wave Incense")]
        WaveIncense = 294,
        [Description("Rose Incense")]
        RoseIncense = 295,
        [Description("Luck Incense")]
        LuckIncense = 296,
        [Description("Pure Incense")]
        PureIncense = 297,
        [Description("Protector")]
        Protector = 298,
        [Description("Electirizer")]
        Electirizer = 299,
        [Description("Magmarizer")]
        Magmarizer = 300,
        [Description("Dubious Disc")]
        DubiousDisc = 301,
        [Description("Reaper Cloth")]
        ReaperCloth = 302,
        [Description("Razor Claw")]
        RazorClaw = 303,
        [Description("Razor Fang")]
        RazorFang = 304,
        [Description("TM01")]
        Tm01 = 305,
        [Description("TM02")]
        Tm02 = 306,
        [Description("TM03")]
        Tm03 = 307,
        [Description("TM04")]
        Tm04 = 308,
        [Description("TM05")]
        Tm05 = 309,
        [Description("TM06")]
        Tm06 = 310,
        [Description("TM07")]
        Tm07 = 311,
        [Description("TM08")]
        Tm08 = 312,
        [Description("TM09")]
        Tm09 = 313,
        [Description("TM10")]
        Tm10 = 314,
        [Description("TM11")]
        Tm11 = 315,
        [Description("TM12")]
        Tm12 = 316,
        [Description("TM13")]
        Tm13 = 317,
        [Description("TM14")]
        Tm14 = 318,
        [Description("TM15")]
        Tm15 = 319,
        [Description("TM16")]
        Tm16 = 320,
        [Description("TM17")]
        Tm17 = 321,
        [Description("TM18")]
        Tm18 = 322,
        [Description("TM19")]
        Tm19 = 323,
        [Description("TM20")]
        Tm20 = 324,
        [Description("TM21")]
        Tm21 = 325,
        [Description("TM22")]
        Tm22 = 326,
        [Description("TM23")]
        Tm23 = 327,
        [Description("TM24")]
        Tm24 = 328,
        [Description("TM25")]
        Tm25 = 329,
        [Description("TM26")]
        Tm26 = 330,
        [Description("TM27")]
        Tm27 = 331,
        [Description("TM28")]
        Tm28 = 332,
        [Description("TM29")]
        Tm29 = 333,
        [Description("TM30")]
        Tm30 = 334,
        [Description("TM31")]
        Tm31 = 335,
        [Description("TM32")]
        Tm32 = 336,
        [Description("TM33")]
        Tm33 = 337,
        [Description("TM34")]
        Tm34 = 338,
        [Description("TM35")]
        Tm35 = 339,
        [Description("TM36")]
        Tm36 = 340,
        [Description("TM37")]
        Tm37 = 341,
        [Description("TM38")]
        Tm38 = 342,
        [Description("TM39")]
        Tm39 = 343,
        [Description("TM40")]
        Tm40 = 344,
        [Description("TM41")]
        Tm41 = 345,
        [Description("TM42")]
        Tm42 = 346,
        [Description("TM43")]
        Tm43 = 347,
        [Description("TM44")]
        Tm44 = 348,
        [Description("TM45")]
        Tm45 = 349,
        [Description("TM46")]
        Tm46 = 350,
        [Description("TM47")]
        Tm47 = 351,
        [Description("TM48")]
        Tm48 = 352,
        [Description("TM49")]
        Tm49 = 353,
        [Description("TM50")]
        Tm50 = 354,
        [Description("TM51")]
        Tm51 = 355,
        [Description("TM52")]
        Tm52 = 356,
        [Description("TM53")]
        Tm53 = 357,
        [Description("TM54")]
        Tm54 = 358,
        [Description("TM55")]
        Tm55 = 359,
        [Description("TM56")]
        Tm56 = 360,
        [Description("TM57")]
        Tm57 = 361,
        [Description("TM58")]
        Tm58 = 362,
        [Description("TM59")]
        Tm59 = 363,
        [Description("TM60")]
        Tm60 = 364,
        [Description("TM61")]
        Tm61 = 365,
        [Description("TM62")]
        Tm62 = 366,
        [Description("TM63")]
        Tm63 = 367,
        [Description("TM64")]
        Tm64 = 368,
        [Description("TM65")]
        Tm65 = 369,
        [Description("TM66")]
        Tm66 = 370,
        [Description("TM67")]
        Tm67 = 371,
        [Description("TM68")]
        Tm68 = 372,
        [Description("TM69")]
        Tm69 = 373,
        [Description("TM70")]
        Tm70 = 374,
        [Description("TM71")]
        Tm71 = 375,
        [Description("TM72")]
        Tm72 = 376,
        [Description("TM73")]
        Tm73 = 377,
        [Description("TM74")]
        Tm74 = 378,
        [Description("TM75")]
        Tm75 = 379,
        [Description("TM76")]
        Tm76 = 380,
        [Description("TM77")]
        Tm77 = 381,
        [Description("TM78")]
        Tm78 = 382,
        [Description("TM79")]
        Tm79 = 383,
        [Description("TM80")]
        Tm80 = 384,
        [Description("TM81")]
        Tm81 = 385,
        [Description("TM82")]
        Tm82 = 386,
        [Description("TM83")]
        Tm83 = 387,
        [Description("TM84")]
        Tm84 = 388,
        [Description("TM85")]
        Tm85 = 389,
        [Description("TM86")]
        Tm86 = 390,
        [Description("TM87")]
        Tm87 = 391,
        [Description("TM88")]
        Tm88 = 392,
        [Description("TM89")]
        Tm89 = 393,
        [Description("TM90")]
        Tm90 = 394,
        [Description("TM91")]
        Tm91 = 395,
        [Description("TM92")]
        Tm92 = 396,
        [Description("HM01")]
        Hm01 = 397,
        [Description("HM02")]
        Hm02 = 398,
        [Description("HM03")]
        Hm03 = 399,
        [Description("HM04")]
        Hm04 = 400,
        [Description("HM05")]
        Hm05 = 401,
        [Description("HM06")]
        Hm06 = 402,
        [Description("HM07")]
        Hm07 = 403,
        [Description("HM08")]
        Hm08 = 404,
        [Description("Explorer Kit")]
        ExplorerKit = 405,
        [Description("Loot Sack")]
        LootSack = 406,
        [Description("Rule Book")]
        RuleBook = 407,
        [Description("Poké Radar")]
        PokeRadar = 408,
        [Description("Point Card")]
        PointCard = 409,
        [Description("Journal")]
        Journal = 410,
        [Description("Seal Case")]
        SealCase = 411,
        [Description("Fashion Case")]
        FashionCase = 412,
        [Description("Seal Bag")]
        SealBag = 413,
        [Description("Pal Pad")]
        PalPad = 414,
        [Description("Works Key")]
        WorksKey = 415,
        [Description("Old Charm")]
        OldCharm = 416,
        [Description("Galactic Key")]
        GalacticKey = 417,
        [Description("Red Chain")]
        RedChain = 418,
        [Description("Town Map")]
        TownMap = 419,
        [Description("Vs. Seeker")]
        VsSeeker = 420,
        [Description("Coin Case")]
        CoinCase = 421,
        [Description("Old Rod")]
        OldRod = 422,
        [Description("Good Rod")]
        GoodRod = 423,
        [Description("Super Rod")]
        SuperRod = 424,
        [Description("Sprayduck")]
        Sprayduck = 425,
        [Description("Poffin Case")]
        PoffinCase = 426,
        [Description("Bicycle")]
        Bicycle = 427,
        [Description("Suite Key")]
        SuiteKey = 428,
        [Description("Oak’s Letter")]
        OaksLetter = 429,
        [Description("Lunar Wing")]
        LunarWing = 430,
        [Description("Member Card")]
        MemberCard = 431,
        [Description("Azure Flute")]
        AzureFlute = 432,
        [Description("S.S. Ticket")]
        SsTicket = 433,
        [Description("Contest Pass")]
        ContestPass = 434,
        [Description("Magma Stone")]
        MagmaStone = 435,
        [Description("Parcel")]
        Parcel = 436,
        [Description("Coupon 1")]
        Coupon1 = 437,
        [Description("Coupon 2")]
        Coupon2 = 438,
        [Description("Coupon 3")]
        Coupon3 = 439,
        [Description("Storage Key")]
        StorageKey = 440,
        [Description("Secret Potion")]
        SecretPotion = 441,
        [Description("Griseous Orb")]
        GriseousOrb = 442,
        [Description("Vs. Recorder")]
        VsRecorder = 443,
        [Description("Gracidea")]
        Gracidea = 444,
        [Description("Secret Key")]
        SecretKey = 445,
        [Description("Apricorn Box")]
        ApricornBox = 446,
        [Description("Berry Pots")]
        BerryPots = 447,
        [Description("Squirt Bottle")]
        SquirtBottle = 448,
        [Description("Lure Ball")]
        LureBall = 449,
        [Description("Level Ball")]
        LevelBall = 450,
        [Description("Moon Ball")]
        MoonBall = 451,
        [Description("Heavy Ball")]
        HeavyBall = 452,
        [Description("Fast Ball")]
        FastBall = 453,
        [Description("Friend Ball")]
        FriendBall = 454,
        [Description("Love Ball")]
        LoveBall = 455,
        [Description("Park Ball")]
        ParkBall = 456,
        [Description("Sport Ball")]
        SportBall = 457,
        [Description("Red Apricorn")]
        RedApricorn = 458,
        [Description("Blue Apricorn")]
        BlueApricorn = 459,
        [Description("Yellow Apricorn")]
        YellowApricorn = 460,
        [Description("Green Apricorn")]
        GreenApricorn = 461,
        [Description("Pink Apricorn")]
        PinkApricorn = 462,
        [Description("White Apricorn")]
        WhiteApricorn = 463,
        [Description("Black Apricorn")]
        BlackApricorn = 464,
        [Description("Dowsing Machine")]
        DowsingMachine = 465,
        [Description("Rage Candy Bar")]
        RageCandyBar = 466,
        [Description("Red Orb")]
        RedOrb = 467,
        [Description("Blue Orb")]
        BlueOrb = 468,
        [Description("Jade Orb")]
        JadeOrb = 469,
        [Description("Enigma Stone")]
        EnigmaStone = 470,
        [Description("Unown Report")]
        UnownReport = 471,
        [Description("Blue Card")]
        BlueCard = 472,
        [Description("Slowpoke Tail")]
        SlowpokeTail = 473,
        [Description("Clear Bell")]
        ClearBell = 474,
        [Description("Card Key")]
        CardKey = 475,
        [Description("Basement Key")]
        BasementKey = 476,
        [Description("Red Scale")]
        RedScale = 477,
        [Description("Lost Item")]
        LostItem = 478,
        [Description("Pass")]
        Pass = 479,
        [Description("Machine Part")]
        MachinePart = 480,
        [Description("Silver Wing")]
        SilverWing = 481,
        [Description("Rainbow Wing")]
        RainbowWing = 482,
        [Description("Mystery Egg")]
        MysteryEgg = 483,
        [Description("GB Sounds")]
        GbSounds = 484,
        [Description("Tidal Bell")]
        TidalBell = 485,
        [Description("Data Card 01")]
        DataCard01 = 486,
        [Description("Data Card 02")]
        DataCard02 = 487,
        [Description("Data Card 03")]
        DataCard03 = 488,
        [Description("Data Card 04")]
        DataCard04 = 489,
        [Description("Data Card 05")]
        DataCard05 = 490,
        [Description("Data Card 06")]
        DataCard06 = 491,
        [Description("Data Card 07")]
        DataCard07 = 492,
        [Description("Data Card 08")]
        DataCard08 = 493,
        [Description("Data Card 09")]
        DataCard09 = 494,
        [Description("Data Card 10")]
        DataCard10 = 495,
        [Description("Data Card 11")]
        DataCard11 = 496,
        [Description("Data Card 12")]
        DataCard12 = 497,
        [Description("Data Card 13")]
        DataCard13 = 498,
        [Description("Data Card 14")]
        DataCard14 = 499,
        [Description("Data Card 15")]
        DataCard15 = 500,
        [Description("Data Card 16")]
        DataCard16 = 501,
        [Description("Data Card 17")]
        DataCard17 = 502,
        [Description("Data Card 18")]
        DataCard18 = 503,
        [Description("Data Card 19")]
        DataCard19 = 504,
        [Description("Data Card 20")]
        DataCard20 = 505,
        [Description("Data Card 21")]
        DataCard21 = 506,
        [Description("Data Card 22")]
        DataCard22 = 507,
        [Description("Data Card 23")]
        DataCard23 = 508,
        [Description("Data Card 24")]
        DataCard24 = 509,
        [Description("Data Card 25")]
        DataCard25 = 510,
        [Description("Data Card 26")]
        DataCard26 = 511,
        [Description("Data Card 27")]
        DataCard27 = 512,
        [Description("Lock Capsule")]
        LockCapsule = 513,
        [Description("Photo Album")]
        PhotoAlbum = 514,
        [Description("Orange Mail")]
        OrangeMail = 515,
        [Description("Harbor Mail")]
        HarborMail = 516,
        [Description("Glitter Mail")]
        GlitterMail = 517,
        [Description("Mech Mail")]
        MechMail = 518,
        [Description("Wood Mail")]
        WoodMail = 519,
        [Description("Wave Mail")]
        WaveMail = 520,
        [Description("Bead Mail")]
        BeadMail = 521,
        [Description("Shadow Mail")]
        ShadowMail = 522,
        [Description("Tropic Mail")]
        TropicMail = 523,
        [Description("Dream Mail")]
        DreamMail = 524,
        [Description("Fab Mail")]
        FabMail = 525,
        [Description("Retro Mail")]
        RetroMail = 526,
        [Description("Mach Bike")]
        MachBike = 527,
        [Description("Acro Bike")]
        AcroBike = 528,
        [Description("Wailmer Pail")]
        WailmerPail = 529,
        [Description("Devon Goods")]
        DevonGoods = 530,
        [Description("Soot Sack")]
        SootSack = 531,
        [Description("Pokéblock Case")]
        PokeblockCase = 532,
        [Description("Letter")]
        Letter = 533,
        [Description("Eon Ticket")]
        EonTicket = 534,
        [Description("Scanner")]
        Scanner = 535,
        [Description("Go-Goggles")]
        GoGoggles = 536,
        [Description("Meteorite")]
        Meteorite = 537,
        [Description("Rm. 1 Key")]
        Rm1Key = 538,
        [Description("Rm. 2 Key")]
        Rm2Key = 539,
        [Description("Rm. 4 Key")]
        Rm4Key = 540,
        [Description("Rm. 6 Key")]
        Rm6Key = 541,
        [Description("Devon Scope")]
        DevonScope = 542,
        [Description("Oak’s Parcel")]
        OaksParcel = 543,
        [Description("Poké Flute")]
        PokeFlute = 544,
        [Description("Bike Voucher")]
        BikeVoucher = 545,
        [Description("Gold Teeth")]
        GoldTeeth = 546,
        [Description("Lift Key")]
        LiftKey = 547,
        [Description("Silph Scope")]
        SilphScope = 548,
        [Description("Fame Checker")]
        FameChecker = 549,
        [Description("TM Case")]
        TmCase = 550,
        [Description("Berry Pouch")]
        BerryPouch = 551,
        [Description("Teachy TV")]
        TeachyTv = 552,
        [Description("Tri-Pass")]
        TriPass = 553,
        [Description("Rainbow Pass")]
        RainbowPass = 554,
        [Description("Tea")]
        Tea = 555,
        [Description("MysticTicket")]
        Mysticticket = 556,
        [Description("AuroraTicket")]
        Auroraticket = 557,
        [Description("Powder Jar")]
        PowderJar = 558,
        [Description("Ruby")]
        Ruby = 559,
        [Description("Sapphire")]
        Sapphire = 560,
        [Description("Magma Emblem")]
        MagmaEmblem = 561,
        [Description("Old Sea Map")]
        OldSeaMap = 562,
        [Description("Douse Drive")]
        DouseDrive = 563,
        [Description("Shock Drive")]
        ShockDrive = 564,
        [Description("Burn Drive")]
        BurnDrive = 565,
        [Description("Chill Drive")]
        ChillDrive = 566,
        [Description("Sweet Heart")]
        SweetHeart = 567,
        [Description("Greet Mail")]
        GreetMail = 568,
        [Description("Favored Mail")]
        FavoredMail = 569,
        [Description("RSVP Mail")]
        RsvpMail = 570,
        [Description("Thanks Mail")]
        ThanksMail = 571,
        [Description("Inquiry Mail")]
        InquiryMail = 572,
        [Description("Like Mail")]
        LikeMail = 573,
        [Description("Reply Mail")]
        ReplyMail = 574,
        [Description("Bridge Mail S")]
        BridgeMailS = 575,
        [Description("Bridge Mail D")]
        BridgeMailD = 576,
        [Description("Bridge Mail T")]
        BridgeMailT = 577,
        [Description("Bridge Mail V")]
        BridgeMailV = 578,
        [Description("Bridge Mail M")]
        BridgeMailM = 579,
        [Description("Prism Scale")]
        PrismScale = 580,
        [Description("Eviolite")]
        Eviolite = 581,
        [Description("Float Stone")]
        FloatStone = 582,
        [Description("Rocky Helmet")]
        RockyHelmet = 583,
        [Description("Air Balloon")]
        AirBalloon = 584,
        [Description("Red Card")]
        RedCard = 585,
        [Description("Ring Target")]
        RingTarget = 586,
        [Description("Binding Band")]
        BindingBand = 587,
        [Description("Absorb Bulb")]
        AbsorbBulb = 588,
        [Description("Cell Battery")]
        CellBattery = 589,
        [Description("Eject Button")]
        EjectButton = 590,
        [Description("Fire Gem")]
        FireGem = 591,
        [Description("Water Gem")]
        WaterGem = 592,
        [Description("Electric Gem")]
        ElectricGem = 593,
        [Description("Grass Gem")]
        GrassGem = 594,
        [Description("Ice Gem")]
        IceGem = 595,
        [Description("Fighting Gem")]
        FightingGem = 596,
        [Description("Poison Gem")]
        PoisonGem = 597,
        [Description("Ground Gem")]
        GroundGem = 598,
        [Description("Flying Gem")]
        FlyingGem = 599,
        [Description("Psychic Gem")]
        PsychicGem = 600,
        [Description("Bug Gem")]
        BugGem = 601,
        [Description("Rock Gem")]
        RockGem = 602,
        [Description("Ghost Gem")]
        GhostGem = 603,
        [Description("Dark Gem")]
        DarkGem = 604,
        [Description("Steel Gem")]
        SteelGem = 605,
        [Description("Health Feather")]
        HealthWing = 606,
        [Description("Muscle Feather")]
        MuscleWing = 607,
        [Description("Resist Feather")]
        ResistWing = 608,
        [Description("Genius Feather")]
        GeniusWing = 609,
        [Description("Clever Feather")]
        CleverWing = 610,
        [Description("Swift Feather")]
        SwiftWing = 611,
        [Description("Pretty Feather")]
        PrettyWing = 612,
        [Description("Cover Fossil")]
        CoverFossil = 613,
        [Description("Plume Fossil")]
        PlumeFossil = 614,
        [Description("Liberty Pass")]
        LibertyPass = 615,
        [Description("Pass Orb")]
        PassOrb = 616,
        [Description("Dream Ball")]
        DreamBall = 617,
        [Description("Poké Toy")]
        PokeToy = 618,
        [Description("Prop Case")]
        PropCase = 619,
        [Description("Dragon Skull")]
        DragonSkull = 620,
        [Description("Balm Mushroom")]
        BalmMushroom = 621,
        [Description("Big Nugget")]
        BigNugget = 622,
        [Description("Pearl String")]
        PearlString = 623,
        [Description("Comet Shard")]
        CometShard = 624,
        [Description("Relic Copper")]
        RelicCopper = 625,
        [Description("Relic Silver")]
        RelicSilver = 626,
        [Description("Relic Gold")]
        RelicGold = 627,
        [Description("Relic Vase")]
        RelicVase = 628,
        [Description("Relic Band")]
        RelicBand = 629,
        [Description("Relic Statue")]
        RelicStatue = 630,
        [Description("Relic Crown")]
        RelicCrown = 631,
        [Description("Casteliacone")]
        Casteliacone = 632,
        [Description("Dire Hit 2")]
        DireHit2 = 633,
        [Description("X Speed 2")]
        XSpeed2 = 634,
        [Description("X Sp. Atk 2")]
        XSpAtk2 = 635,
        [Description("X Sp. Def 2")]
        XSpDef2 = 636,
        [Description("X Defense 2")]
        XDefense2 = 637,
        [Description("X Attack 2")]
        XAttack2 = 638,
        [Description("X Accuracy 2")]
        XAccuracy2 = 639,
        [Description("X Speed 3")]
        XSpeed3 = 640,
        [Description("X Sp. Atk 3")]
        XSpAtk3 = 641,
        [Description("X Sp. Def 3")]
        XSpDef3 = 642,
        [Description("X Defense 3")]
        XDefense3 = 643,
        [Description("X Attack 3")]
        XAttack3 = 644,
        [Description("X Accuracy 3")]
        XAccuracy3 = 645,
        [Description("X Speed 6")]
        XSpeed6 = 646,
        [Description("X Sp. Atk 6")]
        XSpAtk6 = 647,
        [Description("X Sp. Def 6")]
        XSpDef6 = 648,
        [Description("X Defense 6")]
        XDefense6 = 649,
        [Description("X Attack 6")]
        XAttack6 = 650,
        [Description("X Accuracy 6")]
        XAccuracy6 = 651,
        [Description("Ability Urge")]
        AbilityUrge = 652,
        [Description("Item Drop")]
        ItemDrop = 653,
        [Description("Item Urge")]
        ItemUrge = 654,
        [Description("Reset Urge")]
        ResetUrge = 655,
        [Description("Dire Hit 3")]
        DireHit3 = 656,
        [Description("Light Stone")]
        LightStone = 657,
        [Description("Dark Stone")]
        DarkStone = 658,
        [Description("TM93")]
        Tm93 = 659,
        [Description("TM94")]
        Tm94 = 660,
        [Description("TM95")]
        Tm95 = 661,
        [Description("Xtransceiver")]
        Xtransceiver = 662,
        [Description("god stone")]
        GodStone = 663,
        [Description("Gram 1")]
        Gram1 = 664,
        [Description("Gram 2")]
        Gram2 = 665,
        [Description("Gram 3")]
        Gram3 = 666,
        [Description("Dragon Gem")]
        DragonGem = 668,
        [Description("Normal Gem")]
        NormalGem = 669,
        [Description("Medal Box")]
        MedalBox = 670,
        [Description("DNA Splicers")]
        DnaSplicers = 671,
        [Description("Permit")]
        Permit = 673,
        [Description("Oval Charm")]
        OvalCharm = 674,
        [Description("Shiny Charm")]
        ShinyCharm = 675,
        [Description("Plasma Card")]
        PlasmaCard = 676,
        [Description("Grubby Hanky")]
        GrubbyHanky = 677,
        [Description("Colress Machine")]
        ColressMachine = 678,
        [Description("Dropped Item")]
        DroppedItem = 679,
        [Description("Reveal Glass")]
        RevealGlass = 681,
        [Description("Weakness Policy")]
        WeaknessPolicy = 682,
        [Description("Assault Vest")]
        AssaultVest = 683,
        [Description("Pixie Plate")]
        PixiePlate = 684,
        [Description("Ability Capsule")]
        AbilityCapsule = 685,
        [Description("Whipped Dream")]
        WhippedDream = 686,
        [Description("Sachet")]
        Sachet = 687,
        [Description("Luminous Moss")]
        LuminousMoss = 688,
        [Description("Snowball")]
        Snowball = 689,
        [Description("Safety Goggles")]
        SafetyGoggles = 690,
        [Description("Rich Mulch")]
        RichMulch = 691,
        [Description("Surprise Mulch")]
        SurpriseMulch = 692,
        [Description("Boost Mulch")]
        BoostMulch = 693,
        [Description("Amaze Mulch")]
        AmazeMulch = 694,
        [Description("Gengarite")]
        Gengarite = 695,
        [Description("Gardevoirite")]
        Gardevoirite = 696,
        [Description("Ampharosite")]
        Ampharosite = 697,
        [Description("Venusaurite")]
        Venusaurite = 698,
        [Description("Charizardite X")]
        CharizarditeX = 699,
        [Description("Blastoisinite")]
        Blastoisinite = 700,
        [Description("Mewtwonite X")]
        MewtwoniteX = 701,
        [Description("Mewtwonite Y")]
        MewtwoniteY = 702,
        [Description("Blazikenite")]
        Blazikenite = 703,
        [Description("Medichamite")]
        Medichamite = 704,
        [Description("Houndoominite")]
        Houndoominite = 705,
        [Description("Aggronite")]
        Aggronite = 706,
        [Description("Banettite")]
        Banettite = 707,
        [Description("Tyranitarite")]
        Tyranitarite = 708,
        [Description("Scizorite")]
        Scizorite = 709,
        [Description("Pinsirite")]
        Pinsirite = 710,
        [Description("Aerodactylite")]
        Aerodactylite = 711,
        [Description("Lucarionite")]
        Lucarionite = 712,
        [Description("Abomasite")]
        Abomasite = 713,
        [Description("Kangaskhanite")]
        Kangaskhanite = 714,
        [Description("Gyaradosite")]
        Gyaradosite = 715,
        [Description("Absolite")]
        Absolite = 716,
        [Description("Charizardite Y")]
        CharizarditeY = 717,
        [Description("Alakazite")]
        Alakazite = 718,
        [Description("Heracronite")]
        Heracronite = 719,
        [Description("Mawilite")]
        Mawilite = 720,
        [Description("Manectite")]
        Manectite = 721,
        [Description("Garchompite")]
        Garchompite = 722,
        [Description("Roseli Berry")]
        RoseliBerry = 723,
        [Description("Kee Berry")]
        KeeBerry = 724,
        [Description("Maranga Berry")]
        MarangaBerry = 725,
        [Description("Discount Coupon")]
        DiscountCoupon = 726,
        [Description("Strange Souvenir")]
        StrangeSouvenir = 727,
        [Description("Lumiose Galette")]
        LumioseGalette = 728,
        [Description("Jaw Fossil")]
        JawFossil = 729,
        [Description("Sail Fossil")]
        SailFossil = 730,
        [Description("Fairy Gem")]
        FairyGem = 731,
        [Description("Adventure Guide")]
        AdventureRules = 732,
        [Description("Elevator Key")]
        ElevatorKey = 733,
        [Description("Holo Caster")]
        HoloCaster = 734,
        [Description("Honor of Kalos")]
        HonorOfKalos = 735,
        [Description("Intriguing Stone")]
        IntriguingStone = 736,
        [Description("Lens Case")]
        LensCase = 737,
        [Description("Looker Ticket")]
        LookerTicket = 738,
        [Description("Mega Ring")]
        MegaRing = 739,
        [Description("Power Plant Pass")]
        PowerPlantPass = 740,
        [Description("Prof’s Letter")]
        ProfsLetter = 741,
        [Description("Roller Skates")]
        RollerSkates = 742,
        [Description("Sprinklotad")]
        Sprinklotad = 743,
        [Description("TMV Pass")]
        TmvPass = 744,
        [Description("TM96")]
        Tm96 = 745,
        [Description("TM97")]
        Tm97 = 746,
        [Description("TM98")]
        Tm98 = 747,
        [Description("TM99")]
        Tm99 = 748,
        [Description("TM100")]
        Tm100 = 749,
        [Description("Latiasite")]
        Latiasite = 760,
        [Description("Latiosite")]
        Latiosite = 761,
        [Description("Common Stone")]
        CommonStone = 762,
        [Description("Makeup Bag")]
        MakeupBag = 763,
        [Description("Travel Trunk")]
        TravelTrunk = 764,
        [Description("Shalour Sable")]
        ShalourSable = 765,
        [Description("Mega Charm")]
        MegaCharm = 768,
        [Description("Mega Glove")]
        MegaGlove = 769,
        [Description("Devon Parts")]
        DevonParts = 770,
        [Description("Pokéblock Kit")]
        PokeblockKit = 772,
        [Description("Key to Room 1")]
        KeyToRoom1 = 773,
        [Description("Key to Room 2")]
        KeyToRoom2 = 774,
        [Description("Key to Room 4")]
        KeyToRoom4 = 775,
        [Description("Key to Room 6")]
        KeyToRoom6 = 776,
        [Description("Devon Scuba Gear")]
        DevonScubaGear = 779,
        [Description("Contest Costume")]
        ContestCostumeJacket = 780,
        [Description("Magma Suit")]
        MagmaSuit = 782,
        [Description("Aqua Suit")]
        AquaSuit = 783,
        [Description("Pair of Tickets")]
        PairOfTickets = 784,
        [Description("Mega Bracelet")]
        MegaBracelet = 785,
        [Description("Mega Pendant")]
        MegaPendant = 786,
        [Description("Mega Glasses")]
        MegaGlasses = 787,
        [Description("Mega Anchor")]
        MegaAnchor = 788,
        [Description("Mega Stickpin")]
        MegaStickpin = 789,
        [Description("Mega Tiara")]
        MegaTiara = 790,
        [Description("Mega Anklet")]
        MegaAnklet = 791,
        [Description("Swampertite")]
        Swampertite = 793,
        [Description("Sceptilite")]
        Sceptilite = 794,
        [Description("Sablenite")]
        Sablenite = 795,
        [Description("Altarianite")]
        Altarianite = 796,
        [Description("Galladite")]
        Galladite = 797,
        [Description("Audinite")]
        Audinite = 798,
        [Description("Metagrossite")]
        Metagrossite = 799,
        [Description("Sharpedonite")]
        Sharpedonite = 800,
        [Description("Slowbronite")]
        Slowbronite = 801,
        [Description("Steelixite")]
        Steelixite = 802,
        [Description("Pidgeotite")]
        Pidgeotite = 803,
        [Description("Glalitite")]
        Glalitite = 804,
        [Description("Diancite")]
        Diancite = 805,
        [Description("Prison Bottle")]
        PrisonBottle = 806,
        [Description("Mega Cuff")]
        MegaCuff = 807,
        [Description("Cameruptite")]
        Cameruptite = 808,
        [Description("Lopunnite")]
        Lopunnite = 809,
        [Description("Salamencite")]
        Salamencite = 810,
        [Description("Beedrillite")]
        Beedrillite = 811,
        [Description("Key Stone")]
        KeyStone = 814,
        [Description("Meteorite Shard")]
        MeteoriteShard = 815,
        [Description("Eon Flute")]
        EonFlute = 816,
        [Description("Normalium Z")]
        NormaliumZHeld = 817,
        [Description("Firium Z")]
        FiriumZHeld = 818,
        [Description("Waterium Z")]
        WateriumZHeld = 819,
        [Description("Electrium Z")]
        ElectriumZHeld = 820,
        [Description("Grassium Z")]
        GrassiumZHeld = 821,
        [Description("Icium Z")]
        IciumZHeld = 822,
        [Description("Fightinium Z")]
        FightiniumZHeld = 823,
        [Description("Poisonium Z")]
        PoisoniumZHeld = 824,
        [Description("Groundium Z")]
        GroundiumZHeld = 825,
        [Description("Flyinium Z")]
        FlyiniumZHeld = 826,
        [Description("Psychium Z")]
        PsychiumZHeld = 827,
        [Description("Buginium Z")]
        BuginiumZHeld = 828,
        [Description("Rockium Z")]
        RockiumZHeld = 829,
        [Description("Ghostium Z")]
        GhostiumZHeld = 830,
        [Description("Dragonium Z")]
        DragoniumZHeld = 831,
        [Description("Darkinium Z")]
        DarkiniumZHeld = 832,
        [Description("Steelium Z")]
        SteeliumZHeld = 833,
        [Description("Fairium Z")]
        FairiumZHeld = 834,
        [Description("Pikanium Z")]
        PikaniumZHeld = 835,
        [Description("Bottle Cap")]
        BottleCap = 836,
        [Description("Gold Bottle Cap")]
        GoldBottleCap = 837,
        [Description("Z-Ring")]
        ZRing = 838,
        [Description("Decidium Z")]
        DecidiumZHeld = 839,
        [Description("Incinium Z")]
        InciniumZHeld = 840,
        [Description("Primarium Z")]
        PrimariumZHeld = 841,
        [Description("Tapunium Z")]
        TapuniumZHeld = 842,
        [Description("Marshadium Z")]
        MarshadiumZHeld = 843,
        [Description("Aloraichium Z")]
        AloraichiumZHeld = 844,
        [Description("Snorlium Z")]
        SnorliumZHeld = 845,
        [Description("Eevium Z")]
        EeviumZHeld = 846,
        [Description("Mewnium Z")]
        MewniumZHeld = 847,
        [Description("Pikashunium Z")]
        PikashuniumZHeld = 877,
        [Description("Forage Bag")]
        ForageBag = 878,
        [Description("Fishing Rod")]
        FishingRod = 879,
        [Description("Professor’s Mask")]
        ProfessorsMask = 880,
        [Description("Festival Ticket")]
        FestivalTicket = 881,
        [Description("Sparkling Stone")]
        SparklingStone = 882,
        [Description("Adrenaline Orb")]
        AdrenalineOrb = 883,
        [Description("Zygarde Cube")]
        ZygardeCube = 884,
        [Description("Ice Stone")]
        IceStone = 885,
        [Description("Ride Pager")]
        RidePager = 886,
        [Description("Beast Ball")]
        BeastBall = 887,
        [Description("Big Malasada")]
        BigMalasada = 888,
        [Description("Red Nectar")]
        RedNectar = 889,
        [Description("Yellow Nectar")]
        YellowNectar = 890,
        [Description("Pink Nectar")]
        PinkNectar = 891,
        [Description("Purple Nectar")]
        PurpleNectar = 892,
        [Description("Sun Flute")]
        SunFlute = 893,
        [Description("Moon Flute")]
        MoonFlute = 894,
        [Description("Enigmatic Card")]
        EnigmaticCard = 895,
        [Description("Terrain Extender")]
        TerrainExtender = 896,
        [Description("Protective Pads")]
        ProtectivePads = 897,
        [Description("Electric Seed")]
        ElectricSeed = 898,
        [Description("Psychic Seed")]
        PsychicSeed = 899,
        [Description("Misty Seed")]
        MistySeed = 900,
        [Description("Grassy Seed")]
        GrassySeed = 901,
        [Description("Fighting Memory")]
        FightingMemory = 902,
        [Description("Flying Memory")]
        FlyingMemory = 903,
        [Description("Poison Memory")]
        PoisonMemory = 904,
        [Description("Ground Memory")]
        GroundMemory = 905,
        [Description("Rock Memory")]
        RockMemory = 906,
        [Description("Bug Memory")]
        BugMemory = 907,
        [Description("Ghost Memory")]
        GhostMemory = 908,
        [Description("Steel Memory")]
        SteelMemory = 909,
        [Description("Fire Memory")]
        FireMemory = 910,
        [Description("Water Memory")]
        WaterMemory = 911,
        [Description("Grass Memory")]
        GrassMemory = 912,
        [Description("Electric Memory")]
        ElectricMemory = 913,
        [Description("Psychic Memory")]
        PsychicMemory = 914,
        [Description("Ice Memory")]
        IceMemory = 915,
        [Description("Dragon Memory")]
        DragonMemory = 916,
        [Description("Dark Memory")]
        DarkMemory = 917,
        [Description("Fairy Memory")]
        FairyMemory = 918,
        [Description("Bike")]
        BikeGreen = 919,
        [Description("Storage Key")]
        StorageKeyGalacticWarehouse = 920,
        [Description("Basement Key")]
        BasementKeyGoldenrod = 921,
        [Description("Xtransceiver")]
        XtransceiverRed = 922,
        [Description("Xtransceiver")]
        XtransceiverYellow = 923,
        [Description("DNA Splicers")]
        DnaSplicersMerge = 924,
        [Description("DNA Splicers")]
        DnaSplicersSplit = 925,
        [Description("Dropped Item")]
        DroppedItemRed = 926,
        [Description("Dropped Item")]
        DroppedItemYellow = 927,
        [Description("Holo Caster")]
        HoloCasterGreen = 928,
        [Description("Bike")]
        BikeYellow = 929,
        [Description("Holo Caster")]
        HoloCasterRed = 930,
        [Description("Basement Key")]
        BasementKeyNewMauville = 931,
        [Description("Storage Key")]
        StorageKeySeaMauville = 932,
        [Description("S.S. Ticket")]
        SsTicketHoenn = 933,
        [Description("Contest Costume")]
        ContestCostumeDress = 934,
        [Description("Meteorite")]
        Meteorite2 = 935,
        [Description("Meteorite")]
        Meteorite3 = 936,
        [Description("Meteorite")]
        Meteorite4 = 937,
        [Description("Normalium Z")]
        NormaliumZBag = 938,
        [Description("Firium Z")]
        FiriumZBag = 939,
        [Description("Waterium Z")]
        WateriumZBag = 940,
        [Description("Electrium Z")]
        ElectriumZBag = 941,
        [Description("Grassium Z")]
        GrassiumZBag = 942,
        [Description("Icium Z")]
        IciumZBag = 943,
        [Description("Fightinium Z")]
        FightiniumZBag = 944,
        [Description("Poisonium Z")]
        PoisoniumZBag = 945,
        [Description("Groundium Z")]
        GroundiumZBag = 946,
        [Description("Flyinium Z")]
        FlyiniumZBag = 947,
        [Description("Psychium Z")]
        PsychiumZBag = 948,
        [Description("Buginium Z")]
        BuginiumZBag = 949,
        [Description("Rockium Z")]
        RockiumZBag = 950,
        [Description("Ghostium Z")]
        GhostiumZBag = 951,
        [Description("Dragonium Z")]
        DragoniumZBag = 952,
        [Description("Darkinium Z")]
        DarkiniumZBag = 953,
        [Description("Steelium Z")]
        SteeliumZBag = 954,
        [Description("Fairium Z")]
        FairiumZBag = 955,
        [Description("Pikanium Z")]
        PikaniumZBag = 956,
        [Description("Decidium Z")]
        DecidiumZBag = 957,
        [Description("Incinium Z")]
        InciniumZBag = 958,
        [Description("Primarium Z")]
        PrimariumZBag = 959,
        [Description("Tapunium Z")]
        TapuniumZBag = 960,
        [Description("Marshadium Z")]
        MarshadiumZBag = 961,
        [Description("Aloraichium Z")]
        AloraichiumZBag = 962,
        [Description("Snorlium Z")]
        SnorliumZBag = 963,
        [Description("Eevium Z")]
        EeviumZBag = 964,
        [Description("Mewnium Z")]
        MewniumZBag = 965,
        [Description("Pikashunium Z")]
        PikashuniumZBag = 966,
        [Description("Solganium Z")]
        SolganiumZHeld = 967,
        [Description("Lunalium Z")]
        LunaliumZHeld = 968,
        [Description("Ultranecrozium Z")]
        UltranecroziumZHeld = 969,
        [Description("Mimikium Z")]
        MimikiumZHeld = 970,
        [Description("Lycanium Z")]
        LycaniumZHeld = 971,
        [Description("Kommonium Z")]
        KommoniumZHeld = 972,
        [Description("Solganium Z")]
        SolganiumZBag = 973,
        [Description("Lunalium Z")]
        LunaliumZBag = 974,
        [Description("Ultranecrozium Z")]
        UltranecroziumZBag = 975,
        [Description("Mimikium Z")]
        MimikiumZBag = 976,
        [Description("Lycanium Z")]
        LycaniumZBag = 977,
        [Description("Kommonium Z")]
        KommoniumZBag = 978,
        [Description("Z-Power Ring")]
        ZPowerRing = 979,
        [Description("Pink Petal")]
        PinkPetal = 980,
        [Description("Orange Petal")]
        OrangePetal = 981,
        [Description("Blue Petal")]
        BluePetal = 982,
        [Description("Red Petal")]
        RedPetal = 983,
        [Description("Green Petal")]
        GreenPetal = 984,
        [Description("Yellow Petal")]
        YellowPetal = 985,
        [Description("Purple Petal")]
        PurplePetal = 986,
        [Description("Rainbow Flower")]
        RainbowFlower = 987,
        [Description("Surge Badge")]
        SurgeBadge = 988,
        [Description("N-Solarizer")]
        NSolarizerMerge = 989,
        [Description("N-Lunarizer")]
        NLunarizerMerge = 990,
        [Description("N-Solarizer")]
        NSolarizerSplit = 991,
        [Description("N-Lunarizer")]
        NLunarizerSplit = 992,
        [Description("Ilima Normalium Z")]
        IlimasNormaliumZ = 993,
        [Description("Left Poké Ball")]
        LeftPokeBall = 994,
        [Description("Roto Hatch")]
        RotoHatch = 995,
        [Description("Roto Bargain")]
        RotoBargain = 996,
        [Description("Roto Prize Money")]
        RotoPrizeMoney = 997,
        [Description("Roto Exp. Points")]
        RotoExpPoints = 998,
        [Description("Roto Friendship")]
        RotoFriendship = 999,
        [Description("Roto Encounter")]
        RotoEncounter = 1000,
        [Description("Roto Stealth")]
        RotoStealth = 1001,
        [Description("Roto HP Restore")]
        RotoHpRestore = 1002,
        [Description("Roto PP Restore")]
        RotoPpRestore = 1003,
        [Description("Roto Boost")]
        RotoBoost = 1004,
        [Description("Roto Catch")]
        RotoCatch = 1005,
        [Description("Autograph")]
        Autograph = 1006,
        [Description("Pokémon Box Link")]
        PokemonBox = 1007,
        [Description("Medicine Pocket")]
        MedicinePocket = 1008,
        [Description("Candy Jar")]
        CandyJar = 1009,
        [Description("Power-Up Pocket")]
        PowerUpPocket = 1010,
        [Description("Clothing Trunk")]
        ClothingTrunk = 1011,
        [Description("Catching Pocket")]
        CatchingPocket = 1012,
        [Description("Battle Pocket")]
        BattlePocket = 1013,
        [Description("Silver Razz Berry")]
        SilverRazzBerry = 1014,
        [Description("Golden Razz Berry")]
        GoldenRazzBerry = 1015,
        [Description("Silver Nanab Berry")]
        SilverNanabBerry = 1016,
        [Description("Golden Nanab Berry")]
        GoldenNanabBerry = 1017,
        [Description("Silver Pinap Berry")]
        SilverPinapBerry = 1018,
        [Description("Golden Pinap Berry")]
        GoldenPinapBerry = 1019,
        [Description("Secret Key")]
        SecretKeyLetsgo = 1020,
        [Description("S.S. Ticket")]
        SsTicketLetsgo = 1021,
        [Description("Parcel")]
        ParcelLetsgo = 1022,
        [Description("Card Key")]
        CardKeyLetsgo = 1023,
        [Description("Stretchy Spring")]
        StretchySpring = 1024,
        [Description("Chalky Stone")]
        ChalkyStone = 1025,
        [Description("Marble")]
        Marble = 1026,
        [Description("Lone Earring")]
        LoneEarring = 1027,
        [Description("Beach Glass")]
        BeachGlass = 1028,
        [Description("Gold Leaf")]
        GoldLeaf = 1029,
        [Description("Silver Leaf")]
        SilverLeaf = 1030,
        [Description("Polished Mud Ball")]
        PolishedMudBall = 1031,
        [Description("Tropical Shell")]
        TropicalShell = 1032,
        [Description("Leaf Letter")]
        LeafLetterPikachu = 1033,
        [Description("Leaf Letter")]
        LeafLetterEevee = 1034,
        [Description("Small Bouquet")]
        SmallBouquet = 1035,
        [Description("Lure")]
        Lure = 1036,
        [Description("Super Lure")]
        SuperLure = 1037,
        [Description("Max Lure")]
        MaxLure = 1038,
        [Description("Pewter Crunchies")]
        PewterCrunchies = 1039,
        [Description("Health Candy")]
        HealthCandy = 1040,
        [Description("Mighty Candy")]
        MightyCandy = 1041,
        [Description("Tough Candy")]
        ToughCandy = 1042,
        [Description("Smart Candy")]
        SmartCandy = 1043,
        [Description("Courage Candy")]
        CourageCandy = 1044,
        [Description("Quick Candy")]
        QuickCandy = 1045,
        [Description("Health Candy L")]
        HealthCandyL = 1046,
        [Description("Mighty Candy L")]
        MightyCandyL = 1047,
        [Description("Tough Candy L")]
        ToughCandyL = 1048,
        [Description("Smart Candy L")]
        SmartCandyL = 1049,
        [Description("Courage Candy L")]
        CourageCandyL = 1050,
        [Description("Quick Candy L")]
        QuickCandyL = 1051,
        [Description("Health Candy XL")]
        HealthCandyXl = 1052,
        [Description("Mighty Candy XL")]
        MightyCandyXl = 1053,
        [Description("Tough Candy XL")]
        ToughCandyXl = 1054,
        [Description("Smart Candy XL")]
        SmartCandyXl = 1055,
        [Description("Courage Candy XL")]
        CourageCandyXl = 1056,
        [Description("Quick Candy XL")]
        QuickCandyXl = 1057,
        [Description("Bulbasaur Candy")]
        BulbasaurCandy = 1058,
        [Description("Charmander Candy")]
        CharmanderCandy = 1059,
        [Description("Squirtle Candy")]
        SquirtleCandy = 1060,
        [Description("Caterpie Candy")]
        CaterpieCandy = 1061,
        [Description("Weedle Candy")]
        WeedleCandy = 1062,
        [Description("Pidgey Candy")]
        PidgeyCandy = 1063,
        [Description("Rattata Candy")]
        RattataCandy = 1064,
        [Description("Spearow Candy")]
        SpearowCandy = 1065,
        [Description("Ekans Candy")]
        EkansCandy = 1066,
        [Description("Pikachu Candy")]
        PikachuCandy = 1067,
        [Description("Sandshrew Candy")]
        SandshrewCandy = 1068,
        [Description("Nidoran♀ Candy")]
        NidoranFCandy = 1069,
        [Description("Nidoran♂ Candy")]
        NidoranMCandy = 1070,
        [Description("Clefairy Candy")]
        ClefairyCandy = 1071,
        [Description("Vulpix Candy")]
        VulpixCandy = 1072,
        [Description("Jigglypuff Candy")]
        JigglypuffCandy = 1073,
        [Description("Zubat Candy")]
        ZubatCandy = 1074,
        [Description("Oddish Candy")]
        OddishCandy = 1075,
        [Description("Paras Candy")]
        ParasCandy = 1076,
        [Description("Venonat Candy")]
        VenonatCandy = 1077,
        [Description("Diglett Candy")]
        DiglettCandy = 1078,
        [Description("Meowth Candy")]
        MeowthCandy = 1079,
        [Description("Psyduck Candy")]
        PsyduckCandy = 1080,
        [Description("Mankey Candy")]
        MankeyCandy = 1081,
        [Description("Growlithe Candy")]
        GrowlitheCandy = 1082,
        [Description("Poliwag Candy")]
        PoliwagCandy = 1083,
        [Description("Abra Candy")]
        AbraCandy = 1084,
        [Description("Machop Candy")]
        MachopCandy = 1085,
        [Description("Bellsprout Candy")]
        BellsproutCandy = 1086,
        [Description("Tentacool Candy")]
        TentacoolCandy = 1087,
        [Description("Geodude Candy")]
        GeodudeCandy = 1088,
        [Description("Ponyta Candy")]
        PonytaCandy = 1089,
        [Description("Slowpoke Candy")]
        SlowpokeCandy = 1090,
        [Description("Magnemite Candy")]
        MagnemiteCandy = 1091,
        [Description("Farfetch’d Candy")]
        FarfetchdCandy = 1092,
        [Description("Doduo Candy")]
        DoduoCandy = 1093,
        [Description("Seel Candy")]
        SeelCandy = 1094,
        [Description("Grimer Candy")]
        GrimerCandy = 1095,
        [Description("Shellder Candy")]
        ShellderCandy = 1096,
        [Description("Gastly Candy")]
        GastlyCandy = 1097,
        [Description("Onix Candy")]
        OnixCandy = 1098,
        [Description("Drowzee Candy")]
        DrowzeeCandy = 1099,
        [Description("Krabby Candy")]
        KrabbyCandy = 1100,
        [Description("Voltorb Candy")]
        VoltorbCandy = 1101,
        [Description("Exeggcute Candy")]
        ExeggcuteCandy = 1102,
        [Description("Cubone Candy")]
        CuboneCandy = 1103,
        [Description("Hitmonlee Candy")]
        HitmonleeCandy = 1104,
        [Description("Hitmonchan Candy")]
        HitmonchanCandy = 1105,
        [Description("Lickitung Candy")]
        LickitungCandy = 1106,
        [Description("Koffing Candy")]
        KoffingCandy = 1107,
        [Description("Rhyhorn Candy")]
        RhyhornCandy = 1108,
        [Description("Chansey Candy")]
        ChanseyCandy = 1109,
        [Description("Tangela Candy")]
        TangelaCandy = 1110,
        [Description("Kangaskhan Candy")]
        KangaskhanCandy = 1111,
        [Description("Horsea Candy")]
        HorseaCandy = 1112,
        [Description("Goldeen Candy")]
        GoldeenCandy = 1113,
        [Description("Staryu Candy")]
        StaryuCandy = 1114,
        [Description("Mr. Mime Candy")]
        MrMimeCandy = 1115,
        [Description("Scyther Candy")]
        ScytherCandy = 1116,
        [Description("Jynx Candy")]
        JynxCandy = 1117,
        [Description("Electabuzz Candy")]
        ElectabuzzCandy = 1118,
        [Description("Pinsir Candy")]
        PinsirCandy = 1119,
        [Description("Tauros Candy")]
        TaurosCandy = 1120,
        [Description("Magikarp Candy")]
        MagikarpCandy = 1121,
        [Description("Lapras Candy")]
        LaprasCandy = 1122,
        [Description("Ditto Candy")]
        DittoCandy = 1123,
        [Description("Eevee Candy")]
        EeveeCandy = 1124,
        [Description("Porygon Candy")]
        PorygonCandy = 1125,
        [Description("Omanyte Candy")]
        OmanyteCandy = 1126,
        [Description("Kabuto Candy")]
        KabutoCandy = 1127,
        [Description("Aerodactyl Candy")]
        AerodactylCandy = 1128,
        [Description("Snorlax Candy")]
        SnorlaxCandy = 1129,
        [Description("Articuno Candy")]
        ArticunoCandy = 1130,
        [Description("Zapdos Candy")]
        ZapdosCandy = 1131,
        [Description("Moltres Candy")]
        MoltresCandy = 1132,
        [Description("Dratini Candy")]
        DratiniCandy = 1133,
        [Description("Mewtwo Candy")]
        MewtwoCandy = 1134,
        [Description("Mew Candy")]
        MewCandy = 1135,
        [Description("Meltan Candy")]
        MeltanCandy = 1136,
        [Description("Magmar Candy")]
        MagmarCandy = 1137,
        [Description("Endorsement")]
        Endorsement = 1138,
        [Description("Pokémon Box Link")]
        PokemonBoxLink = 1139,
        [Description("Wishing Star")]
        WishingStar = 1140,
        [Description("Dynamax Band")]
        DynamaxBand = 1141,
        [Description("Fishing Rod")]
        FishingRodGalar = 1142,
        [Description("Rotom Bike")]
        RotomBike = 1143,
        [Description("Sausages")]
        Sausages = 1144,
        [Description("Bob’s Food Tin")]
        BobsFoodTin = 1145,
        [Description("Bach’s Food Tin")]
        BachsFoodTin = 1146,
        [Description("Tin of Beans")]
        TinOfBeans = 1147,
        [Description("Bread")]
        Bread = 1148,
        [Description("Pasta")]
        Pasta = 1149,
        [Description("Mixed Mushrooms")]
        MixedMushrooms = 1150,
        [Description("Smoke-Poke Tail")]
        SmokePokeTail = 1151,
        [Description("Large Leek")]
        LargeLeek = 1152,
        [Description("Fancy Apple")]
        FancyApple = 1153,
        [Description("Brittle Bones")]
        BrittleBones = 1154,
        [Description("Pack of Potatoes")]
        PackOfPotatoes = 1155,
        [Description("Pungent Root")]
        PungentRoot = 1156,
        [Description("Salad Mix")]
        SaladMix = 1157,
        [Description("Fried Food")]
        FriedFood = 1158,
        [Description("Boiled Egg")]
        BoiledEgg = 1159,
        [Description("Camping Gear")]
        CampingGear = 1160,
        [Description("Rusted Sword")]
        RustedSword = 1161,
        [Description("Rusted Shield")]
        RustedShield = 1162,
        [Description("Fossilized Bird")]
        FossilizedBird = 1163,
        [Description("Fossilized Fish")]
        FossilizedFish = 1164,
        [Description("Fossilized Drake")]
        FossilizedDrake = 1165,
        [Description("Fossilized Dino")]
        FossilizedDino = 1166,
        [Description("Strawberry Sweet")]
        StrawberrySweet = 1167,
        [Description("Love Sweet")]
        LoveSweet = 1168,
        [Description("Berry Sweet")]
        BerrySweet = 1169,
        [Description("Clover Sweet")]
        CloverSweet = 1170,
        [Description("Flower Sweet")]
        FlowerSweet = 1171,
        [Description("Star Sweet")]
        StarSweet = 1172,
        [Description("Ribbon Sweet")]
        RibbonSweet = 1173,
        [Description("Sweet Apple")]
        SweetApple = 1174,
        [Description("Tart Apple")]
        TartApple = 1175,
        [Description("Throat Spray")]
        ThroatSpray = 1176,
        [Description("Eject Pack")]
        EjectPack = 1177,
        [Description("Heavy-Duty Boots")]
        HeavyDutyBoots = 1178,
        [Description("Blunder Policy")]
        BlunderPolicy = 1179,
        [Description("Room Service")]
        RoomService = 1180,
        [Description("Utility Umbrella")]
        UtilityUmbrella = 1181,
        [Description("Exp. Candy XS")]
        ExpCandyXs = 1182,
        [Description("Exp. Candy S")]
        ExpCandyS = 1183,
        [Description("Exp. Candy M")]
        ExpCandyM = 1184,
        [Description("Exp. Candy L")]
        ExpCandyL = 1185,
        [Description("Exp. Candy XL")]
        ExpCandyXl = 1186,
        [Description("Dynamax Candy")]
        DynamaxCandy = 1187,
        [Description("TR00")]
        Tr00 = 1188,
        [Description("TR01")]
        Tr01 = 1189,
        [Description("TR02")]
        Tr02 = 1190,
        [Description("TR03")]
        Tr03 = 1191,
        [Description("TR04")]
        Tr04 = 1192,
        [Description("TR05")]
        Tr05 = 1193,
        [Description("TR06")]
        Tr06 = 1194,
        [Description("TR07")]
        Tr07 = 1195,
        [Description("TR08")]
        Tr08 = 1196,
        [Description("TR09")]
        Tr09 = 1197,
        [Description("TR10")]
        Tr10 = 1198,
        [Description("TR11")]
        Tr11 = 1199,
        [Description("TR12")]
        Tr12 = 1200,
        [Description("TR13")]
        Tr13 = 1201,
        [Description("TR14")]
        Tr14 = 1202,
        [Description("TR15")]
        Tr15 = 1203,
        [Description("TR16")]
        Tr16 = 1204,
        [Description("TR17")]
        Tr17 = 1205,
        [Description("TR18")]
        Tr18 = 1206,
        [Description("TR19")]
        Tr19 = 1207,
        [Description("TR20")]
        Tr20 = 1208,
        [Description("TR21")]
        Tr21 = 1209,
        [Description("TR22")]
        Tr22 = 1210,
        [Description("TR23")]
        Tr23 = 1211,
        [Description("TR24")]
        Tr24 = 1212,
        [Description("TR25")]
        Tr25 = 1213,
        [Description("TR26")]
        Tr26 = 1214,
        [Description("TR27")]
        Tr27 = 1215,
        [Description("TR28")]
        Tr28 = 1216,
        [Description("TR29")]
        Tr29 = 1217,
        [Description("TR30")]
        Tr30 = 1218,
        [Description("TR31")]
        Tr31 = 1219,
        [Description("TR32")]
        Tr32 = 1220,
        [Description("TR33")]
        Tr33 = 1221,
        [Description("TR34")]
        Tr34 = 1222,
        [Description("TR35")]
        Tr35 = 1223,
        [Description("TR36")]
        Tr36 = 1224,
        [Description("TR37")]
        Tr37 = 1225,
        [Description("TR38")]
        Tr38 = 1226,
        [Description("TR39")]
        Tr39 = 1227,
        [Description("TR40")]
        Tr40 = 1228,
        [Description("TR41")]
        Tr41 = 1229,
        [Description("TR42")]
        Tr42 = 1230,
        [Description("TR43")]
        Tr43 = 1231,
        [Description("TR44")]
        Tr44 = 1232,
        [Description("TR45")]
        Tr45 = 1233,
        [Description("TR46")]
        Tr46 = 1234,
        [Description("TR47")]
        Tr47 = 1235,
        [Description("TR48")]
        Tr48 = 1236,
        [Description("TR49")]
        Tr49 = 1237,
        [Description("TR50")]
        Tr50 = 1238,
        [Description("TR51")]
        Tr51 = 1239,
        [Description("TR52")]
        Tr52 = 1240,
        [Description("TR53")]
        Tr53 = 1241,
        [Description("TR54")]
        Tr54 = 1242,
        [Description("TR55")]
        Tr55 = 1243,
        [Description("TR56")]
        Tr56 = 1244,
        [Description("TR57")]
        Tr57 = 1245,
        [Description("TR58")]
        Tr58 = 1246,
        [Description("TR59")]
        Tr59 = 1247,
        [Description("TR60")]
        Tr60 = 1248,
        [Description("TR61")]
        Tr61 = 1249,
        [Description("TR62")]
        Tr62 = 1250,
        [Description("TR63")]
        Tr63 = 1251,
        [Description("TR64")]
        Tr64 = 1252,
        [Description("TR65")]
        Tr65 = 1253,
        [Description("TR66")]
        Tr66 = 1254,
        [Description("TR67")]
        Tr67 = 1255,
        [Description("TR68")]
        Tr68 = 1256,
        [Description("TR69")]
        Tr69 = 1257,
        [Description("TR70")]
        Tr70 = 1258,
        [Description("TR71")]
        Tr71 = 1259,
        [Description("TR72")]
        Tr72 = 1260,
        [Description("TR73")]
        Tr73 = 1261,
        [Description("TR74")]
        Tr74 = 1262,
        [Description("TR75")]
        Tr75 = 1263,
        [Description("TR76")]
        Tr76 = 1264,
        [Description("TR77")]
        Tr77 = 1265,
        [Description("TR78")]
        Tr78 = 1266,
        [Description("TR79")]
        Tr79 = 1267,
        [Description("TR80")]
        Tr80 = 1268,
        [Description("TR81")]
        Tr81 = 1269,
        [Description("TR82")]
        Tr82 = 1270,
        [Description("TR83")]
        Tr83 = 1271,
        [Description("TR84")]
        Tr84 = 1272,
        [Description("TR85")]
        Tr85 = 1273,
        [Description("TR86")]
        Tr86 = 1274,
        [Description("TR87")]
        Tr87 = 1275,
        [Description("TR88")]
        Tr88 = 1276,
        [Description("TR89")]
        Tr89 = 1277,
        [Description("TR90")]
        Tr90 = 1278,
        [Description("TR91")]
        Tr91 = 1279,
        [Description("TR92")]
        Tr92 = 1280,
        [Description("TR93")]
        Tr93 = 1281,
        [Description("TR94")]
        Tr94 = 1282,
        [Description("TR95")]
        Tr95 = 1283,
        [Description("TR96")]
        Tr96 = 1284,
        [Description("TR97")]
        Tr97 = 1285,
        [Description("TR98")]
        Tr98 = 1286,
        [Description("TR99")]
        Tr99 = 1287,
        [Description("TM00")]
        Tm00 = 1288,
        [Description("Lonely Mint")]
        LonelyMint = 1289,
        [Description("Adamant Mint")]
        AdamantMint = 1290,
        [Description("Naughty Mint")]
        NaughtyMint = 1291,
        [Description("Brave Mint")]
        BraveMint = 1292,
        [Description("Bold Mint")]
        BoldMint = 1293,
        [Description("Impish Mint")]
        ImpishMint = 1294,
        [Description("Lax Mint")]
        LaxMint = 1295,
        [Description("Relaxed Mint")]
        RelaxedMint = 1296,
        [Description("Modest Mint")]
        ModestMint = 1297,
        [Description("Mild Mint")]
        MildMint = 1298,
        [Description("Rash Mint")]
        RashMint = 1299,
        [Description("Quiet Mint")]
        QuietMint = 1300,
        [Description("Calm Mint")]
        CalmMint = 1301,
        [Description("Gentle Mint")]
        GentleMint = 1302,
        [Description("Careful Mint")]
        CarefulMint = 1303,
        [Description("Sassy Mint")]
        SassyMint = 1304,
        [Description("Timid Mint")]
        TimidMint = 1305,
        [Description("Hasty Mint")]
        HastyMint = 1306,
        [Description("Jolly Mint")]
        JollyMint = 1307,
        [Description("Naive Mint")]
        NaiveMint = 1308,
        [Description("Serious Mint")]
        SeriousMint = 1309,
        [Description("Wishing Piece")]
        WishingPiece = 1310,
        [Description("Cracked Pot")]
        CrackedPot = 1311,
        [Description("Chipped Pot")]
        ChippedPot = 1312,
        [Description("Hi-tech Earbuds")]
        HiTechEarbuds = 1313,
        [Description("Fruit Bunch")]
        FruitBunch = 1314,
        [Description("Moomoo Cheese")]
        MoomooCheese = 1315,
        [Description("Spice Mix")]
        SpiceMix = 1316,
        [Description("Fresh Cream")]
        FreshCream = 1317,
        [Description("Packaged Curry")]
        PackagedCurry = 1318,
        [Description("Coconut Milk")]
        CoconutMilk = 1319,
        [Description("Instant Noodles")]
        InstantNoodles = 1320,
        [Description("Precooked Burger")]
        PrecookedBurger = 1321,
        [Description("Gigantamix")]
        Gigantamix = 1322,
        [Description("Wishing Chip")]
        WishingChip = 1323,
        [Description("Rotom Bike")]
        RotomBikeWaterMode = 1324,
        [Description("Catching Charm")]
        CatchingCharm = 1325,
        [Description("Old Letter")]
        OldLetter = 1326,
        [Description("Band Autograph")]
        BandAutograph = 1327,
        [Description("Sonia’s Book")]
        SoniasBook = 1328,
        [Description("Rotom Catalog")]
        RotomCatalog = 1329,
        [Description("★And458")]
        DynamaxCrystalAnd458 = 1330,
        [Description("★And15")]
        DynamaxCrystalAnd15 = 1331,
        [Description("★And337")]
        DynamaxCrystalAnd337 = 1332,
        [Description("★And603")]
        DynamaxCrystalAnd603 = 1333,
        [Description("★And390")]
        DynamaxCrystalAnd390 = 1334,
        [Description("★Sgr6879")]
        DynamaxCrystalSgr6879 = 1335,
        [Description("★Sgr6859")]
        DynamaxCrystalSgr6859 = 1336,
        [Description("★Sgr6913")]
        DynamaxCrystalSgr6913 = 1337,
        [Description("★Sgr7348")]
        DynamaxCrystalSgr7348 = 1338,
        [Description("★Sgr7121")]
        DynamaxCrystalSgr7121 = 1339,
        [Description("★Sgr6746")]
        DynamaxCrystalSgr6746 = 1340,
        [Description("★Sgr7194")]
        DynamaxCrystalSgr7194 = 1341,
        [Description("★Sgr7337")]
        DynamaxCrystalSgr7337 = 1342,
        [Description("★Sgr7343")]
        DynamaxCrystalSgr7343 = 1343,
        [Description("★Sgr6812")]
        DynamaxCrystalSgr6812 = 1344,
        [Description("★Sgr7116")]
        DynamaxCrystalSgr7116 = 1345,
        [Description("★Sgr7264")]
        DynamaxCrystalSgr7264 = 1346,
        [Description("★Sgr7597")]
        DynamaxCrystalSgr7597 = 1347,
        [Description("★Del7882")]
        DynamaxCrystalDel7882 = 1348,
        [Description("★Del7906")]
        DynamaxCrystalDel7906 = 1349,
        [Description("★Del7852")]
        DynamaxCrystalDel7852 = 1350,
        [Description("★Psc596")]
        DynamaxCrystalPsc596 = 1351,
        [Description("★Psc361")]
        DynamaxCrystalPsc361 = 1352,
        [Description("★Psc510")]
        DynamaxCrystalPsc510 = 1353,
        [Description("★Psc437")]
        DynamaxCrystalPsc437 = 1354,
        [Description("★Psc8773")]
        DynamaxCrystalPsc8773 = 1355,
        [Description("★Lep1865")]
        DynamaxCrystalLep1865 = 1356,
        [Description("★Lep1829")]
        DynamaxCrystalLep1829 = 1357,
        [Description("★Boo5340")]
        DynamaxCrystalBoo5340 = 1358,
        [Description("★Boo5506")]
        DynamaxCrystalBoo5506 = 1359,
        [Description("★Boo5435")]
        DynamaxCrystalBoo5435 = 1360,
        [Description("★Boo5602")]
        DynamaxCrystalBoo5602 = 1361,
        [Description("★Boo5733")]
        DynamaxCrystalBoo5733 = 1362,
        [Description("★Boo5235")]
        DynamaxCrystalBoo5235 = 1363,
        [Description("★Boo5351")]
        DynamaxCrystalBoo5351 = 1364,
        [Description("★Hya3748")]
        DynamaxCrystalHya3748 = 1365,
        [Description("★Hya3903")]
        DynamaxCrystalHya3903 = 1366,
        [Description("★Hya3418")]
        DynamaxCrystalHya3418 = 1367,
        [Description("★Hya3482")]
        DynamaxCrystalHya3482 = 1368,
        [Description("★Hya3845")]
        DynamaxCrystalHya3845 = 1369,
        [Description("★Eri1084")]
        DynamaxCrystalEri1084 = 1370,
        [Description("★Eri472")]
        DynamaxCrystalEri472 = 1371,
        [Description("★Eri1666")]
        DynamaxCrystalEri1666 = 1372,
        [Description("★Eri897")]
        DynamaxCrystalEri897 = 1373,
        [Description("★Eri1231")]
        DynamaxCrystalEri1231 = 1374,
        [Description("★Eri874")]
        DynamaxCrystalEri874 = 1375,
        [Description("★Eri1298")]
        DynamaxCrystalEri1298 = 1376,
        [Description("★Eri1325")]
        DynamaxCrystalEri1325 = 1377,
        [Description("★Eri984")]
        DynamaxCrystalEri984 = 1378,
        [Description("★Eri1464")]
        DynamaxCrystalEri1464 = 1379,
        [Description("★Eri1393")]
        DynamaxCrystalEri1393 = 1380,
        [Description("★Eri850")]
        DynamaxCrystalEri850 = 1381,
        [Description("★Tau1409")]
        DynamaxCrystalTau1409 = 1382,
        [Description("★Tau1457")]
        DynamaxCrystalTau1457 = 1383,
        [Description("★Tau1165")]
        DynamaxCrystalTau1165 = 1384,
        [Description("★Tau1791")]
        DynamaxCrystalTau1791 = 1385,
        [Description("★Tau1910")]
        DynamaxCrystalTau1910 = 1386,
        [Description("★Tau1346")]
        DynamaxCrystalTau1346 = 1387,
        [Description("★Tau1373")]
        DynamaxCrystalTau1373 = 1388,
        [Description("★Tau1412")]
        DynamaxCrystalTau1412 = 1389,
        [Description("★CMa2491")]
        DynamaxCrystalCma2491 = 1390,
        [Description("★CMa2693")]
        DynamaxCrystalCma2693 = 1391,
        [Description("★CMa2294")]
        DynamaxCrystalCma2294 = 1392,
        [Description("★CMa2827")]
        DynamaxCrystalCma2827 = 1393,
        [Description("★CMa2282")]
        DynamaxCrystalCma2282 = 1394,
        [Description("★CMa2618")]
        DynamaxCrystalCma2618 = 1395,
        [Description("★CMa2657")]
        DynamaxCrystalCma2657 = 1396,
        [Description("★CMa2646")]
        DynamaxCrystalCma2646 = 1397,
        [Description("★UMa4905")]
        DynamaxCrystalUma4905 = 1398,
        [Description("★UMa4301")]
        DynamaxCrystalUma4301 = 1399,
        [Description("★UMa5191")]
        DynamaxCrystalUma5191 = 1400,
        [Description("★UMa5054")]
        DynamaxCrystalUma5054 = 1401,
        [Description("★UMa4295")]
        DynamaxCrystalUma4295 = 1402,
        [Description("★UMa4660")]
        DynamaxCrystalUma4660 = 1403,
        [Description("★UMa4554")]
        DynamaxCrystalUma4554 = 1404,
        [Description("★UMa4069")]
        DynamaxCrystalUma4069 = 1405,
        [Description("★UMa3569")]
        DynamaxCrystalUma3569 = 1406,
        [Description("★UMa3323")]
        DynamaxCrystalUma3323 = 1407,
        [Description("★UMa4033")]
        DynamaxCrystalUma4033 = 1408,
        [Description("★UMa4377")]
        DynamaxCrystalUma4377 = 1409,
        [Description("★UMa4375")]
        DynamaxCrystalUma4375 = 1410,
        [Description("★UMa4518")]
        DynamaxCrystalUma4518 = 1411,
        [Description("★UMa3594")]
        DynamaxCrystalUma3594 = 1412,
        [Description("★Vir5056")]
        DynamaxCrystalVir5056 = 1413,
        [Description("★Vir4825")]
        DynamaxCrystalVir4825 = 1414,
        [Description("★Vir4932")]
        DynamaxCrystalVir4932 = 1415,
        [Description("★Vir4540")]
        DynamaxCrystalVir4540 = 1416,
        [Description("★Vir4689")]
        DynamaxCrystalVir4689 = 1417,
        [Description("★Vir5338")]
        DynamaxCrystalVir5338 = 1418,
        [Description("★Vir4910")]
        DynamaxCrystalVir4910 = 1419,
        [Description("★Vir5315")]
        DynamaxCrystalVir5315 = 1420,
        [Description("★Vir5359")]
        DynamaxCrystalVir5359 = 1421,
        [Description("★Vir5409")]
        DynamaxCrystalVir5409 = 1422,
        [Description("★Vir5107")]
        DynamaxCrystalVir5107 = 1423,
        [Description("★Ari617")]
        DynamaxCrystalAri617 = 1424,
        [Description("★Ari553")]
        DynamaxCrystalAri553 = 1425,
        [Description("★Ari546")]
        DynamaxCrystalAri546 = 1426,
        [Description("★Ari951")]
        DynamaxCrystalAri951 = 1427,
        [Description("★Ori1713")]
        DynamaxCrystalOri1713 = 1428,
        [Description("★Ori2061")]
        DynamaxCrystalOri2061 = 1429,
        [Description("★Ori1790")]
        DynamaxCrystalOri1790 = 1430,
        [Description("★Ori1903")]
        DynamaxCrystalOri1903 = 1431,
        [Description("★Ori1948")]
        DynamaxCrystalOri1948 = 1432,
        [Description("★Ori2004")]
        DynamaxCrystalOri2004 = 1433,
        [Description("★Ori1852")]
        DynamaxCrystalOri1852 = 1434,
        [Description("★Ori1879")]
        DynamaxCrystalOri1879 = 1435,
        [Description("★Ori1899")]
        DynamaxCrystalOri1899 = 1436,
        [Description("★Ori1543")]
        DynamaxCrystalOri1543 = 1437,
        [Description("★Cas21")]
        DynamaxCrystalCas21 = 1438,
        [Description("★Cas168")]
        DynamaxCrystalCas168 = 1439,
        [Description("★Cas403")]
        DynamaxCrystalCas403 = 1440,
        [Description("★Cas153")]
        DynamaxCrystalCas153 = 1441,
        [Description("★Cas542")]
        DynamaxCrystalCas542 = 1442,
        [Description("★Cas219")]
        DynamaxCrystalCas219 = 1443,
        [Description("★Cas265")]
        DynamaxCrystalCas265 = 1444,
        [Description("★Cnc3572")]
        DynamaxCrystalCnc3572 = 1445,
        [Description("★Cnc3208")]
        DynamaxCrystalCnc3208 = 1446,
        [Description("★Cnc3461")]
        DynamaxCrystalCnc3461 = 1447,
        [Description("★Cnc3449")]
        DynamaxCrystalCnc3449 = 1448,
        [Description("★Cnc3429")]
        DynamaxCrystalCnc3429 = 1449,
        [Description("★Cnc3627")]
        DynamaxCrystalCnc3627 = 1450,
        [Description("★Cnc3268")]
        DynamaxCrystalCnc3268 = 1451,
        [Description("★Cnc3249")]
        DynamaxCrystalCnc3249 = 1452,
        [Description("★Com4968")]
        DynamaxCrystalCom4968 = 1453,
        [Description("★Crv4757")]
        DynamaxCrystalCrv4757 = 1454,
        [Description("★Crv4623")]
        DynamaxCrystalCrv4623 = 1455,
        [Description("★Crv4662")]
        DynamaxCrystalCrv4662 = 1456,
        [Description("★Crv4786")]
        DynamaxCrystalCrv4786 = 1457,
        [Description("★Aur1708")]
        DynamaxCrystalAur1708 = 1458,
        [Description("★Aur2088")]
        DynamaxCrystalAur2088 = 1459,
        [Description("★Aur1605")]
        DynamaxCrystalAur1605 = 1460,
        [Description("★Aur2095")]
        DynamaxCrystalAur2095 = 1461,
        [Description("★Aur1577")]
        DynamaxCrystalAur1577 = 1462,
        [Description("★Aur1641")]
        DynamaxCrystalAur1641 = 1463,
        [Description("★Aur1612")]
        DynamaxCrystalAur1612 = 1464,
        [Description("★Pav7790")]
        DynamaxCrystalPav7790 = 1465,
        [Description("★Cet911")]
        DynamaxCrystalCet911 = 1466,
        [Description("★Cet681")]
        DynamaxCrystalCet681 = 1467,
        [Description("★Cet188")]
        DynamaxCrystalCet188 = 1468,
        [Description("★Cet539")]
        DynamaxCrystalCet539 = 1469,
        [Description("★Cet804")]
        DynamaxCrystalCet804 = 1470,
        [Description("★Cep8974")]
        DynamaxCrystalCep8974 = 1471,
        [Description("★Cep8162")]
        DynamaxCrystalCep8162 = 1472,
        [Description("★Cep8238")]
        DynamaxCrystalCep8238 = 1473,
        [Description("★Cep8417")]
        DynamaxCrystalCep8417 = 1474,
        [Description("★Cen5267")]
        DynamaxCrystalCen5267 = 1475,
        [Description("★Cen5288")]
        DynamaxCrystalCen5288 = 1476,
        [Description("★Cen551")]
        DynamaxCrystalCen551 = 1477,
        [Description("★Cen5459")]
        DynamaxCrystalCen5459 = 1478,
        [Description("★Cen5460")]
        DynamaxCrystalCen5460 = 1479,
        [Description("★CMi2943")]
        DynamaxCrystalCmi2943 = 1480,
        [Description("★CMi2845")]
        DynamaxCrystalCmi2845 = 1481,
        [Description("★Equ8131")]
        DynamaxCrystalEqu8131 = 1482,
        [Description("★Vul7405")]
        DynamaxCrystalVul7405 = 1483,
        [Description("★UMi424")]
        DynamaxCrystalUmi424 = 1484,
        [Description("★UMi5563")]
        DynamaxCrystalUmi5563 = 1485,
        [Description("★UMi5735")]
        DynamaxCrystalUmi5735 = 1486,
        [Description("★UMi6789")]
        DynamaxCrystalUmi6789 = 1487,
        [Description("★Crt4287")]
        DynamaxCrystalCrt4287 = 1488,
        [Description("★Lyr7001")]
        DynamaxCrystalLyr7001 = 1489,
        [Description("★Lyr7178")]
        DynamaxCrystalLyr7178 = 1490,
        [Description("★Lyr7106")]
        DynamaxCrystalLyr7106 = 1491,
        [Description("★Lyr7298")]
        DynamaxCrystalLyr7298 = 1492,
        [Description("★Ara6585")]
        DynamaxCrystalAra6585 = 1493,
        [Description("★Sco6134")]
        DynamaxCrystalSco6134 = 1494,
        [Description("★Sco6527")]
        DynamaxCrystalSco6527 = 1495,
        [Description("★Sco6553")]
        DynamaxCrystalSco6553 = 1496,
        [Description("★Sco5953")]
        DynamaxCrystalSco5953 = 1497,
        [Description("★Sco5984")]
        DynamaxCrystalSco5984 = 1498,
        [Description("★Sco6508")]
        DynamaxCrystalSco6508 = 1499,
        [Description("★Sco6084")]
        DynamaxCrystalSco6084 = 1500,
        [Description("★Sco5944")]
        DynamaxCrystalSco5944 = 1501,
        [Description("★Sco6630")]
        DynamaxCrystalSco6630 = 1502,
        [Description("★Sco6027")]
        DynamaxCrystalSco6027 = 1503,
        [Description("★Sco6247")]
        DynamaxCrystalSco6247 = 1504,
        [Description("★Sco6252")]
        DynamaxCrystalSco6252 = 1505,
        [Description("★Sco5928")]
        DynamaxCrystalSco5928 = 1506,
        [Description("★Sco6241")]
        DynamaxCrystalSco6241 = 1507,
        [Description("★Sco6165")]
        DynamaxCrystalSco6165 = 1508,
        [Description("★Tri544")]
        DynamaxCrystalTri544 = 1509,
        [Description("★Leo3982")]
        DynamaxCrystalLeo3982 = 1510,
        [Description("★Leo4534")]
        DynamaxCrystalLeo4534 = 1511,
        [Description("★Leo4357")]
        DynamaxCrystalLeo4357 = 1512,
        [Description("★Leo4057")]
        DynamaxCrystalLeo4057 = 1513,
        [Description("★Leo4359")]
        DynamaxCrystalLeo4359 = 1514,
        [Description("★Leo4031")]
        DynamaxCrystalLeo4031 = 1515,
        [Description("★Leo3852")]
        DynamaxCrystalLeo3852 = 1516,
        [Description("★Leo3905")]
        DynamaxCrystalLeo3905 = 1517,
        [Description("★Leo3773")]
        DynamaxCrystalLeo3773 = 1518,
        [Description("★Gru8425")]
        DynamaxCrystalGru8425 = 1519,
        [Description("★Gru8636")]
        DynamaxCrystalGru8636 = 1520,
        [Description("★Gru8353")]
        DynamaxCrystalGru8353 = 1521,
        [Description("★Lib5685")]
        DynamaxCrystalLib5685 = 1522,
        [Description("★Lib5531")]
        DynamaxCrystalLib5531 = 1523,
        [Description("★Lib5787")]
        DynamaxCrystalLib5787 = 1524,
        [Description("★Lib5603")]
        DynamaxCrystalLib5603 = 1525,
        [Description("★Pup3165")]
        DynamaxCrystalPup3165 = 1526,
        [Description("★Pup3185")]
        DynamaxCrystalPup3185 = 1527,
        [Description("★Pup3045")]
        DynamaxCrystalPup3045 = 1528,
        [Description("★Cyg7924")]
        DynamaxCrystalCyg7924 = 1529,
        [Description("★Cyg7417")]
        DynamaxCrystalCyg7417 = 1530,
        [Description("★Cyg7796")]
        DynamaxCrystalCyg7796 = 1531,
        [Description("★Cyg8301")]
        DynamaxCrystalCyg8301 = 1532,
        [Description("★Cyg7949")]
        DynamaxCrystalCyg7949 = 1533,
        [Description("★Cyg7528")]
        DynamaxCrystalCyg7528 = 1534,
        [Description("★Oct7228")]
        DynamaxCrystalOct7228 = 1535,
        [Description("★Col1956")]
        DynamaxCrystalCol1956 = 1536,
        [Description("★Col2040")]
        DynamaxCrystalCol2040 = 1537,
        [Description("★Col2177")]
        DynamaxCrystalCol2177 = 1538,
        [Description("★Gem2990")]
        DynamaxCrystalGem2990 = 1539,
        [Description("★Gem2891")]
        DynamaxCrystalGem2891 = 1540,
        [Description("★Gem2421")]
        DynamaxCrystalGem2421 = 1541,
        [Description("★Gem2473")]
        DynamaxCrystalGem2473 = 1542,
        [Description("★Gem2216")]
        DynamaxCrystalGem2216 = 1543,
        [Description("★Gem2777")]
        DynamaxCrystalGem2777 = 1544,
        [Description("★Gem2650")]
        DynamaxCrystalGem2650 = 1545,
        [Description("★Gem2286")]
        DynamaxCrystalGem2286 = 1546,
        [Description("★Gem2484")]
        DynamaxCrystalGem2484 = 1547,
        [Description("★Gem2930")]
        DynamaxCrystalGem2930 = 1548,
        [Description("★Peg8775")]
        DynamaxCrystalPeg8775 = 1549,
        [Description("★Peg8781")]
        DynamaxCrystalPeg8781 = 1550,
        [Description("★Peg39")]
        DynamaxCrystalPeg39 = 1551,
        [Description("★Peg8308")]
        DynamaxCrystalPeg8308 = 1552,
        [Description("★Peg8650")]
        DynamaxCrystalPeg8650 = 1553,
        [Description("★Peg8634")]
        DynamaxCrystalPeg8634 = 1554,
        [Description("★Peg8684")]
        DynamaxCrystalPeg8684 = 1555,
        [Description("★Peg8450")]
        DynamaxCrystalPeg8450 = 1556,
        [Description("★Peg8880")]
        DynamaxCrystalPeg8880 = 1557,
        [Description("★Peg8905")]
        DynamaxCrystalPeg8905 = 1558,
        [Description("★Oph6556")]
        DynamaxCrystalOph6556 = 1559,
        [Description("★Oph6378")]
        DynamaxCrystalOph6378 = 1560,
        [Description("★Oph6603")]
        DynamaxCrystalOph6603 = 1561,
        [Description("★Oph6149")]
        DynamaxCrystalOph6149 = 1562,
        [Description("★Oph6056")]
        DynamaxCrystalOph6056 = 1563,
        [Description("★Oph6075")]
        DynamaxCrystalOph6075 = 1564,
        [Description("★Ser5854")]
        DynamaxCrystalSer5854 = 1565,
        [Description("★Ser7141")]
        DynamaxCrystalSer7141 = 1566,
        [Description("★Ser5879")]
        DynamaxCrystalSer5879 = 1567,
        [Description("★Her6406")]
        DynamaxCrystalHer6406 = 1568,
        [Description("★Her6148")]
        DynamaxCrystalHer6148 = 1569,
        [Description("★Her6410")]
        DynamaxCrystalHer6410 = 1570,
        [Description("★Her6526")]
        DynamaxCrystalHer6526 = 1571,
        [Description("★Her6117")]
        DynamaxCrystalHer6117 = 1572,
        [Description("★Her6008")]
        DynamaxCrystalHer6008 = 1573,
        [Description("★Per936")]
        DynamaxCrystalPer936 = 1574,
        [Description("★Per1017")]
        DynamaxCrystalPer1017 = 1575,
        [Description("★Per1131")]
        DynamaxCrystalPer1131 = 1576,
        [Description("★Per1228")]
        DynamaxCrystalPer1228 = 1577,
        [Description("★Per834")]
        DynamaxCrystalPer834 = 1578,
        [Description("★Per941")]
        DynamaxCrystalPer941 = 1579,
        [Description("★Phe99")]
        DynamaxCrystalPhe99 = 1580,
        [Description("★Phe338")]
        DynamaxCrystalPhe338 = 1581,
        [Description("★Vel3634")]
        DynamaxCrystalVel3634 = 1582,
        [Description("★Vel3485")]
        DynamaxCrystalVel3485 = 1583,
        [Description("★Vel3734")]
        DynamaxCrystalVel3734 = 1584,
        [Description("★Aqr8232")]
        DynamaxCrystalAqr8232 = 1585,
        [Description("★Aqr8414")]
        DynamaxCrystalAqr8414 = 1586,
        [Description("★Aqr8709")]
        DynamaxCrystalAqr8709 = 1587,
        [Description("★Aqr8518")]
        DynamaxCrystalAqr8518 = 1588,
        [Description("★Aqr7950")]
        DynamaxCrystalAqr7950 = 1589,
        [Description("★Aqr8499")]
        DynamaxCrystalAqr8499 = 1590,
        [Description("★Aqr8610")]
        DynamaxCrystalAqr8610 = 1591,
        [Description("★Aqr8264")]
        DynamaxCrystalAqr8264 = 1592,
        [Description("★Cru4853")]
        DynamaxCrystalCru4853 = 1593,
        [Description("★Cru4730")]
        DynamaxCrystalCru4730 = 1594,
        [Description("★Cru4763")]
        DynamaxCrystalCru4763 = 1595,
        [Description("★Cru4700")]
        DynamaxCrystalCru4700 = 1596,
        [Description("★Cru4656")]
        DynamaxCrystalCru4656 = 1597,
        [Description("★PsA8728")]
        DynamaxCrystalPsa8728 = 1598,
        [Description("★TrA6217")]
        DynamaxCrystalTra6217 = 1599,
        [Description("★Cap7776")]
        DynamaxCrystalCap7776 = 1600,
        [Description("★Cap7754")]
        DynamaxCrystalCap7754 = 1601,
        [Description("★Cap8278")]
        DynamaxCrystalCap8278 = 1602,
        [Description("★Cap8322")]
        DynamaxCrystalCap8322 = 1603,
        [Description("★Cap7773")]
        DynamaxCrystalCap7773 = 1604,
        [Description("★Sge7479")]
        DynamaxCrystalSge7479 = 1605,
        [Description("★Car2326")]
        DynamaxCrystalCar2326 = 1606,
        [Description("★Car3685")]
        DynamaxCrystalCar3685 = 1607,
        [Description("★Car3307")]
        DynamaxCrystalCar3307 = 1608,
        [Description("★Car3699")]
        DynamaxCrystalCar3699 = 1609,
        [Description("★Dra5744")]
        DynamaxCrystalDra5744 = 1610,
        [Description("★Dra5291")]
        DynamaxCrystalDra5291 = 1611,
        [Description("★Dra6705")]
        DynamaxCrystalDra6705 = 1612,
        [Description("★Dra6536")]
        DynamaxCrystalDra6536 = 1613,
        [Description("★Dra7310")]
        DynamaxCrystalDra7310 = 1614,
        [Description("★Dra6688")]
        DynamaxCrystalDra6688 = 1615,
        [Description("★Dra4434")]
        DynamaxCrystalDra4434 = 1616,
        [Description("★Dra6370")]
        DynamaxCrystalDra6370 = 1617,
        [Description("★Dra7462")]
        DynamaxCrystalDra7462 = 1618,
        [Description("★Dra6396")]
        DynamaxCrystalDra6396 = 1619,
        [Description("★Dra6132")]
        DynamaxCrystalDra6132 = 1620,
        [Description("★Dra6636")]
        DynamaxCrystalDra6636 = 1621,
        [Description("★CVn4915")]
        DynamaxCrystalCvn4915 = 1622,
        [Description("★CVn4785")]
        DynamaxCrystalCvn4785 = 1623,
        [Description("★CVn4846")]
        DynamaxCrystalCvn4846 = 1624,
        [Description("★Aql7595")]
        DynamaxCrystalAql7595 = 1625,
        [Description("★Aql7557")]
        DynamaxCrystalAql7557 = 1626,
        [Description("★Aql7525")]
        DynamaxCrystalAql7525 = 1627,
        [Description("★Aql7602")]
        DynamaxCrystalAql7602 = 1628,
        [Description("★Aql7235")]
        DynamaxCrystalAql7235 = 1629,
        [Description("Max Honey")]
        MaxHoney = 1630,
        [Description("Max Mushrooms")]
        MaxMushrooms = 1631,
        [Description("Galarica Twig")]
        GalaricaTwig = 1632,
        [Description("Galarica Cuff")]
        GalaricaCuff = 1633,
        [Description("Style Card")]
        StyleCard = 1634,
        [Description("Armor Pass")]
        ArmorPass = 1635,
        [Description("Rotom Bike")]
        RotomBikeSparklingWhite = 1636,
        [Description("Rotom Bike")]
        RotomBikeGlisteningBlack = 1637,
        [Description("Exp. Charm")]
        ExpCharm = 1638,
        [Description("Armorite Ore")]
        ArmoriteOre = 1639,
        [Description("Mark Charm")]
        MarkCharm = 1640,
        [Description("Reins of Unity")]
        ReinsOfUnityMerge = 1641,
        [Description("Reins of Unity")]
        ReinsOfUnitySplit = 1642,
        [Description("Galarica Wreath")]
        GalaricaWreath = 1643,
        [Description("Legendary Clue 1")]
        LegendaryClue1 = 1644,
        [Description("Legendary Clue 2")]
        LegendaryClue2 = 1645,
        [Description("Legendary Clue 3")]
        LegendaryClue3 = 1646,
        [Description("Legendary Clue?")]
        LegendaryClueQuestion = 1647,
        [Description("Crown Pass")]
        CrownPass = 1648,
        [Description("Wooden Crown")]
        WoodenCrown = 1649,
        [Description("Radiant Petal")]
        RadiantPetal = 1650,
        [Description("White Mane Hair")]
        WhiteManeHair = 1651,
        [Description("Black Mane Hair")]
        BlackManeHair = 1652,
        [Description("Iceroot Carrot")]
        IcerootCarrot = 1653,
        [Description("Shaderoot Carrot")]
        ShaderootCarrot = 1654,
        [Description("Dynite Ore")]
        DyniteOre = 1655,
        [Description("Carrot Seeds")]
        CarrotSeeds = 1656,
        [Description("Ability Patch")]
        AbilityPatch = 1657,
        [Description("Reins of Unity")]
        ReinsOfUnity = 1658,
        [Description("Adamant Crystal")]
        AdamantCrystal = 1659,
        [Description("Lustrous Globe")]
        LustrousGlobe = 1660,
        [Description("Griseous Core")]
        GriseousCore = 1661,
        [Description("Blank Plate")]
        BlankPlate = 1662,
        [Description("Strange Ball")]
        StrangeBall = 1663,
        [Description("Legend Plate")]
        LegendPlate = 1664,
        [Description("Rotom Phone")]
        RotomPhone = 1665,
        [Description("Sandwich")]
        Sandwich = 1666,
        [Description("Koraidon’s Poké Ball")]
        KoraidonPokéBall = 1667,
        [Description("Miraidon’s Poké Ball")]
        MiraidonPokéBall = 1668,
        [Description("Tera Orb")]
        TeraOrb = 1669,
        [Description("Scarlet Book")]
        ScarletBook = 1670,
        [Description("Violet Book")]
        VioletBook = 1671,
        [Description("Kofu’s Wallet")]
        KofuWallet = 1672,
        [Description("Tiny Bamboo Shoot")]
        TinyBambooShoot = 1673,
        [Description("Big Bamboo Shoot")]
        BigBambooShoot = 1674,
        [Description("Scroll of Darkness")]
        ScrollOfDarkness = 1675,
        [Description("Scroll of Waters")]
        ScrollOfWaters = 1676,
        [Description("Malicious Armor")]
        MaliciousArmor = 1677,
        [Description("Normal Tera Shard")]
        NormalTeraShard = 1678,
        [Description("Fire Tera Shard")]
        FireTeraShard = 1679,
        [Description("Water Tera Shard")]
        WaterTeraShard = 1680,
        [Description("Electric Tera Shard")]
        ElectricTeraShard = 1681,
        [Description("Grass Tera Shard")]
        GrassTeraShard = 1682,
        [Description("Ice Tera Shard")]
        IceTeraShard = 1683,
        [Description("Fighting Tera Shard")]
        FightingTeraShard = 1684,
        [Description("Poison Tera Shard")]
        PoisonTeraShard = 1685,
        [Description("Ground Tera Shard")]
        GroundTeraShard = 1686,
        [Description("Flying Tera Shard")]
        FlyingTeraShard = 1687,
        [Description("Psychic Tera Shard")]
        PsychicTeraShard = 1688,
        [Description("Bug Tera Shard")]
        BugTeraShard = 1689,
        [Description("Rock Tera Shard")]
        RockTeraShard = 1690,
        [Description("Ghost Tera Shard")]
        GhostTeraShard = 1691,
        [Description("Dragon Tera Shard")]
        DragonTeraShard = 1692,
        [Description("Dark Tera Shard")]
        DarkTeraShard = 1693,
        [Description("Steel Tera Shard")]
        SteelTeraShard = 1694,
        [Description("Fairy Tera Shard")]
        FairyTeraShard = 1695,
        [Description("Booster Energy")]
        BoosterEnergy = 1696,
        [Description("Ability Shield")]
        AbilityShield = 1697,
        [Description("Clear Amulet")]
        ClearAmulet = 1698,
        [Description("Mirror Herb")]
        MirrorHerb = 1699,
        [Description("Punching Glove")]
        PunchingGlove = 1700,
        [Description("Covert Cloak")]
        CovertCloak = 1701,
        [Description("Loaded Dice")]
        LoadedDice = 1702,
        [Description("Baguette")]
        Baguette = 1703,
        [Description("Mayonnaise")]
        Mayonnaise = 1704,
        [Description("Ketchup")]
        Ketchup = 1705,
        [Description("Mustard")]
        Mustard = 1706,
        [Description("Butter")]
        Butter = 1707,
        [Description("Peanut Butter")]
        PeanutButter = 1708,
        [Description("Chili Sauce")]
        ChiliSauce = 1709,
        [Description("Salt")]
        Salt = 1710,
        [Description("Pepper")]
        Pepper = 1711,
        [Description("Yogurt")]
        Yogurt = 1712,
        [Description("Whipped Cream")]
        WhippedCream = 1713,
        [Description("Cream Cheese")]
        CreamCheese = 1714,
        [Description("Jam")]
        Jam = 1715,
        [Description("Marmalade")]
        Marmalade = 1716,
        [Description("Olive Oil")]
        OliveOil = 1717,
        [Description("Vinegar")]
        Vinegar = 1718,
        [Description("Sweet Herba Mystica")]
        SweetHerbaMystica = 1719,
        [Description("Salty Herba Mystica")]
        SaltyHerbaMystica = 1720,
        [Description("Sour Herba Mystica")]
        SourHerbaMystica = 1721,
        [Description("Bitter Herba Mystica")]
        BitterHerbaMystica = 1722,
        [Description("Spicy Herba Mystica")]
        SpicyHerbaMystica = 1723,
        [Description("Lettuce")]
        Lettuce = 1724,
        [Description("Tomato")]
        Tomato = 1725,
        [Description("Cherry Tomatoes")]
        CherryTomatoes = 1726,
        [Description("Cucumber")]
        Cucumber = 1727,
        [Description("Pickle")]
        Pickle = 1728,
        [Description("Onion")]
        Onion = 1729,
        [Description("Red Onion")]
        RedOnion = 1730,
        [Description("Green Bell Pepper")]
        GreenBellPepper = 1731,
        [Description("Red Bell Pepper")]
        RedBellPepper = 1732,
        [Description("Yellow Bell Pepper")]
        YellowBellPepper = 1733,
        [Description("Avocado")]
        Avocado = 1734,
        [Description("Bacon")]
        Bacon = 1735,
        [Description("Ham")]
        Ham = 1736,
        [Description("Prosciutto")]
        Prosciutto = 1737,
        [Description("Chorizo")]
        Chorizo = 1738,
        [Description("Herbed Sausage")]
        HerbedSausage = 1739,
        [Description("Hamburger")]
        Hamburger = 1740,
        [Description("Klawf Stick")]
        KlawfStick = 1741,
        [Description("Smoked Fillet")]
        SmokedFillet = 1742,
        [Description("Fried Fillet")]
        FriedFillet = 1743,
        [Description("Egg")]
        Egg = 1744,
        [Description("Potato Tortilla")]
        PotatoTortilla = 1745,
        [Description("Tofu")]
        Tofu = 1746,
        [Description("Rice")]
        Rice = 1747,
        [Description("Noodles")]
        Noodles = 1748,
        [Description("Potato Salad")]
        PotatoSalad = 1749,
        [Description("Cheese")]
        Cheese = 1750,
        [Description("Banana")]
        Banana = 1751,
        [Description("Strawberry")]
        Strawberry = 1752,
        [Description("Apple")]
        Apple = 1753,
        [Description("Kiwi")]
        Kiwi = 1754,
        [Description("Pineapple")]
        Pineapple = 1755,
        [Description("Jalapeño")]
        Jalapeño = 1756,
        [Description("Horseradish")]
        Horseradish = 1757,
        [Description("Curry Powder")]
        CurryPowder = 1758,
        [Description("Wasabi")]
        Wasabi = 1759,
        [Description("Watercress")]
        Watercress = 1760,
        [Description("Basil")]
        Basil = 1761,
        [Description("Venonat Fang")]
        VenonatFang = 1762,
        [Description("Diglett Dirt")]
        DiglettDirt = 1763,
        [Description("Meowth Fur")]
        MeowthFur = 1764,
        [Description("Psyduck Down")]
        PsyduckDown = 1765,
        [Description("Mankey Fur")]
        MankeyFur = 1766,
        [Description("Growlithe Fur")]
        GrowlitheFur = 1767,
        [Description("Slowpoke Claw")]
        SlowpokeClaw = 1768,
        [Description("Magnemite Screw")]
        MagnemiteScrew = 1769,
        [Description("Grimer Toxin")]
        GrimerToxin = 1770,
        [Description("Shellder Pearl")]
        ShellderPearl = 1771,
        [Description("Gastly Gas")]
        GastlyGas = 1772,
        [Description("Drowzee Fur")]
        DrowzeeFur = 1773,
        [Description("Voltorb Sparks")]
        VoltorbSparks = 1774,
        [Description("Scyther Claw")]
        ScytherClaw = 1775,
        [Description("Tauros Hair")]
        TaurosHair = 1776,
        [Description("Magikarp Scales")]
        MagikarpScales = 1777,
        [Description("Ditto Goo")]
        DittoGoo = 1778,
        [Description("Eevee Fur")]
        EeveeFur = 1779,
        [Description("Dratini Scales")]
        DratiniScales = 1780,
        [Description("Pichu Fur")]
        PichuFur = 1781,
        [Description("Igglybuff Fluff")]
        IgglybuffFluff = 1782,
        [Description("Mareep Wool")]
        MareepWool = 1783,
        [Description("Hoppip Leaf")]
        HoppipLeaf = 1784,
        [Description("Sunkern Leaf")]
        SunkernLeaf = 1785,
        [Description("Murkrow Bauble")]
        MurkrowBauble = 1786,
        [Description("Misdreavus Tears")]
        MisdreavusTears = 1787,
        [Description("Girafarig Fur")]
        GirafarigFur = 1788,
        [Description("Pineco Husk")]
        PinecoHusk = 1789,
        [Description("Dunsparce Scales")]
        DunsparceScales = 1790,
        [Description("Qwilfish Spines")]
        QwilfishSpines = 1791,
        [Description("Heracross Claw")]
        HeracrossClaw = 1792,
        [Description("Sneasel Claw")]
        SneaselClaw = 1793,
        [Description("Teddiursa Claw")]
        TeddiursaClaw = 1794,
        [Description("Delibird Parcel")]
        DelibirdParcel = 1795,
        [Description("Houndour Fang")]
        HoundourFang = 1796,
        [Description("Phanpy Nail")]
        PhanpyNail = 1797,
        [Description("Stantler Hair")]
        StantlerHair = 1798,
        [Description("Larvitar Claw")]
        LarvitarClaw = 1799,
        [Description("Wingull Feather")]
        WingullFeather = 1800,
        [Description("Ralts Dust")]
        RaltsDust = 1801,
        [Description("Surskit Syrup")]
        SurskitSyrup = 1802,
        [Description("Shroomish Spores")]
        ShroomishSpores = 1803,
        [Description("Slakoth Fur")]
        SlakothFur = 1804,
        [Description("Makuhita Sweat")]
        MakuhitaSweat = 1805,
        [Description("Azurill Fur")]
        AzurillFur = 1806,
        [Description("Sableye Gem")]
        SableyeGem = 1807,
        [Description("Meditite Sweat")]
        MedititeSweat = 1808,
        [Description("Gulpin Mucus")]
        GulpinMucus = 1809,
        [Description("Numel Lava")]
        NumelLava = 1810,
        [Description("Torkoal Coal")]
        TorkoalCoal = 1811,
        [Description("Spoink Pearl")]
        SpoinkPearl = 1812,
        [Description("Cacnea Needle")]
        CacneaNeedle = 1813,
        [Description("Swablu Fluff")]
        SwabluFluff = 1814,
        [Description("Zangoose Claw")]
        ZangooseClaw = 1815,
        [Description("Seviper Fang")]
        SeviperFang = 1816,
        [Description("Barboach Slime")]
        BarboachSlime = 1817,
        [Description("Shuppet Scrap")]
        ShuppetScrap = 1818,
        [Description("Tropius Leaf")]
        TropiusLeaf = 1819,
        [Description("Snorunt Fur")]
        SnoruntFur = 1820,
        [Description("Luvdisc Scales")]
        LuvdiscScales = 1821,
        [Description("Bagon Scales")]
        BagonScales = 1822,
        [Description("Starly Feather")]
        StarlyFeather = 1823,
        [Description("Kricketot Shell")]
        KricketotShell = 1824,
        [Description("Shinx Fang")]
        ShinxFang = 1825,
        [Description("Combee Honey")]
        CombeeHoney = 1826,
        [Description("Pachirisu Fur")]
        PachirisuFur = 1827,
        [Description("Buizel Fur")]
        BuizelFur = 1828,
        [Description("Shellos Mucus")]
        ShellosMucus = 1829,
        [Description("Drifloon Gas")]
        DrifloonGas = 1830,
        [Description("Stunky Fur")]
        StunkyFur = 1831,
        [Description("Bronzor Fragment")]
        BronzorFragment = 1832,
        [Description("Bonsly Tears")]
        BonslyTears = 1833,
        [Description("Happiny Dust")]
        HappinyDust = 1834,
        [Description("Spiritomb Fragment")]
        SpiritombFragment = 1835,
        [Description("Gible Scales")]
        GibleScales = 1836,
        [Description("Riolu Fur")]
        RioluFur = 1837,
        [Description("Hippopotas Sand")]
        HippopotasSand = 1838,
        [Description("Croagunk Poison")]
        CroagunkPoison = 1839,
        [Description("Finneon Scales")]
        FinneonScales = 1840,
        [Description("Snover Berries")]
        SnoverBerries = 1841,
        [Description("Rotom Sparks")]
        RotomSparks = 1842,
        [Description("Petilil Leaf")]
        PetililLeaf = 1843,
        [Description("Basculin Fang")]
        BasculinFang = 1844,
        [Description("Sandile Claw")]
        SandileClaw = 1845,
        [Description("Zorua Fur")]
        ZoruaFur = 1846,
        [Description("Gothita Eyelash")]
        GothitaEyelash = 1847,
        [Description("Deerling Hair")]
        DeerlingHair = 1848,
        [Description("Foongus Spores")]
        FoongusSpores = 1849,
        [Description("Alomomola Mucus")]
        AlomomolaMucus = 1850,
        [Description("Tynamo Slime")]
        TynamoSlime = 1851,
        [Description("Axew Scales")]
        AxewScales = 1852,
        [Description("Cubchoo Fur")]
        CubchooFur = 1853,
        [Description("Cryogonal Ice")]
        CryogonalIce = 1854,
        [Description("Pawniard Blade")]
        PawniardBlade = 1855,
        [Description("Rufflet Feather")]
        RuffletFeather = 1856,
        [Description("Deino Scales")]
        DeinoScales = 1857,
        [Description("Larvesta Fuzz")]
        LarvestaFuzz = 1858,
        [Description("Fletchling Feather")]
        FletchlingFeather = 1859,
        [Description("Scatterbug Powder")]
        ScatterbugPowder = 1860,
        [Description("Litleo Tuft")]
        LitleoTuft = 1861,
        [Description("Flabébé Pollen")]
        FlabébéPollen = 1862,
        [Description("Skiddo Leaf")]
        SkiddoLeaf = 1863,
        [Description("Skrelp Kelp")]
        SkrelpKelp = 1864,
        [Description("Clauncher Claw")]
        ClauncherClaw = 1865,
        [Description("Hawlucha Down")]
        HawluchaDown = 1866,
        [Description("Dedenne Fur")]
        DedenneFur = 1867,
        [Description("Goomy Goo")]
        GoomyGoo = 1868,
        [Description("Klefki Key")]
        KlefkiKey = 1869,
        [Description("Bergmite Ice")]
        BergmiteIce = 1870,
        [Description("Noibat Fur")]
        NoibatFur = 1871,
        [Description("Yungoos Fur")]
        YungoosFur = 1872,
        [Description("Crabrawler Shell")]
        CrabrawlerShell = 1873,
        [Description("Oricorio Feather")]
        OricorioFeather = 1874,
        [Description("Rockruff Rock")]
        RockruffRock = 1875,
        [Description("Mareanie Spike")]
        MareanieSpike = 1876,
        [Description("Mudbray Mud")]
        MudbrayMud = 1877,
        [Description("Fomantis Leaf")]
        FomantisLeaf = 1878,
        [Description("Salandit Gas")]
        SalanditGas = 1879,
        [Description("Bounsweet Sweat")]
        BounsweetSweat = 1880,
        [Description("Oranguru Fur")]
        OranguruFur = 1881,
        [Description("Passimian Fur")]
        PassimianFur = 1882,
        [Description("Sandygast Sand")]
        SandygastSand = 1883,
        [Description("Komala Claw")]
        KomalaClaw = 1884,
        [Description("Mimikyu Scrap")]
        MimikyuScrap = 1885,
        [Description("Bruxish Tooth")]
        BruxishTooth = 1886,
        [Description("Chewtle Claw")]
        ChewtleClaw = 1887,
        [Description("Skwovet Fur")]
        SkwovetFur = 1888,
        [Description("Arrokuda Scales")]
        ArrokudaScales = 1889,
        [Description("Rookidee Feather")]
        RookideeFeather = 1890,
        [Description("Toxel Sparks")]
        ToxelSparks = 1891,
        [Description("Falinks Sweat")]
        FalinksSweat = 1892,
        [Description("Cufant Tarnish")]
        CufantTarnish = 1893,
        [Description("Rolycoly Coal")]
        RolycolyCoal = 1894,
        [Description("Silicobra Sand")]
        SilicobraSand = 1895,
        [Description("Indeedee Fur")]
        IndeedeeFur = 1896,
        [Description("Pincurchin Spines")]
        PincurchinSpines = 1897,
        [Description("Snom Thread")]
        SnomThread = 1898,
        [Description("Impidimp Hair")]
        ImpidimpHair = 1899,
        [Description("Applin Juice")]
        ApplinJuice = 1900,
        [Description("Sinistea Chip")]
        SinisteaChip = 1901,
        [Description("Hatenna Dust")]
        HatennaDust = 1902,
        [Description("Stonjourner Stone")]
        StonjournerStone = 1903,
        [Description("Eiscue Down")]
        EiscueDown = 1904,
        [Description("Dreepy Powder")]
        DreepyPowder = 1905,
        [Description("Lechonk Hair")]
        LechonkHair = 1906,
        [Description("Tarountula Thread")]
        TarountulaThread = 1907,
        [Description("Nymble Claw")]
        NymbleClaw = 1908,
        [Description("Rellor Mud")]
        RellorMud = 1909,
        [Description("Greavard Wax")]
        GreavardWax = 1910,
        [Description("Flittle Down")]
        FlittleDown = 1911,
        [Description("Wiglett Sand")]
        WiglettSand = 1912,
        [Description("Dondozo Whisker")]
        DondozoWhisker = 1913,
        [Description("Veluza Fillet")]
        VeluzaFillet = 1914,
        [Description("Finizen Mucus")]
        FinizenMucus = 1915,
        [Description("Smoliv Oil")]
        SmolivOil = 1916,
        [Description("Capsakid Seed")]
        CapsakidSeed = 1917,
        [Description("Tadbulb Mucus")]
        TadbulbMucus = 1918,
        [Description("Varoom Fume")]
        VaroomFume = 1919,
        [Description("Orthworm Tarnish")]
        OrthwormTarnish = 1920,
        [Description("Tandemaus Fur")]
        TandemausFur = 1921,
        [Description("Cetoddle Grease")]
        CetoddleGrease = 1922,
        [Description("Frigibax Scales")]
        FrigibaxScales = 1923,
        [Description("Tatsugiri Scales")]
        TatsugiriScales = 1924,
        [Description("Cyclizar Scales")]
        CyclizarScales = 1925,
        [Description("Pawmi Fur")]
        PawmiFur = 1926,
        [Description("Wattrel Feather")]
        WattrelFeather = 1927,
        [Description("Bombirdier Feather")]
        BombirdierFeather = 1928,
        [Description("Squawkabilly Feather")]
        SquawkabillyFeather = 1929,
        [Description("Flamigo Down")]
        FlamigoDown = 1930,
        [Description("Klawf Claw")]
        KlawfClaw = 1931,
        [Description("Nacli Salt")]
        NacliSalt = 1932,
        [Description("Glimmet Crystal")]
        GlimmetCrystal = 1933,
        [Description("Shroodle Ink")]
        ShroodleInk = 1934,
        [Description("Fidough Fur")]
        FidoughFur = 1935,
        [Description("Maschiff Fang")]
        MaschiffFang = 1936,
        [Description("Bramblin Twig")]
        BramblinTwig = 1937,
        [Description("Gimmighoul Coin")]
        GimmighoulCoin = 1938,
        [Description("Tinkatink Hair")]
        TinkatinkHair = 1939,
        [Description("Charcadet Soot")]
        CharcadetSoot = 1940,
        [Description("Toedscool Flaps")]
        ToedscoolFlaps = 1941,
        [Description("Wooper Slime")]
        WooperSlime = 1942,
        [Description("TM100")]
        Tm100_ = 1943,
        [Description("TM101")]
        Tm101 = 1944,
        [Description("TM102")]
        Tm102 = 1945,
        [Description("TM103")]
        Tm103 = 1946,
        [Description("TM104")]
        Tm104 = 1947,
        [Description("TM105")]
        Tm105 = 1948,
        [Description("TM106")]
        Tm106 = 1949,
        [Description("TM107")]
        Tm107 = 1950,
        [Description("TM108")]
        Tm108 = 1951,
        [Description("TM109")]
        Tm109 = 1952,
        [Description("TM110")]
        Tm110 = 1953,
        [Description("TM111")]
        Tm111 = 1954,
        [Description("TM112")]
        Tm112 = 1955,
        [Description("TM113")]
        Tm113 = 1956,
        [Description("TM114")]
        Tm114 = 1957,
        [Description("TM115")]
        Tm115 = 1958,
        [Description("TM116")]
        Tm116 = 1959,
        [Description("TM117")]
        Tm117 = 1960,
        [Description("TM118")]
        Tm118 = 1961,
        [Description("TM119")]
        Tm119 = 1962,
        [Description("TM120")]
        Tm120 = 1963,
        [Description("TM121")]
        Tm121 = 1964,
        [Description("TM122")]
        Tm122 = 1965,
        [Description("TM123")]
        Tm123 = 1966,
        [Description("TM124")]
        Tm124 = 1967,
        [Description("TM125")]
        Tm125 = 1968,
        [Description("TM126")]
        Tm126 = 1969,
        [Description("TM127")]
        Tm127 = 1970,
        [Description("TM128")]
        Tm128 = 1971,
        [Description("TM129")]
        Tm129 = 1972,
        [Description("TM130")]
        Tm130 = 1973,
        [Description("TM131")]
        Tm131 = 1974,
        [Description("TM132")]
        Tm132 = 1975,
        [Description("TM133")]
        Tm133 = 1976,
        [Description("TM134")]
        Tm134 = 1977,
        [Description("TM135")]
        Tm135 = 1978,
        [Description("TM136")]
        Tm136 = 1979,
        [Description("TM137")]
        Tm137 = 1980,
        [Description("TM138")]
        Tm138 = 1981,
        [Description("TM139")]
        Tm139 = 1982,
        [Description("TM140")]
        Tm140 = 1983,
        [Description("TM141")]
        Tm141 = 1984,
        [Description("TM142")]
        Tm142 = 1985,
        [Description("TM143")]
        Tm143 = 1986,
        [Description("TM144")]
        Tm144 = 1987,
        [Description("TM145")]
        Tm145 = 1988,
        [Description("TM146")]
        Tm146 = 1989,
        [Description("TM147")]
        Tm147 = 1990,
        [Description("TM148")]
        Tm148 = 1991,
        [Description("TM149")]
        Tm149 = 1992,
        [Description("TM150")]
        Tm150 = 1993,
        [Description("TM151")]
        Tm151 = 1994,
        [Description("TM152")]
        Tm152 = 1995,
        [Description("TM153")]
        Tm153 = 1996,
        [Description("TM154")]
        Tm154 = 1997,
        [Description("TM155")]
        Tm155 = 1998,
        [Description("TM156")]
        Tm156 = 1999,
        [Description("TM157")]
        Tm157 = 2000,
        [Description("TM158")]
        Tm158 = 2001,
        [Description("TM159")]
        Tm159 = 2002,
        [Description("TM160")]
        Tm160 = 2003,
        [Description("TM161")]
        Tm161 = 2004,
        [Description("TM162")]
        Tm162 = 2005,
        [Description("TM163")]
        Tm163 = 2006,
        [Description("TM164")]
        Tm164 = 2007,
        [Description("TM165")]
        Tm165 = 2008,
        [Description("TM166")]
        Tm166 = 2009,
        [Description("TM167")]
        Tm167 = 2010,
        [Description("TM168")]
        Tm168 = 2011,
        [Description("TM169")]
        Tm169 = 2012,
        [Description("TM170")]
        Tm170 = 2013,
        [Description("TM171")]
        Tm171 = 2014,
        [Description("Picnic Set")]
        PicnicSet = 2015,
        [Description("Academy Bottle")]
        AcademyBottle = 2016,
        [Description("Academy Bottle")]
        AcademyBottle_ = 2017,
        [Description("Polka-Dot Bottle")]
        PolkaDotBottle = 2018,
        [Description("Striped Bottle")]
        StripedBottle = 2019,
        [Description("Diamond Bottle")]
        DiamondBottle = 2020,
        [Description("Academy Cup")]
        AcademyCup = 2021,
        [Description("Academy Cup")]
        AcademyCup_ = 2022,
        [Description("Striped Cup")]
        StripedCup = 2023,
        [Description("Polka-Dot Cup")]
        PolkaDotCup = 2024,
        [Description("Flower Pattern Cup")]
        FlowerPatternCup = 2025,
        [Description("Academy Tablecloth")]
        AcademyTablecloth = 2026,
        [Description("Academy Tablecloth")]
        AcademyTablecloth_ = 2027,
        [Description("Whimsical Tablecloth")]
        WhimsicalTablecloth = 2028,
        [Description("Leafy Tablecloth")]
        LeafyTablecloth = 2029,
        [Description("Spooky Tablecloth")]
        SpookyTablecloth = 2030,
        [Description("Academy Ball")]
        AcademyBall = 2031,
        [Description("Academy Ball")]
        AcademyBall_ = 2032,
        [Description("Marill Ball")]
        MarillBall = 2033,
        [Description("Yarn Ball")]
        YarnBall = 2034,
        [Description("Cyber Ball")]
        CyberBall = 2035,
        [Description("Gold Pick")]
        GoldPick = 2036,
        [Description("Silver Pick")]
        SilverPick = 2037,
        [Description("Red-Flag Pick")]
        RedFlagPick = 2038,
        [Description("Blue-Flag Pick")]
        BlueFlagPick = 2039,
        [Description("Pika-Pika Pick")]
        PikaPikaPick = 2040,
        [Description("Winking Pika Pick")]
        WinkingPikaPick = 2041,
        [Description("Vee-Vee Pick")]
        VeeVeePick = 2042,
        [Description("Smiling Vee Pick")]
        SmilingVeePick = 2043,
        [Description("Blue Poké Ball Pick")]
        BluePokéBallPick = 2044,
        [Description("Auspicious Armor")]
        AuspiciousArmor = 2045,
        [Description("Leader’s Crest")]
        LeaderCrest = 2046,
        [Description("Pink Bottle")]
        PinkBottle = 2047,
        [Description("Blue Bottle")]
        BlueBottle = 2048,
        [Description("Yellow Bottle")]
        YellowBottle = 2049,
        [Description("Steel Bottle (R)")]
        SteelBottleR = 2050,
        [Description("Steel Bottle (Y)")]
        SteelBottleY = 2051,
        [Description("Steel Bottle (B)")]
        SteelBottleB = 2052,
        [Description("Silver Bottle")]
        SilverBottle = 2053,
        [Description("Barred Cup")]
        BarredCup = 2054,
        [Description("Diamond Pattern Cup")]
        DiamondPatternCup = 2055,
        [Description("Fire Pattern Cup")]
        FirePatternCup = 2056,
        [Description("Pink Cup")]
        PinkCup = 2057,
        [Description("Blue Cup")]
        BlueCup = 2058,
        [Description("Yellow Cup")]
        YellowCup = 2059,
        [Description("Pikachu Cup")]
        PikachuCup = 2060,
        [Description("Eevee Cup")]
        EeveeCup = 2061,
        [Description("Slowpoke Cup")]
        SlowpokeCup = 2062,
        [Description("Silver Cup")]
        SilverCup = 2063,
        [Description("Exercise Ball")]
        ExerciseBall = 2064,
        [Description("Plaid Tablecloth (Y)")]
        PlaidTableclothY = 2065,
        [Description("Plaid Tablecloth (B)")]
        PlaidTableclothB = 2066,
        [Description("Plaid Tablecloth (R)")]
        PlaidTableclothR = 2067,
        [Description("B&W Grass Tablecloth")]
        BWGrassTablecloth = 2068,
        [Description("Battle Tablecloth")]
        BattleTablecloth = 2069,
        [Description("Monstrous Tablecloth")]
        MonstrousTablecloth = 2070,
        [Description("Striped Tablecloth")]
        StripedTablecloth = 2071,
        [Description("Diamond Tablecloth")]
        DiamondTablecloth = 2072,
        [Description("Polka-Dot Tablecloth")]
        PolkaDotTablecloth = 2073,
        [Description("Lilac Tablecloth")]
        LilacTablecloth = 2074,
        [Description("Mint Tablecloth")]
        MintTablecloth = 2075,
        [Description("Peach Tablecloth")]
        PeachTablecloth = 2076,
        [Description("Yellow Tablecloth")]
        YellowTablecloth = 2077,
        [Description("Blue Tablecloth")]
        BlueTablecloth = 2078,
        [Description("Pink Tablecloth")]
        PinkTablecloth = 2079,
        [Description("Gold Bottle")]
        GoldBottle = 2080,
        [Description("Bronze Bottle")]
        BronzeBottle = 2081,
        [Description("Gold Cup")]
        GoldCup = 2082,
        [Description("Bronze Cup")]
        BronzeCup = 2083,
        [Description("Green Poké Ball Pick")]
        GreenPokéBallPick = 2084,
        [Description("Red Poké Ball Pick")]
        RedPokéBallPick = 2085,
        [Description("Party Sparkler Pick")]
        PartySparklerPick = 2086,
        [Description("Heroic Sword Pick")]
        HeroicSwordPick = 2087,
        [Description("Magical Star Pick")]
        MagicalStarPick = 2088,
        [Description("Magical Heart Pick")]
        MagicalHeartPick = 2089,
        [Description("Parasol Pick")]
        ParasolPick = 2090,
        [Description("Blue-Sky Flower Pick")]
        BlueSkyFlowerPick = 2091,
        [Description("Sunset Flower Pick")]
        SunsetFlowerPick = 2092,
        [Description("Sunrise Flower Pick")]
        SunriseFlowerPick = 2093,
        [Description("Blue Dish")]
        BlueDish = 2094,
        [Description("Green Dish")]
        GreenDish = 2095,
        [Description("Orange Dish")]
        OrangeDish = 2096,
        [Description("Red Dish")]
        RedDish = 2097,
        [Description("White Dish")]
        WhiteDish = 2098,
        [Description("Yellow Dish")]
        YellowDish = 2099,
        [Description("Roto Stick")]
        RotoStick = 2100,
        [Description("Teal Style Card")]
        TealStyleCard = 2101,
        [Description("Teal Mask")]
        TealMask = 2102,
        [Description("Glimmering Charm")]
        GlimmeringCharm = 2103,
        [Description("Crystal Cluster")]
        CrystalCluster = 2104,
        [Description("Fairy Feather")]
        FairyFeather = 2105,
        [Description("Wellspring Mask")]
        WellspringMask = 2106,
        [Description("Hearthflame Mask")]
        HearthflameMask = 2107,
        [Description("Cornerstone Mask")]
        CornerstoneMask = 2108,
        [Description("Syrupy Apple")]
        SyrupyApple = 2109,
        [Description("Unremarkable Teacup")]
        UnremarkableTeacup = 2110,
        [Description("Masterpiece Teacup")]
        MasterpieceTeacup = 2111,
        [Description("Health Mochi")]
        HealthMochi = 2112,
        [Description("Muscle Mochi")]
        MuscleMochi = 2113,
        [Description("Resist Mochi")]
        ResistMochi = 2114,
        [Description("Genius Mochi")]
        GeniusMochi = 2115,
        [Description("Clever Mochi")]
        CleverMochi = 2116,
        [Description("Swift Mochi")]
        SwiftMochi = 2117,
        [Description("Fresh Start Mochi")]
        FreshStartMochi = 2118,
        [Description("Ekans Fang")]
        EkansFang = 2119,
        [Description("Sandshrew Claw")]
        SandshrewClaw = 2120,
        [Description("Cleffa Fur")]
        CleffaFur = 2121,
        [Description("Vulpix Fur")]
        VulpixFur = 2122,
        [Description("Poliwag Slime")]
        PoliwagSlime = 2123,
        [Description("Bellsprout Vine")]
        BellsproutVine = 2124,
        [Description("Geodude Fragment")]
        GeodudeFragment = 2125,
        [Description("Koffing Gas")]
        KoffingGas = 2126,
        [Description("Munchlax Fang")]
        MunchlaxFang = 2127,
        [Description("Sentret Fur")]
        SentretFur = 2128,
        [Description("Hoothoot Feather")]
        HoothootFeather = 2129,
        [Description("Spinarak Thread")]
        SpinarakThread = 2130,
        [Description("Aipom Hair")]
        AipomHair = 2131,
        [Description("Yanma Spike")]
        YanmaSpike = 2132,
        [Description("Gligar Fang")]
        GligarFang = 2133,
        [Description("Slugma Lava")]
        SlugmaLava = 2134,
        [Description("Swinub Hair")]
        SwinubHair = 2135,
        [Description("Poochyena Fang")]
        PoochyenaFang = 2136,
        [Description("Lotad Leaf")]
        LotadLeaf = 2137,
        [Description("Seedot Stem")]
        SeedotStem = 2138,
        [Description("Nosepass Fragment")]
        NosepassFragment = 2139,
        [Description("Volbeat Fluid")]
        VolbeatFluid = 2140,
        [Description("Illumise Fluid")]
        IllumiseFluid = 2141,
        [Description("Corphish Shell")]
        CorphishShell = 2142,
        [Description("Feebas Scales")]
        FeebasScales = 2143,
        [Description("Duskull Fragment")]
        DuskullFragment = 2144,
        [Description("Chingling Fragment")]
        ChinglingFragment = 2145,
        [Description("Timburr Sweat")]
        TimburrSweat = 2146,
        [Description("Sewaddle Leaf")]
        SewaddleLeaf = 2147,
        [Description("Ducklett Feather")]
        DucklettFeather = 2148,
        [Description("Litwick Soot")]
        LitwickSoot = 2149,
        [Description("Mienfoo Claw")]
        MienfooClaw = 2150,
        [Description("Vullaby Feather")]
        VullabyFeather = 2151,
        [Description("Carbink Jewel")]
        CarbinkJewel = 2152,
        [Description("Phantump Twig")]
        PhantumpTwig = 2153,
        [Description("Grubbin Thread")]
        GrubbinThread = 2154,
        [Description("Cutiefly Powder")]
        CutieflyPowder = 2155,
        [Description("Jangmo-o Scales")]
        JangmoOScales = 2156,
        [Description("Cramorant Down")]
        CramorantDown = 2157,
        [Description("Morpeko Snack")]
        MorpekoSnack = 2158,
        [Description("Poltchageist Powder")]
        PoltchageistPowder = 2159,
        [Description("Linking Cord")]
        LinkingCord = 2160,
        [Description("TM172")]
        Tm172 = 2161,
        [Description("TM173")]
        Tm173 = 2162,
        [Description("TM174")]
        Tm174 = 2163,
        [Description("TM175")]
        Tm175 = 2164,
        [Description("TM176")]
        Tm176 = 2165,
        [Description("TM177")]
        Tm177 = 2166,
        [Description("TM178")]
        Tm178 = 2167,
        [Description("TM179")]
        Tm179 = 2168,
        [Description("TM180")]
        Tm180 = 2169,
        [Description("TM181")]
        Tm181 = 2170,
        [Description("TM182")]
        Tm182 = 2171,
        [Description("TM183")]
        Tm183 = 2172,
        [Description("TM184")]
        Tm184 = 2173,
        [Description("TM185")]
        Tm185 = 2174,
        [Description("TM186")]
        Tm186 = 2175,
        [Description("TM187")]
        Tm187 = 2176,
        [Description("TM188")]
        Tm188 = 2177,
        [Description("TM189")]
        Tm189 = 2178,
        [Description("TM190")]
        Tm190 = 2179,
        [Description("TM191")]
        Tm191 = 2180,
        [Description("TM192")]
        Tm192 = 2181,
        [Description("TM193")]
        Tm193 = 2182,
        [Description("TM194")]
        Tm194 = 2183,
        [Description("TM195")]
        Tm195 = 2184,
        [Description("TM196")]
        Tm196 = 2185,
        [Description("TM197")]
        Tm197 = 2186,
        [Description("TM198")]
        Tm198 = 2187,
        [Description("TM199")]
        Tm199 = 2188,
        [Description("TM200")]
        Tm200 = 2189,
        [Description("TM201")]
        Tm201 = 2190,
        [Description("TM202")]
        Tm202 = 2191,
        [Description("TM203")]
        Tm203 = 2192,
        [Description("TM204")]
        Tm204 = 2193,
        [Description("TM205")]
        Tm205 = 2194,
        [Description("TM206")]
        Tm206 = 2195,
        [Description("TM207")]
        Tm207 = 2196,
        [Description("TM208")]
        Tm208 = 2197,
        [Description("TM209")]
        Tm209 = 2198,
        [Description("TM210")]
        Tm210 = 2199,
        [Description("TM211")]
        Tm211 = 2200,
        [Description("TM212")]
        Tm212 = 2201,
        [Description("TM213")]
        Tm213 = 2202,
        [Description("TM214")]
        Tm214 = 2203,
        [Description("TM215")]
        Tm215 = 2204,
        [Description("TM216")]
        Tm216 = 2205,
        [Description("TM217")]
        Tm217 = 2206,
        [Description("TM218")]
        Tm218 = 2207,
        [Description("TM219")]
        Tm219 = 2208,
        [Description("TM220")]
        Tm220 = 2209,
        [Description("TM221")]
        Tm221 = 2210,
        [Description("TM222")]
        Tm222 = 2211,
        [Description("TM223")]
        Tm223 = 2212,
        [Description("TM224")]
        Tm224 = 2213,
        [Description("TM225")]
        Tm225 = 2214,
        [Description("TM226")]
        Tm226 = 2215,
        [Description("TM227")]
        Tm227 = 2216,
        [Description("TM228")]
        Tm228 = 2217,
        [Description("TM229")]
        Tm229 = 2218,
        [Description("Strange Ball")]
        LastrangeBall = 2219,
        [Description("Poké Ball")]
        LapokeBall = 2220,
        [Description("Great Ball")]
        LagreatBall = 2221,
        [Description("Ultra Ball")]
        LaultraBall = 2222,
        [Description("Heavy Ball")]
        LaheavyBall = 2223,
        [Description("Leaden Ball")]
        LaleadenBall = 2224,
        [Description("Gigaton Ball")]
        LagigatonBall = 2225,
        [Description("Feather Ball")]
        LafeatherBall = 2226,
        [Description("Wing Ball")]
        LawingBall = 2227,
        [Description("Jet Ball")]
        LajetBall = 2228,
        [Description("Origin Ball")]
        LaoriginBall = 2229,
    }
}
