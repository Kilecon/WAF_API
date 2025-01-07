using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAF_API_Domain.Ranking.ValueObject
{
    public class QuestionTypeName
    {
        public string Value { get; set; }
        public QuestionTypeName(string typeName) 
        { 
            // TODO
            Value = typeName;
        }
    }
}
