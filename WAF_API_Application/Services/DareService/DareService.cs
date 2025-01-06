using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Commands;
using WAF_API_Domain.Dare.Dtos;
using WAF_API_Domain.Dare.Factory;

namespace WAF_API_Application.Services.DareService
{
    public class DareService : BaseService<DareDto, CreateDareCmd, UpdateDareCmd>, IDareService
    {
        private IDareFactory _factory;
        public DareService(IDareFactory factory, IBaseRepository<DareDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<DareDto> CreateSpecificAsync(CreateDareCmd cmd, string id)
        {
            var dare = _factory.CreateIntance(cmd, id);

            return Task.FromResult(dare.ToDto());
        }

        protected override Task<DareDto> UpdateSpecificAsync(UpdateDareCmd cmd)
        {
            var dare = _factory.UpdateIntance(cmd);

            return Task.FromResult(dare.ToDto());
        }
    }
}
