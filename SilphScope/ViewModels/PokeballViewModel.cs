using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilphScope.ViewModels
{
    public partial class PokeballViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Bitmap? _Sprite;
    }
}
