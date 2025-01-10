using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Suggestion.Dtos;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.Suggestion.Entities
{
    public class SuggestionAr
    {
        public Id Id { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        
        public QuestionLang QuestionLang { get; private set; }
        public QuestionSuggested QuestionSuggested { get; private set; }

        public Comment Comment { get; private set; }
        public SuggestionAr(Id id, QuestionLang questionLang, QuestionSuggested questionSuggested, Comment comment) 
        {
            Id = id;
            QuestionLang = questionLang;
            QuestionSuggested = questionSuggested;
            Comment = comment;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public SuggestionDto ToDto()
        {
            return new SuggestionDto
            {
                Id = Id.Value,
                QuestionLang = QuestionLang.Value,
                QuestionSuggested = QuestionSuggested.Value,
                Comment = Comment.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}