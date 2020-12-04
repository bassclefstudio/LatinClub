using BassClefStudio.AppModel.Lifecycle;
using BassClefStudio.AppModel.Navigation;
using BassClefStudio.NET.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Client.ViewModels
{
    public class MainViewModel : Observable, IViewModel, IActivationHandler
    {
        public bool Enabled { get; } = true;

        public void Activate(IActivatedEventArgs args)
        { }

        public bool CanHandle(IActivatedEventArgs args)
        {
            return args is LaunchActivatedEventArgs;
        }

        public async Task InitializeAsync()
        { }
    }
}
