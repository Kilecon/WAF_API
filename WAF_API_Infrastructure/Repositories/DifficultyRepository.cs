using MongoDB.Driver;
using WAF_API_Application.Services.DareService;
using WAF_API_Application.Services.Difficulty;
using WAF_API_Application.Services.DifficultyService;
using WAF_API_Domain.Difficulty.Dtos;
using WAF_API_Domain.Difficulty.Factory;

namespace WAF_API_Infrastructure.Repositories
{

    /// <summary>
    /// Defines the <see cref="DifficultyRepository" />
    /// </summary>
    public class DifficultyRepository(IMongoDatabase database) : BaseRepository<DifficultyDto>(database), IDifficultyRepository
    {
    }
}
