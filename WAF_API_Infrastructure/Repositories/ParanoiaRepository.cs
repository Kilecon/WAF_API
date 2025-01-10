using WAF_API_Application.Services.ParanoiaService;
using MongoDB.Driver;
using WAF_API_Domain.Paranoia.Dtos;

namespace WAF_API_Infrastructure.Repositories
{
    /// <summary>
    /// Defines the <see cref="ParanoiaRepository" />
    /// </summary>
    public class ParanoiaRepository(IMongoDatabase database) : BaseRepository<SuggestionDto>(database), IParanoiaRepository
    {
    }
}
