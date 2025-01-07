using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.WouldYouRather.Commands;
using WAF_API_Domain.WouldYouRather.Dtos;
using WAF_API_Domain.WouldYouRather.Factory;

namespace WAF_API_Application.Services.WouldYouRatherService
{
    public class WouldYouRatherService : BaseService<WouldYouRatherDto, CreateWouldYouRatherCmd, UpdateWouldYouRatherCmd>, IWouldYouRatherService
    {
        private IWouldYouRatherFactory _factory;
        public WouldYouRatherService(IWouldYouRatherFactory factory, IBaseRepository<WouldYouRatherDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<WouldYouRatherDto> CreateSpecificAsync(CreateWouldYouRatherCmd cmd, string id)
        {
            var dare = _factory.CreateIntance(cmd, id);

            return Task.FromResult(dare.ToDto());
        }

        protected override Task<WouldYouRatherDto> UpdateSpecificAsync(UpdateWouldYouRatherCmd cmd)
        {
            var dare = _factory.UpdateIntance(cmd);

            return Task.FromResult(dare.ToDto());
        }
    }
}
