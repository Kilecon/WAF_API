using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAF_API_Domain.ValueObject
{
    public class QuestionEn
    {
        public string Value { get; set; }
        public QuestionEn(string Sentence)
        {
            // formatter la string
            Value = Sentence;
        }
    }
}
