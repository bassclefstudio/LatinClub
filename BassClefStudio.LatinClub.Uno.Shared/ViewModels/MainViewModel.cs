using BassClefStudio.LatinClub.Uno.Helpers;
using BassClefStudio.NET.Core;
#if NETFX_CORE
using Microsoft.UI.Xaml.Input;
#else
using System.Windows.Input;
#endif
using System;
using System.Collections.Generic;
using System.Text;

namespace BassClefStudio.LatinClub.Uno.ViewModels
{
    public class MainViewModel : Observable
    {
        private string textOut;
        public string TextOut { get => textOut; set => Set(ref textOut, value); }

        private string textIn;
        public string TextIn { get => textIn; set => Set(ref textIn, value); }

        public MainViewModel()
        {
            SetCommand = new RelayCommandBuilder(Set).Command;
        }

        public ICommand SetCommand { get; }

        public void Set()
        {
            TextOut = TextIn;
        }
    }
}
