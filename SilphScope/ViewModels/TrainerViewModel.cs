using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games;
using SilphScope.Models.Games.State.Common;

namespace SilphScope.ViewModels;

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

    private bool[] _badgeSet = new bool[8];
    private bool[]? _extraBadgeSet;
    private Game? _game;

    public bool HasExtraBadgeSet => _extraBadgeSet != null;

    public ObservableCollection<BadgeViewModel> Badges { get; private set; } = [];
    public bool IsGameDetected => _game != null;

    public TrainerViewModel()
    { }

    public void UpdateGameState(Trainer trainer)
    {
        Name = trainer.Name;
        Id = trainer.Id;
        Money = trainer.Money;
        Gender = trainer.Gender;
        _badgeSet = trainer.Badges;
        _extraBadgeSet = trainer.ExtraBadges;
    }

    public void SetCurrentGame(Game game)
    {
        _game = game;
        Badges.Clear();
        for (int i = 0; i < _badgeSet.Length; i++)
        {
            Badges.Add(new(i + 1, game.BadgesPath, _badgeSet[i]));
        }
    }

}
