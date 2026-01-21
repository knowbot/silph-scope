namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record IVs(int HP, int Attack, int Defense, int SpecialAttack, int SpecialDefense, int Speed)
    {
        public bool IsValid()
        {
            return !((uint)HP > 31 | (uint)Attack > 31 | (uint)Defense > 31 | (uint)SpecialAttack > 31 | (uint)SpecialDefense > 31 | (uint)Speed > 31);
        }
    }


}
