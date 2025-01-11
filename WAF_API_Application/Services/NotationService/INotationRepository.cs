using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;
using WAF_API_Domain.Notation.Dtos;

namespace WAF_API_Application.Services.NotationService
{
    public interface INotationRepository<NotationDto>
    {
        Task<IEnumerable<NotationDto>> GetDareItems();
        Task<IEnumerable<NotationDto>> GetParanoiaItems();
        Task<IEnumerable<NotationDto>> GetNeverHaveIEverItems();
        Task<IEnumerable<NotationDto>> GetTruthItems();
        Task<IEnumerable<NotationDto>> GetWouldYouRatherItems();
        Task<IEnumerable<NotationDto>> GetByQuestionId(string questionId);
        Task<NotationDto> GetItemById(string id);
        Task<NotationDto> AddAsync(NotationDto item);
        Task DeleteByIdAsync(string id);
        Task WatchForChanges();
    }
}