using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.State.Common.PkmnInfo;
using SilphScope.Models.Games.StaticData;

namespace SilphScope.ViewModels
{
	public partial class MoveViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string? _name;

		[ObservableProperty]
		private int? _currentPP;

		[ObservableProperty]
		private int? _TotPP;

		public TypesViewModel MoveType { get; } = new();

		public MoveViewModel() { }

		public void UpdateGameState(Move? move)
		{
			if (move == null)
			{
				Name = default;
				CurrentPP = default;
				TotPP = default;
				MoveType.UpdateGameState(null, null);
				return;
			}

			Name = move.Value.Name.GetDescription();
			CurrentPP = move.Value.CurrPP;
			TotPP = move.Value.TotPP;
			MoveType.UpdateGameState(MoveData.MoveTypes[(int)move.Value.Name], null);
		}
	}
}
