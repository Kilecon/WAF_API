namespace WAF_API_Domain.Note.Entities
{
    using WAF_API_Domain.Note.Dtos;
    using WAF_API_Domain.Note.ValueObject;
    using WAF_API_Domain.ValueObject;

    /// <summary>
    /// Defines the <see cref="ChallengeAr" />
    /// </summary>
    public class ChallengeAr
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
        /// Gets the IsChecked
        /// </summary>
        public IsChecked IsChecked { get; private set; }

        /// <summary>
        /// Gets the LastUpdateUnixTimestamp
        /// </summary>
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChallengeAr"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="Id"/></param>
        /// <param name="title">The title<see cref="Title"/></param>
        /// <param name="description">The description<see cref="Description"/></param>
        /// <param name="isChecked">The isChecked<see cref="IsChecked"/></param>
        public ChallengeAr(Id id, Title title, Description description, IsChecked isChecked)
        {
            Id = id;
            Title = title;
            Description = description;
            IsChecked = isChecked;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChallengeAr"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="Id"/></param>
        /// <param name="title">The title<see cref="Title"/></param>
        /// <param name="description">The description<see cref="Description"/></param>
        public ChallengeAr(Id id, Title title, Description description)
        {
            Id = id;
            Title = title;
            Description = description;
            IsChecked = new IsChecked(false);
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        /// <summary>
        /// The ToDto
        /// </summary>
        /// <returns>The <see cref="ChallengeDto"/></returns>
        public ChallengeDto ToDto()
        {
            return new ChallengeDto
            {
                Id = Id.Value,
                Title = Title.Value,
                Description = Description.Value,
                IsCheked = IsChecked.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
