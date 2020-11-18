using BassClefStudio.LatinClub.Uno.ViewModels;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;

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
            this.DataContext = ViewModel;

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            Windows.UI.Color titleColor = (Windows.UI.Color)Resources["SystemChromeMediumColor"];
            titleBar.BackgroundColor = titleColor;
            titleBar.ButtonBackgroundColor = titleColor;
            this.InitializeComponent();
        }
    }
}
