using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services.Difficulty;
using WAF_API_Domain.Difficulty.Commands;
using WAF_API_Domain.Difficulty.Dtos;
using WAF_API_Domain.Difficulty.Factory;

namespace WAF_API_Application.Services.DareService
{
    public class DifficultyService : BaseService<DifficultyDto, CreateDifficultyCmd, UpdateDifficultyCmd>, IDifficultyService
    {
        private IDifficultyFactory _factory;
        public DifficultyService(IDifficultyFactory factory, IBaseRepository<DifficultyDto> repo) : base(repo)
        {
            _factory = factory;
        }

        protected override Task<DifficultyDto> CreateSpecificAsync(CreateDifficultyCmd cmd, string id)
        {
            var difficulty = _factory.CreateIntance(cmd, id);

            return Task.FromResult(difficulty.ToDto());
        }

        protected override Task<DifficultyDto> UpdateSpecificAsync(UpdateDifficultyCmd cmd)
        {
            var difficulty = _factory.UpdateIntance(cmd);

            return Task.FromResult(difficulty.ToDto());
        }
    }
}
