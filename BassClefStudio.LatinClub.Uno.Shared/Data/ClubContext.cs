using BassClefStudio.LatinClub.Core.Events;
using BassClefStudio.LatinClub.Core.News;
using BassClefStudio.NET.Core;
using BassClefStudio.NET.Sync;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Uno.Data
{
    public class ClubContext
    {
        public const string ApiUrl = "http://localhost:59525/api";

        public ISyncCollection<IKeyedSyncItem<ClubEvent, int>> Events { get; }
        public ISyncCollection<IKeyedSyncItem<Article, int>> Articles { get; }

        public ClubContext()
        {
            Events = new EventSyncCollection();
            Articles = new ArticleSyncCollection();
        }

        public async Task InitializeAsync()
        {
            await new Task[]
            {
                Events.UpdateAsync(),
                Articles.UpdateAsync()
            }.RunParallelAsync();
        }
    }
}
