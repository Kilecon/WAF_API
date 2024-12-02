using WAF_API_Domain.Note.Commands;
using WAF_API_Domain.Note.Dtos;
using WAF_API_Domain.Note.Factory;
using System.Globalization;
using System.Threading.Tasks;
using WAF_API_Application.Services;

namespace WAF_API_Application.Services.NoteService
{
    public class ChallengeService : BaseService<ChallengeDto, CreateChallengeCmd, UpdateChallengeCmd>, IChallengeService
    {
        private IChallengeFactory _factory;
        public ChallengeService(IChallengeFactory factory, IBaseRepository<ChallengeDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<ChallengeDto> CreateSpecificAsync(CreateChallengeCmd cmd, string id)
        {
            var note = _factory.CreateIntance(cmd, id);

            return Task.FromResult(note.ToDto());
        }

        protected override Task<ChallengeDto> UpdateSpecificAsync(UpdateChallengeCmd cmd)
        {
            var note = _factory.UpdateIntance(cmd);


            return Task.FromResult(note.ToDto());
        }
    }
}
