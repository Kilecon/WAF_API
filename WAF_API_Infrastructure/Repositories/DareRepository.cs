using MongoDB.Driver;
using WAF_API_Application.Services.DareService;
using WAF_API_Domain.Dare.Dtos;

namespace WAF_API_Infrastructure.Repositories
{

    /// <summary>
    /// Defines the <see cref="DareRepository" />
    /// </summary>
    public class DareRepository(IMongoDatabase database) : BaseRepository<DareDto>(database), IDareRepository
    {
    }
}
