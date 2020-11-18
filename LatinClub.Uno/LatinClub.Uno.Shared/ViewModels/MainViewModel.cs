using BassClefStudio.LatinClub.Uno.Helpers;
using BassClefStudio.NET.Core;
using System;
using System.Collections.Generic;
using System.Text;
using BassClefStudio.LatinClub.Uno.Data;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Toolkit.Uwp.UI;
using System.Collections;
using System.Windows.Input;
using BassClefStudio.LatinClub.Core.Events;

namespace BassClefStudio.LatinClub.Uno.ViewModels
{
    public class MainViewModel : Observable
    {
        private ClubContext context;
        public ClubContext Context { get => context; set => Set(ref context, value); }

        public AdvancedCollectionView EventsView { get; }

        public MainViewModel()
        {
            Context = new ClubContext();
            EventsView = new AdvancedCollectionView(Context.Events.Item as IList);
            SetCommand = new RelayCommandBuilder(Set).Command;
        }

        public ICommand SetCommand { get; }

        public async Task Set()
        {
            Debug.WriteLine("Updating values...");
            try
            {
                //await Context.Events.UpdateAsync();
                Context.Events.Item.Add(new EventSyncItem(new ClubEvent() { Id = 0, Name = "Hello World!" }));
                Debug.WriteLine($"Found {Context.Events.Item.Count} items.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception thrown: {ex}");
            }
        }
    }
}
