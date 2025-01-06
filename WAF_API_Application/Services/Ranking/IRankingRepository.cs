using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Ranking.Models;

namespace WAF_API_Application.Services.Ranking
{
    public interface IRankingRepository
    {
        Task<IEnumerable<RankingDto>> GetItems();
        Task<RankingDto?> GetItemById(string id);
        Task<RankingDto?> AddAsync(RankingDto item);
        Task UpdateAsync(RankingDto item);
        Task DeleteByIdAsync(string id);
    }
}
