namespace WAF_API_Domain.Rating.Factory
{
    using WAF_API_Domain.Rating.Commands;
    using WAF_API_Domain.Rating.Entities;

    /// <summary>
    /// Defines the <see cref="IRatingFactory" />
    /// </summary>
    public interface IRatingFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateRatingCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="RatingAr"/></returns>
        RatingAr CreateIntance(CreateRatingCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateRatingCmd"/></param>
        /// <returns>The <see cref="RatingAr"/></returns>
        RatingAr UpdateIntance(UpdateRatingCmd cmd);
    }
}
