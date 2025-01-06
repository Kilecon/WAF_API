using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Ranking.Commands;

namespace WAF_API_Domain.Ranking.Factory
{
    public interface IRankingFactory
    {
        object CreateIntance(CreateRankingCmd cmd, string id);
        object UpdateIntance(UpdateRankingCmd cmd);
    }
}
