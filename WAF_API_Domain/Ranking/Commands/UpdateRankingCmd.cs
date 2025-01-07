using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Commands;

namespace WAF_API_Domain.Ranking.Commands
{
    public class UpdateRankingCmd : IdCmd
    {
        public string QuestionId { get; set; }
        public string QuestionTypeName { get; set; }
        public bool IsLiked { get; set; }
    }
}
