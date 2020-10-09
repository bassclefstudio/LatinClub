using System;
using System.Collections.Generic;
using System.Text;

namespace BassClefStudio.LatinClub.Core.News
{
    /// <summary>
    /// Represents a club news article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Primary key for this <see cref="Article"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the <see cref="Article"/>.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The name of the author of the <see cref="Article"/>.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// A <see cref="DateTimeOffset"/> representing the date and time the <see cref="Article"/> was published.
        /// </summary>
        public DateTimeOffset PublishTime { get; set; }

        /// <summary>
        /// The content of the <see cref="Article"/>, written in Markdown format.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// An <see cref="ArticleType"/> representing the category this <see cref="Article"/> falls under.
        /// </summary>
        public ArticleType Type { get; set; }
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
