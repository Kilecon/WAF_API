namespace WAF_API_Infrastructure.Repositories
{
    using MongoDB.Driver;
    using WAF_API_Application.Services;
    using WAF_API_Application.Services.RatingService;
    using WAF_API_Domain.Rating.Dtos;

    /// <summary>
    /// Defines the <see cref="RatingRepository" />
    /// </summary>
    public class RatingRepository(IMongoDatabase database) : BaseRepository<RatingDto>(database), IRatingRepository
    {
    }
}
