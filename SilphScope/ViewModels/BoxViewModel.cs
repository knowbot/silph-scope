using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models.Games.State.Common;
using System.Collections.ObjectModel;
using System.Linq;

namespace SilphScope.ViewModels
{
	public partial class BoxViewModel : ViewModelBase
	{
		[ObservableProperty]
		private ObservableCollection<PokemonViewModel> _contents = [];

		[ObservableProperty]
		private PokemonViewModel? _selected;

		[ObservableProperty]
		private string? _name;

		public BoxViewModel()
		{ }

		internal void UpdateGameState(Box box)
		{
			// Keep the appropriate number of pokemon.
			while (Contents.Count < box.Slots.Length)
			{
				Contents.Add(new());
			}
			while (Contents.Count > box.Slots.Length)
			{
				Contents.RemoveAt(Contents.Count - 1);
			}

			// Update each pokemon.
			for (int i = 0; i < box.Slots.Length; i++)
			{
				Contents[i].UpdateGameState(box.Slots[i]);
			}

			// Ensure first pokemon is automatically selected.
			if (Selected == null && Contents.Count > 0)
			{
				Selected = Contents.First();
			}
		}
	}
}
