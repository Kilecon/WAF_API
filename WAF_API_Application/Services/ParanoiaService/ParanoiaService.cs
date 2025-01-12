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
    public class ParanoiaService : BaseService<ParanoiaDto, CreateParanoiaCmd, UpdateParanoiaCmd>, IParanoiaService
    {
        private IParanoiaFactory _factory;
        public ParanoiaService(IParanoiaFactory factory, IBaseRepository<ParanoiaDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<ParanoiaDto> CreateSpecificAsync(CreateParanoiaCmd cmd, string id)
        {
            var paranoia = _factory.CreateIntance(cmd, id);

            return Task.FromResult(paranoia.ToDto());
        }

        protected override Task<ParanoiaDto> UpdateSpecificAsync(UpdateParanoiaCmd cmd)
        {
            var paranoia = _factory.UpdateIntance(cmd);

            return Task.FromResult(paranoia.ToDto());
        }
    }
}
