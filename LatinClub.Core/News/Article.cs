using BassClefStudio.NET.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BassClefStudio.LatinClub.Core.News
{
    /// <summary>
    /// Represents a club news article.
    /// </summary>
    public class Article : Observable, IIdentifiable<int>
    {
        /// <summary>
        /// Primary key for this <see cref="Article"/>.
        /// </summary>
        public int Id { get; set; }

        private string title;
        /// <summary>
        /// The name of the <see cref="Article"/>.
        /// </summary>
        public string Title { get => title; set => Set(ref title, value); }

        private string author;
        /// <summary>
        /// The name of the author of the <see cref="Article"/>.
        /// </summary>
        public string Author { get => author; set => Set(ref author, value); }

        private DateTimeOffset publishTime;
        /// <summary>
        /// A <see cref="DateTimeOffset"/> representing the date and time the <see cref="Article"/> was published.
        /// </summary>
        public DateTimeOffset PublishTime { get => publishTime; set => Set(ref publishTime, value); }

        private string content;
        /// <summary>
        /// The content of the <see cref="Article"/>, written in Markdown format.
        /// </summary>
        public string Content { get => content; set => Set(ref content, value); }

        private ArticleType type;
        /// <summary>
        /// An <see cref="ArticleType"/> representing the category this <see cref="Article"/> falls under.
        /// </summary>
        public ArticleType Type { get => type; set => Set(ref type, value); }
    }

    /// <summary>
    /// An enum representing the function/category of an <see cref="Article"/>.
    /// </summary>
    public enum ArticleType
    {
        /// <summary>
        /// The <see cref="Article"/> is a short announcement or reminder.
        /// </summary>
        Announcement = 0,
        /// <summary>
        /// The <see cref="Article"/> is a short, fun fact.
        /// </summary>
        Fact = 1,
        /// <summary>
        /// The <see cref="Article"/> is club-related news or information that is not a direct announcement.
        /// </summary>
        Newsletter = 2
    }
}
