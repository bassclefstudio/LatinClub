using BassClefStudio.NET.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace BassClefStudio.LatinClub.Core.Events
{
    /// <summary>
    /// Represents a club calendar, with a collection of <see cref="Event"/>s that can be queried.
    /// </summary>
    public class Calendar
    {
        /// <summary>
        /// The full collection of <see cref="Event"/>s happening on this <see cref="Calendar"/>.
        /// </summary>
        public IEnumerable<Event> Events { get => EventCollection.AsEnumerable(); set { EventCollection.Clear(); EventCollection.AddRange(value); } }

        /// <summary>
        /// An <see cref="ObservableCollection{T}"/> allowing for dynamic manipulation of the <see cref="Event"/>s in the <see cref="Calendar"/>.
        /// </summary>
        [JsonIgnore]
        public ObservableCollection<Event> EventCollection { get; }

        public Calendar() 
        {
            EventCollection = new ObservableCollection<Event>();
        }

        /// <summary>
        /// Creates a new <see cref="Calendar"/>.
        /// </summary>
        /// <param name="events">A collection of <see cref="Event"/>s on the <see cref="Calendar"/>.</param>
        public Calendar(IEnumerable<Event> events) : this()
        {
            Events = events;
        }
    }
}
