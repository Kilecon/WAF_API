namespace WAF_API_Application.Services.RatingService
{
    using WAF_API_Domain.Rating.Commands;
    using WAF_API_Domain.Rating.Dtos;
    using System.Threading.Tasks;
    using WAF_API_Application.Services;

    /// <summary>
    /// Defines the <see cref="IRatingService" />
    /// </summary>
    public interface IRatingService : IService<RatingDto, CreateRatingCmd, UpdateRatingCmd>
    {
        /// <summary>
        /// The UpdateAsync
        /// </summary>
        /// <param name="comment">The comment<see cref="UpdateRatingCmd"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task UpdateAsync(UpdateRatingCmd comment);
    }
}
