using System;
using System.Collections.Generic;
using System.Text;

namespace BassClefStudio.LatinClub.Core.Events
{
    /// <summary>
    /// Represents an activity, meeting, or other event that could be present on a calendar.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// The time the <see cref="Event"/> begins.
        /// </summary>
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// The name of the <see cref="Event"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Additional information about the <see cref="Event"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The <see cref="EventType"/> describing the function of this <see cref="Event"/>.
        /// </summary>
        public EventType Type { get; set; }
    }

    /// <summary>
    /// An enum representing the function/category of an <see cref="Event"/>.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// The <see cref="Event"/> is a meeting of members at a specified time.
        /// </summary>
        Meeting = 0,
        /// <summary>
        /// The <see cref="Event"/> is a presentation by one or more people or a showing of media.
        /// </summary>
        Presentation = 1,
        /// <summary>
        /// The <see cref="Event"/> is an activity, game, or competition.
        /// </summary>
        Activity = 2,
        /// <summary>
        /// The <see cref="Event"/> is the due date of an assignment (i.e. something that needs to be done or submitted).
        /// </summary>
        Assignment = 3
    }
}
