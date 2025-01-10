using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Suggestion.Commands;
using WAF_API_Domain.Suggestion.Entities;

namespace WAF_API_Domain.Suggestion.Factory
{
    public interface ISuggestionFactory
    {
        public SuggestionAr CreateIntance(CreateSuggestionCmd cmd, string id);
        
    }
}
