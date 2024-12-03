namespace WAF_API_Application.Services.RatingService
{
    using WAF_API_Application.Services;
    using WAF_API_Domain.Rating.Dtos;

    /// <summary>
    /// Defines the <see cref="IRatingRepository" />
    /// </summary>
    public interface IRatingRepository : IBaseRepository<RatingDto>
    {
    }
}
