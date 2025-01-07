using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;
using WAF_API_Domain.Ranking.Commands;
using WAF_API_Domain.Ranking.Models;

namespace WAF_API_Application.Services.Ranking
{
    public interface IRankingService : IService<RankingDto, CreateRankingCmd, UpdateRankingCmd>
    {
        Task UpdateAsync(UpdateRankingCmd note);
        Task<IEnumerable<RankingDto>> GetByQuestionIdAsync(string id);
    }
}
