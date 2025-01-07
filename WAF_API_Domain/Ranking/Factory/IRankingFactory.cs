using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Entities;
using WAF_API_Domain.Ranking.Commands;
using WAF_API_Domain.Ranking.Entities;

namespace WAF_API_Domain.Ranking.Factory
{
    public interface IRankingFactory
    {
        public RankingAr CreateIntance(CreateRankingCmd cmd, string id);
        public RankingAr UpdateIntance(UpdateRankingCmd cmd);
    }
}
