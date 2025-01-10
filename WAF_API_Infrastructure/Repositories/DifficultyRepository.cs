using MongoDB.Driver;
using WAF_API_Application.Services.DifficultyService;
using WAF_API_Domain.Difficulty.Dtos;

namespace WAF_API_Infrastructure.Repositories
{

    /// <summary>
    /// Defines the <see cref="DifficultyRepository" />
    /// </summary>
    public class DifficultyRepository(IMongoDatabase database) : BaseRepository<DifficultyDto>(database), IDifficultyRepository
    {
    }
}
