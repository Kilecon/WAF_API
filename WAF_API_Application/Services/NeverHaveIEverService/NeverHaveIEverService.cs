using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.NeverHaveIEver.Commands;
using WAF_API_Domain.NeverHaveIEver.Dtos;
using WAF_API_Domain.NeverHaveIEver.Factory;

namespace WAF_API_Application.Services.NeverHaveIEverService
{
    public class NeverHaveIEverService : BaseService<NeverHaveIEverDto, CreateNeverHaveIEverCmd, UpdateNeverHaveIEverCmd>, INeverHaveIEverService
    {
        private INeverHaveIEverFactory _factory;
        public NeverHaveIEverService(INeverHaveIEverFactory factory, IBaseRepository<NeverHaveIEverDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<NeverHaveIEverDto> CreateSpecificAsync(CreateNeverHaveIEverCmd cmd, string id)
        {
            var neverIHaveEver = _factory.CreateIntance(cmd, id);

            return Task.FromResult(neverIHaveEver.ToDto());
        }

        protected override Task<NeverHaveIEverDto> UpdateSpecificAsync(UpdateNeverHaveIEverCmd cmd)
        {
            var neverIHaveEver = _factory.UpdateIntance(cmd);

            return Task.FromResult(neverIHaveEver.ToDto());
        }
    }
}
