using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Suggestion.Commands;
using WAF_API_Domain.Suggestion.Entities;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.Suggestion.Factory
{
    public class SuggestionFactory : ISuggestionFactory
    {
        public SuggestionAr CreateIntance(CreateSuggestionCmd cmd, string id)
        {
            try
            {
                return new SuggestionAr(new Id(id), 
                    new QuestionLang(cmd.QuestionLang), 
                    new QuestionSuggested(cmd.QuestionSuggested),
                    new Comment(cmd.Comment));
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateSuggestionCmd)}\" Command is Invalid");
            }
        }
    }
}
