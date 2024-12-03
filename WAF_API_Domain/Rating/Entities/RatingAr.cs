namespace WAF_API_Domain.Rating.Entities
{
    using WAF_API_Domain.Rating.Dtos;
    using WAF_API_Domain.Rating.ValueObject;
    using WAF_API_Domain.ValueObject;

    /// <summary>
    /// Defines the <see cref="RatingAr" />
    /// </summary>
    public class RatingAr
    {
        public Id Id { get; private set; }
        public Id SentenceId { get; private set; }
        public Rating Rating { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }

        public RatingAr(Id id, Id sentenceId, Rating rating)
        {
            Id = id;
            SentenceId = sentenceId;
            Rating = rating;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public RatingDto ToDto()
        {
            return new RatingDto
            {
                Id = Id.Value,
                SentenceId = SentenceId.Value,
                Rating = Rating.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
