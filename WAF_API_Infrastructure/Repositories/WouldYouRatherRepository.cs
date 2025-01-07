using MongoDB.Driver;
using WAF_API_Application.Services.DareService;
using WAF_API_Application.Services.WouldYouRatherService;
using WAF_API_Domain.Dare.Dtos;
using WAF_API_Domain.WouldYouRather.Dtos;

namespace WAF_API_Infrastructure.Repositories;

    /// <summary>
    /// Defines the <see cref="WouldYouRatherRepository" />
    /// </summary>
    public class WouldYouRatherRepository(IMongoDatabase database) : BaseRepository<WouldYouRatherDto>(database), IWouldYouRatherRepository
    {
    }