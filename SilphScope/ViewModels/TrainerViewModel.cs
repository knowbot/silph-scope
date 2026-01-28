using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels
{
    public partial class TrainerViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _name = "???";
        [ObservableProperty]
        private ushort _id;
        [ObservableProperty]
        private uint _money;
        [ObservableProperty]
        private bool _gender;
        [ObservableProperty]
        private bool[] _badges = new bool[8];
        [ObservableProperty]
        private bool _hasBadges2 = false;
        [ObservableProperty]
        private bool[] _badges2 = new bool[8];

        public TrainerViewModel()
        { }

        internal void UpdateGameState(Trainer trainer)
        {
            Name = trainer.Name;
            Id = trainer.Id;
            Money = trainer.Money;
            Gender = trainer.Gender;
            HasBadges2 = trainer.Badges2 != null;
            for (int i = 0; i < trainer.Badges; i++)
            {
                Badges[i] = (trainer.Badges & (1 << i)) != 0;
                if (HasBadges2) Badges2[i] = (trainer.Badges2 & (1 << i)) != 0;
            }
        }
    }
}
