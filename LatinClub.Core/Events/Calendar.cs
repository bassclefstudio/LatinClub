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
    /// Represents a club calendar, with a collection of <see cref="ClubEvent"/>s that can be queried.
    /// </summary>
    public class Calendar
    {
        /// <summary>
        /// An <see cref="ObservableCollection{T}"/> allowing for dynamic manipulation of the <see cref="ClubEvent"/>s in the <see cref="Calendar"/>.
        /// </summary>
        public ObservableCollection<ClubEvent> EventCollection { get; }

        /// <summary>
        /// Creates an empty <see cref="Calendar"/>.
        /// </summary>
        public Calendar() 
        {
            EventCollection = new ObservableCollection<ClubEvent>();
        }

        /// <summary>
        /// Creates a new <see cref="Calendar"/>.
        /// </summary>
        /// <param name="events">A collection of <see cref="ClubEvent"/>s on the <see cref="Calendar"/>.</param>
        public Calendar(IEnumerable<ClubEvent> events)
        {
            EventCollection = new ObservableCollection<ClubEvent>(events);
        }
    }
}
