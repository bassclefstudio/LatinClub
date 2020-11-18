using BassClefStudio.LatinClub.Core.News;
using BassClefStudio.NET.Api;
using BassClefStudio.NET.Core;
using BassClefStudio.NET.Sync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Uno.Data
{
    public class ArticleLink : ILink<Article>
    {
        public int Id { get; }
        public ArticleLink(int id)
        {
            Id = id;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(ISyncItem<Article> item, ISyncInfo<Article> info = null)
        {
            Article updated = null;
            if (info is ArticleSyncCollectionInfo syncInfo)
            {
                updated = syncInfo.Articles.Get(Id);
            }
            else
            {
                using (var service = new ApiService())
                {
                    updated = await service.GetAsync<Article>($"{ClubContext.ApiUrl}/articles/{Id}");
                }
            }

            if (item.Item == null)
            {
                item.Item = updated;
            }
            else
            {
                item.Item.Title = updated.Title;
                item.Item.PublishTime = updated.PublishTime;
                item.Item.Type = updated.Type;
            }
        }

        /// <inheritdoc/>
        public async Task PushAsync(ISyncItem<Article> item, ISyncInfo<Article> info = null)
        {
            using (var service = new ApiService())
            {
                //service.PatchAsync<Article>($"{ClubContext.ApiUrl}/events/{Id}");
            }
        }
    }

    /// <inheritdoc/>
    public class ArticleSyncItem : KeyedSyncItem<Article, int>
    {
        /// <inheritdoc/>
        public ArticleSyncItem(Article item, ILink<Article> link = null) : base(item, link)
        { }

        /// <inheritdoc/>
        public ArticleSyncItem(ILink<Article> link = null) : base(link)
        { }
    }

    /// <inheritdoc/>
    public class ArticleSyncCollection : SyncCollection<Article, int>
    {
        /// <inheritdoc/>
        protected override IKeyedSyncItem<Article, int> CreateSyncItem(ILink<Article> link)
        {
            Debug.WriteLine("Creating SyncItem...");
            return new ArticleSyncItem(link);
        }

        /// <inheritdoc/>
        protected override async Task<ISyncCollectionInfo<Article, int>> GetCollectionInfo()
        {
            Debug.WriteLine("Getting collection info...");
            using (var service = new ApiService())
            {
                var articles = await service.GetAsync<Article[]>($"{ClubContext.ApiUrl}/articles");
                Debug.WriteLine($"Retrieved {articles.Length} articles in collection info.");
                return new ArticleSyncCollectionInfo(articles);
            }
        }

        /// <inheritdoc/>
        protected override ILink<Article> GetLink(int key)
        {
            return new ArticleLink(key);
        }
    }

    public class ArticleSyncCollectionInfo : ISyncCollectionInfo<Article, int>
    {
        /// <inheritdoc/>
        public IEnumerable<int> GetKeys() => Articles.Select(a => a.Id);

        /// <summary>
        /// A collection of returned <see cref="Article"/>s.
        /// </summary>
        public IEnumerable<Article> Articles { get; }

        /// <summary>
        /// Creates a new <see cref="ArticleSyncCollectionInfo"/> from the given keys.
        /// </summary>
        /// <param name="articles">A collection of <see cref="Article"/> items in the collection.</param>
        public ArticleSyncCollectionInfo(IEnumerable<Article> articles)
        {
            Articles = articles;
        }
    }
}
