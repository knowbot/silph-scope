using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.Models.Core.Sprites;

/// <summary>
/// This data identifies a Sprite.
/// </summary>
public readonly struct SpriteIdentifier(Species species, int form, Gender gender, bool shiny)
{
    public readonly Species Species = species;
    public readonly int Form = form;
    public readonly Gender Gender = gender;
    public readonly bool Shiny = shiny;
}
