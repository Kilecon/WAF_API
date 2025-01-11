using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;
using WAF_API_Domain.Notation.Commands;
using WAF_API_Domain.Notation.Dtos;

namespace WAF_API_Application.Services.NotationService
{
    public interface INotationService : IService<NotationDto, CreateNotationCmd, UpdateNotationCmd>
    {
        Task UpdateAsync(UpdateNotationCmd note);
        Task<IEnumerable<NotationDto>> GetByQuestionIdAsync(string id);
        Task<IEnumerable<NotationDto>> GetDareItemsAsync();
        Task<IEnumerable<NotationDto>> GetParanoiaItemsAsync();
        Task<IEnumerable<NotationDto>> GetNeverHaveIEverItemsAsync();
        Task<IEnumerable<NotationDto>> GetTruthItemsAsync();
        Task<IEnumerable<NotationDto>> GetWouldYouRatherItemsAsync();
    }
}
