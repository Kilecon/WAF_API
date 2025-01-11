using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Commands;

namespace WAF_API_Domain.Suggestion.Commands
{
    public class CreateSuggestionCmd : Cmd
    {
        public string? QuestionLang { get; set; }

        public string? QuestionSuggested { get; set; }
        public string? Comment {  get; set; }
    }
}
