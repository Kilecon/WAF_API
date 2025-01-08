using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;
using WAF_API_Domain.Ranking.Models;

namespace WAF_API_Application.Services.Ranking
{
    public interface IRankingRepository<RankingDto>
    {
        Task<IEnumerable<RankingDto>> GetDareItems();
        Task<IEnumerable<RankingDto>> GetParanoiaItems();
        Task<IEnumerable<RankingDto>> GetNeverHaveIEverItems();
        Task<IEnumerable<RankingDto>> GetTruthItems();
        Task<IEnumerable<RankingDto>> GetWouldYouRatherItems();
        Task<IEnumerable<RankingDto>> GetByQuestionId(string questionId);
        Task<RankingDto> GetItemById(string id);
        Task<RankingDto> AddAsync(RankingDto item);
        Task DeleteByIdAsync(string id);
        Task WatchForChanges();
    }
}