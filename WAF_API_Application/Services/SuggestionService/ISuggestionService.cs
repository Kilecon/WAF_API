using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services;
using WAF_API_Domain.Commands;
using WAF_API_Domain.Paranoia.Commands;
using WAF_API_Domain.Paranoia.Dtos;
using WAF_API_Domain.Suggestion.Commands;

namespace WAF_API_Application.Services.SuggestionService
{
    public interface ISuggestionService : IService<SuggestionDto, CreateSuggestionCmd, UpdateSuggestionCmd>
    {
    }

    public class UpdateSuggestionCmd : IdCmd
    {
    }
}