using System;
using System.Collections.Generic;
using System.Text;

namespace BassClefStudio.LatinClub.Core.Events
{
    /// <summary>
    /// Represents an activity, meeting, or other event that could be present on a calendar.
    /// </summary>
    public class ClubEvent
    {
        /// <summary>
        /// Primary key for this <see cref="ClubEvent"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A <see cref="DateTimeOffset"/> representing the date and time when the <see cref="ClubEvent"/> occurs.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// The name of the <see cref="ClubEvent"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Additional information about the <see cref="ClubEvent"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// An <see cref="EventType"/> describing the function of this <see cref="ClubEvent"/>.
        /// </summary>
        public EventType Type { get; set; }
    }

    /// <summary>
    /// An enum representing the function/category of an <see cref="ClubEvent"/>.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// The <see cref="ClubEvent"/> is a meeting of members at a specified time.
        /// </summary>
        Meeting = 0,
        /// <summary>
        /// The <see cref="ClubEvent"/> is a presentation by one or more people or a showing of media.
        /// </summary>
        Presentation = 1,
        /// <summary>
        /// The <see cref="ClubEvent"/> is an activity, game, or competition.
        /// </summary>
        Activity = 2,
        /// <summary>
        /// The <see cref="ClubEvent"/> is the due date of an assignment (i.e. something that needs to be done or submitted).
        /// </summary>
        Assignment = 3
    }
}
