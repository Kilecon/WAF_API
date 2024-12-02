using WAF_API_Domain.Note.Commands;
using WAF_API_Domain.Note.Dtos;
using System.Threading.Tasks;
using WAF_API_Application.Services;

namespace WAF_API_Application.Services.NoteService
{
    public interface IChallengeService : IService<ChallengeDto, CreateChallengeCmd, UpdateChallengeCmd>
    {
        Task UpdateAsync(UpdateChallengeCmd note);
    }
}
