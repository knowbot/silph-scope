namespace SilphScope.Models.Games.State.Common.PkmnInfo;

public readonly record struct Level(byte Current, uint Progress, uint ToNext);
