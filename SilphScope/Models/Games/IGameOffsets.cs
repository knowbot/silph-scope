using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilphScope.Models.GameData
{
    public interface IGameOffsets
    {
        string AnchorString { get; }
        int Anchor { get; }
        int SavePointer { get; }
        int TrainerName { get; }
        int TrainerID { get; }
        int PartySize {  get; }
        int BoxData { get; }
        int Money { get; }
    }
}
