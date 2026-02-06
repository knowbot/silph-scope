using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Core.Sprites;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.StaticData;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.ViewModels
{
	public partial class PokemonViewModel : ViewModelBase
	{
		[ObservableProperty]
		private string? _name;

		[ObservableProperty]
		private string? _gender;

		[ObservableProperty]
		private string? _nature;

		[ObservableProperty]
		private Bitmap? _sprite;

		[ObservableProperty]
		private int _exp;

		[ObservableProperty]
		private int _level;

		[ObservableProperty]
		private int _levelProgress;

		[ObservableProperty]
		private int _levelToNext;

		public int ExpBarLength => LevelProgress + LevelToNext;

		private PokeballViewModel Pokeball { get; } = new();

		public HeldItemViewModel HeldItem { get; } = new();

		public TypesViewModel Types { get; } = new();

		public StatsViewModel Stats { get; } = new();

		public MoveSetViewModel MoveSet { get; } = new();

		public void UpdateGameState(Pkmn? pokemon)
		{
			if (pokemon == null)
			{
				Name = string.Empty;
				return;
			}

			Name = string.IsNullOrEmpty(pokemon.Nickname) ? pokemon.Species.ToString() : pokemon.Nickname;
			Gender = pokemon.Gender.GetDescription();
			Level = pokemon.Level.Current;
			LevelProgress = (int)pokemon.Level.Progress;
			LevelToNext = (int)pokemon.Level.ToNext;
			Exp = (int)pokemon.Exp;
			HeldItem.UpdateGameState(pokemon.HeldItem);
			Nature = pokemon.Nature.ToString();

			(Types, Types?) typeData = TypeTables.Gen3to5[(int)pokemon.Species];
			Types.UpdateGameState(typeData.Item1, typeData.Item2);

			Stats.UpdateGameState(pokemon);
			MoveSet.UpdateGameState(pokemon.MoveSet);

			// Ask for asynchronous sprite loading.
			// When sprite has been loaded, go back to UI thread to update UI.
			SpriteLoadTask task = SpriteAsyncPool.Current.Load(pokemon.Species, SpriteFlags.None);
			task.OnCompleted(() => Dispatcher.UIThread.Post(() => Sprite = task.Result.Sprite));
		}
	}
}
