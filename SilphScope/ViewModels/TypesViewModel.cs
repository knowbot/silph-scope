using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using SilphScope.Models;
using SilphScope.Models.Extensions;
using SilphScope.Models.Games.StaticData.Enums;

namespace SilphScope.ViewModels
{
	public partial class TypesViewModel : ViewModelBase
	{
		private static readonly BrushCache brushes = new();

		[ObservableProperty]
		private string? _type1;

		[ObservableProperty]
		private string? _type2;

		[ObservableProperty]
		private IBrush? _brush1;

		[ObservableProperty]
		private IBrush? _brush2;

		public TypesViewModel()
		{

		}

		public void UpdateGameState(Types type1, Types? type2)
		{
			Type1 = type1.GetDescription();
			Type2 = type2?.GetDescription();

			Brush1 = brushes.Get(Color.Parse(ColorAttribute.Get(type1)!));
			if (type2 != null)
			{
				Brush2 = brushes.Get(Color.Parse(ColorAttribute.Get(type2)!));
			}
			else
			{
				Brush2 = null;
			}
		}
	}
}
