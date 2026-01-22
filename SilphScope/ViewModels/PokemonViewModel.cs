using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core.Sprites;
using SilphScope.Models.Games.State.Common;
using System.Threading.Tasks;

namespace SilphScope.ViewModels
{
	public partial class PokemonViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string? _Name;

		[ObservableProperty]
		private Bitmap? _Sprite;

		[ObservableProperty]
		private int _Level;

		[ObservableProperty]
		private int _ExpToNext;

		[ObservableProperty]
		private int _Exp;

		public void UpdateGameState(Pokemon? pokemon)
		{
			if (pokemon == null)
			{
				Name = string.Empty;
				return;
			}

			Name = pokemon.Species.ToString();
			Level = pokemon.Level.Current;
			ExpToNext = (int)pokemon.Level.ExpToNext;
			Exp = (int)pokemon.Exp;

			// Ask for asynchronous sprite loading.
			// When sprite has been loaded, go back to UI thread to update UI.
			Task<SpriteLoadResult> task = SpriteAsyncPool.Current.Load(pokemon.Species, SpriteFlags.None);
			task.ContinueWith(task => Dispatcher.UIThread.Post(() => Sprite = task.Result.Result));
		}
	}
}
