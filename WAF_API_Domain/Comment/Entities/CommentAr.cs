namespace WAF_API_Domain.Comment.Entities
{
    using WAF_API_Domain.Comment.Dtos;
    using WAF_API_Domain.Comment.ValueObject;
    using WAF_API_Domain.ValueObject;

    /// <summary>
    /// Defines the <see cref="CommentAr" />
    /// </summary>
    public class CommentAr
    {
        /// <summary>
        /// Gets the Id
        /// </summary>
        public Id Id { get; private set; }

        /// <summary>
        /// Gets the Title
        /// </summary>
        public Title Title { get; private set; }

        /// <summary>
        /// Gets the Description
        /// </summary>
        public Description Description { get; private set; }

        /// <summary>
        /// Gets the LastUpdateUnixTimestamp
        /// </summary>
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentAr"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="Id"/></param>
        /// <param name="title">The title<see cref="Title"/></param>
        /// <param name="description">The description<see cref="Description"/></param>
        public CommentAr(Id id, Title title, Description description)
        {
            Id = id;
            Title = title;
            Description = description;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        /// <summary>
        /// The ToDto
        /// </summary>
        /// <returns>The <see cref="CommentDto"/></returns>
        public CommentDto ToDto()
        {
            return new CommentDto
            {
                Id = Id.Value,
                Title = Title.Value,
                Description = Description.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
