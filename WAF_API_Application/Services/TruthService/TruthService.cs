using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Truth.Commands;
using WAF_API_Domain.Truth.Dtos;
using WAF_API_Domain.Truth.Factory;

namespace WAF_API_Application.Services.TruthService
{
    public class TruthService : BaseService<TruthDto, CreateTruthCmd, UpdateTruthCmd>, ITruthService
    {
        private ITruthFactory _factory;
        public TruthService(ITruthFactory factory, IBaseRepository<TruthDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<TruthDto> CreateSpecificAsync(CreateTruthCmd cmd, string id)
        {
            var dare = _factory.CreateIntance(cmd, id);

            return Task.FromResult(dare.ToDto());
        }

        protected override Task<TruthDto> UpdateSpecificAsync(UpdateTruthCmd cmd)
        {
            var dare = _factory.UpdateIntance(cmd);

            return Task.FromResult(dare.ToDto());
        }
    }
}
