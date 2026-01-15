using SilphScope.Models.Games.Enums;

namespace SilphScope.Models.Games
{
    public record MoveSet
    {
        public Move Move1 { get; set; }
        public Move Move2 { get; set; }
        public Move Move3 { get; set; }
        public Move Move4 { get; set; }
    }
}