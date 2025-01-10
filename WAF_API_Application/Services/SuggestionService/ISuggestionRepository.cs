using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Suggestion.Dtos;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Application.Services.SuggestionService
{
    public interface ISuggestionRepository<SuggestionDto>
    {
        Task<SuggestionDto> AddAsync(SuggestionDto item);
        Task DeleteByIdAsync(string id);
        Task<SuggestionDto> GetItemById(string id);
        Task<IEnumerable<SuggestionDto>> GetItems();
    }
}
