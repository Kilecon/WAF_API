using WAF_API_Application.Services.TruthService;
using MongoDB.Driver;
using WAF_API_Domain.Truth.Dtos;

namespace WAF_API_Infrastructure.Repositories
{
    /// <summary>
    /// Defines the <see cref="DareRepository" />
    /// </summary>
    public class TruthRepository(IMongoDatabase database) : BaseRepository<TruthDto>(database), ITruthRepository
    {
    }
}
