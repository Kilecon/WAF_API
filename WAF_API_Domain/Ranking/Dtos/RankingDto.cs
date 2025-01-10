using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;

namespace WAF_API_Domain.Ranking.Models
{
    public class RankingDto : Dto
    {
        public string QuestionId { get; set; }
        public string QuestionTypeName { get; set; }
        public bool IsLiked { get; set; }
    }
}
