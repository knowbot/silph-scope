using CommunityToolkit.Mvvm.ComponentModel;

namespace SilphScope.ViewModels
{
	public partial class StatViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string _name;

		[ObservableProperty]
		private int _total;

		[ObservableProperty]
		private int _ivs;

		[ObservableProperty]
		private int _evs;

		public StatViewModel(string name)
		{
			Name = name;
		}

		public void UpdateGameState(ushort total, byte ivs, ushort evs)
		{
			Total = total;
			Ivs = ivs;
			Evs = evs;
		}
	}
}
