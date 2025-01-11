using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Commands;
using WAF_API_Domain.Suggestion.Commands;
using WAF_API_Domain.Suggestion.Dtos;

namespace WAF_API_Application.Services.SuggestionService
{
    public interface ISuggestionService : IService<SuggestionDto, CreateSuggestionCmd, IdCmd>
    {
        
    }
}