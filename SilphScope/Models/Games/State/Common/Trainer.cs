namespace SilphScope.Models.Games.State.Common;

public record Trainer(string Name, ushort Id, uint Money, bool Gender, bool[] Badges, bool[]? ExtraBadges = null);
