using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Paranoia.Commands;
using WAF_API_Domain.Paranoia.Dtos;
using WAF_API_Domain.Paranoia.Factory;

namespace WAF_API_Application.Services.ParanoiaService
{
    public class ParanoiaService : BaseService<SuggestionDto, CreateParanoiaCmd, UpdateParanoiaCmd>, IParanoiaService
    {
        private IParanoiaFactory _factory;
        public ParanoiaService(IParanoiaFactory factory, IBaseRepository<SuggestionDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<SuggestionDto> CreateSpecificAsync(CreateParanoiaCmd cmd, string id)
        {
            var dare = _factory.CreateIntance(cmd, id);

            return Task.FromResult(dare.ToDto());
        }

        protected override Task<SuggestionDto> UpdateSpecificAsync(UpdateParanoiaCmd cmd)
        {
            var dare = _factory.UpdateIntance(cmd);

            return Task.FromResult(dare.ToDto());
        }
    }
}
