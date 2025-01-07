using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAF_API_Domain.Ranking.ValueObject
{
    public class IsLiked
    {
        public bool Value { get; set; }
        public IsLiked(bool isLiked) 
        {
            Value = isLiked;
        }
    }
}
