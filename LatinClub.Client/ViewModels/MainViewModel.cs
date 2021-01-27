using BassClefStudio.AppModel.Lifecycle;
using BassClefStudio.AppModel.Navigation;
using BassClefStudio.AppModel.Threading;
using BassClefStudio.LatinClub.Core.Events;
using BassClefStudio.LatinClub.Core.News;
using BassClefStudio.NET.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Client.ViewModels
{
    public class MainViewModel : Observable, IViewModel, IActivationHandler
    {
        /// <summary>
        /// The current version of the app, as a human-readable <see cref="Version"/>.
        /// </summary>
        public Version AppVersion { get; } = typeof(MainViewModel).Assembly.GetName().Version;

        /// <inheritdoc/>
        public bool Enabled { get; } = true;

        /// <summary>
        /// A collection of upcoming <see cref="ClubEvent"/>s to show.
        /// </summary>
        public ObservableCollection<ClubEvent> Events { get; }

        /// <summary>
        /// A collection of available <see cref="Article"/>s to show.
        /// </summary>
        public ObservableCollection<Article> Articles { get; }

        internal IDispatcherService DispatcherService;
        public MainViewModel(IDispatcherService dispatcherService)
        {
            DispatcherService = dispatcherService;
            Events = new ObservableCollection<ClubEvent>();
            Articles = new ObservableCollection<Article>();
        }

        public void Activate(IActivatedEventArgs args)
        { }

        public bool CanHandle(IActivatedEventArgs args)
        {
            return args is LaunchActivatedEventArgs;
        }

        public async Task InitializeAsync()
        {
            await DispatcherService.RunOnUIThreadAsync(() =>
            {
                Events.Add(new ClubEvent()
                {
                    Id = 0,
                    Name = "Hello World!",
                    Description = "This is a test.",
                    Type = EventType.Activity,
                    StartTime = DateTimeOffset.Now + new TimeSpan(2, 0, 0)
                });

                Events.Add(new ClubEvent()
                {
                    Id = 1,
                    Name = "Another Club Meeting.",
                    Description = "We'll be meeting today at 3pm.",
                    Type = EventType.Meeting,
                    StartTime = DateTimeOffset.Now.Date + new TimeSpan(15, 0, 0)
                });

                Events.Add(new ClubEvent()
                {
                    Id = 2,
                    Name = "Test 3.",
                    Description = "This is a test.",
                    Type = EventType.Meeting,
                    StartTime = DateTimeOffset.Now + new TimeSpan(6, 0, 0)
                });

                Events.Add(new ClubEvent()
                {
                    Id = 3,
                    Name = "Test 4.",
                    Description = "This is a test.",
                    Type = EventType.Meeting,
                    StartTime = DateTimeOffset.Now - new TimeSpan(12, 0, 0)
                });

                Events.Add(new ClubEvent()
                {
                    Id = 4,
                    Name = "Test 5.",
                    Description = "This is a test.",
                    Type = EventType.Meeting,
                    StartTime = DateTimeOffset.Now + new TimeSpan(8, 0, 0)
                });

                Articles.Add(new Article()
                {
                    Id = 0,
                    Author = "Decklan S",
                    Title = "Latin Club Website Released!",
                    Type = ArticleType.Newsletter,
                    PublishTime = DateTimeOffset.Now,
                    Content = "Looks like the new website for the RHS Latin Club was released! _Let's take a look!_"
                });
            });
        }
    }
}
