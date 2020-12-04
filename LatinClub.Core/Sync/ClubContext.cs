using BassClefStudio.LatinClub.Core.Events;
using BassClefStudio.LatinClub.Core.News;
using BassClefStudio.NET.Core;
using BassClefStudio.NET.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Core.Sync
{
    public class ClubContext
    {
        public const string ApiUrl = "http://localhost:59525/api";

        public SyncCollection<ClubEvent, int> Events { get; }
        public SyncCollection<Article, int> Articles { get; }

        public ClubContext()
        {
            Events = new EventSyncCollection();
            Articles = new ArticleSyncCollection();
        }
    }
}
