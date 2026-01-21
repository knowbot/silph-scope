namespace SilphScope.Models.Games.State.Common.PkmnInfo
{
    public record EVs(int HP, int Attack, int Defense, int SpecialDefense, int SpecialAttack, int Speed)
    {
        public bool IsValid()
        {
            if (HP + Attack + Defense + SpecialDefense + SpecialAttack > 510) return false;
            return !((uint)HP > 252 | (uint)Attack > 252 | (uint)Defense > 252 | (uint)SpecialAttack > 252 | (uint)SpecialDefense > 252 | (uint)Speed > 252);
        }
    }
}
