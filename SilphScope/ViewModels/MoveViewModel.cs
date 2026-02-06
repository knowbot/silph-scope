using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.State.Common.PkmnInfo;

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
				return;
			}

			Name = move.Value.Name.GetDescription();
			CurrentPP = move.Value.CurrPP;
			TotPP = move.Value.TotPP;

			// TODO: temporary. Remove.
			MoveType.UpdateGameState(Models.Games.StaticData.Enums.Types.Fire, null);
		}
	}
}
