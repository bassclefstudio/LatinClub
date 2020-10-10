using BassClefStudio.LatinClub.Core.Events;
using BassClefStudio.NET.Api;
using BassClefStudio.NET.Core;
using BassClefStudio.NET.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Uno.Data
{
    public class EventLink : ILink<ClubEvent>
    {
        public int Id { get; }
        public EventLink(int id)
        {
            Id = id;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(ISyncItem<ClubEvent> item, ISyncInfo<ClubEvent> info = null)
        {
            ClubEvent updated = null;
            if (info is EventSyncCollectionInfo syncInfo)
            {
                updated = syncInfo.Events.Get(Id);
            }
            else
            {
                using (var service = new ApiService())
                {
                    updated = await service.GetAsync<ClubEvent>($"{ClubContext.ApiUrl}/events/{Id}");
                }
            }

            if (item.Item == null)
            {
                item.Item = updated;
            }
            else
            {
                item.Item.Name = updated.Name;
                item.Item.StartTime = updated.StartTime;
                item.Item.Type = updated.Type;
            }
        }

        /// <inheritdoc/>
        public async Task PushAsync(ISyncItem<ClubEvent> item, ISyncInfo<ClubEvent> info = null)
        {
            using (var service = new ApiService())
            {
                //service.PatchAsync<Article>($"{ClubContext.ApiUrl}/events/{Id}");
            }
        }
    }

    public class EventSyncCollection : SyncCollection<ClubEvent, int>
    {
        /// <inheritdoc/>
        protected override async Task<ISyncCollectionInfo<ClubEvent, int>> GetCollectionInfo()
        {
            using (var service = new ApiService())
            {
                var events = await service.GetAsync<IEnumerable<ClubEvent>>($"{ClubContext.ApiUrl}/events");
                // Actually include some of the data here at this point.
                return new EventSyncCollectionInfo(events);
            }
        }

        /// <inheritdoc/>
        protected override ILink<ClubEvent> GetLink(int key)
        {
            return new EventLink(key);
        }
    }

    public class EventSyncCollectionInfo : ISyncCollectionInfo<ClubEvent, int>
    {
        /// <inheritdoc/>
        public IEnumerable<int> GetKeys() => Events.Select(a => a.Id);

        /// <summary>
        /// A collection of returned <see cref="Article"/>s.
        /// </summary>
        public IEnumerable<ClubEvent> Events { get; }

        /// <summary>
        /// Creates a new <see cref="ArticleSyncCollectionInfo"/> from the given keys.
        /// </summary>
        /// <param name="events">A collection of <see cref="ClubEvent"/> items in the collection.</param>
        public EventSyncCollectionInfo(IEnumerable<ClubEvent> events)
        {
            Events = events;
        }
    }
}
