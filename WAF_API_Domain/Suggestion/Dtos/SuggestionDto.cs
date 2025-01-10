using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;

namespace WAF_API_Domain.Suggestion.Dtos
{
    public class SuggestionDto : Dto
    {
        public string? QuestionLang { get; set; }
        public string? QuestionSuggested { get; set; }
        public string? Comment {  get; set; }
    }
}
