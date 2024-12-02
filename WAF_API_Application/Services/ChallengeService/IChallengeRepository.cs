using WAF_API_Domain.Note.Dtos;
using WAF_API_Application.Services;


namespace WAF_API_Application.Services.NoteService
{
    public interface IChallengeRepository : IBaseRepository<ChallengeDto>
    {
    }
}
