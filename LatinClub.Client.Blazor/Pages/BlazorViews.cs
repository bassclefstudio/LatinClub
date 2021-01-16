using BassClefStudio.AppModel.Navigation;
using BassClefStudio.LatinClub.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Client.Blazor.Pages
{
    public class MainBlazorView : BlazorView<MainViewModel>
    {
        public override string ViewPath { get; } = "";
    }
}
