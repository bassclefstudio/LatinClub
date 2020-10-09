using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using BassClefStudio.LatinClub.Uno.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BassClefStudio.LatinClub.Uno
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; set; }

        public MainPage()
        {
            ViewModel = new MainViewModel();

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            Windows.UI.Color titleColor = (Windows.UI.Color)Resources["SystemChromeMediumColor"];
            titleBar.BackgroundColor = titleColor;
            titleBar.ButtonBackgroundColor = titleColor;

            this.InitializeComponent();
        }
    }
}
