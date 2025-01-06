using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Ranking.Commands;
using WAF_API_Domain.Ranking.Factory;
using WAF_API_Domain.Ranking.Models;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Application.Services.Ranking
{
    public class RankingService
    {
        private IRankingFactory _factory;
        private readonly IRankingRepository _repo;
        public RankingService(IRankingFactory factory, IRankingRepository repo)
        {
            _factory = factory;
            _repo = repo;
        }

        protected Task<RankingDto> CreateSpecificAsync(CreateRankingCmd cmd, string id)
        {
            var dare = _factory.CreateIntance(cmd, id);

            return Task.FromResult(dare);
        }

        protected Task<RankingDto> UpdateSpecificAsync(UpdateRankingCmd cmd)
        {
            var dare = _factory.UpdateIntance(cmd);

            return Task.FromResult(dare);
        }

        public async Task<RankingDto?> CreateAsync(CreateRankingCmd cmd)
        {
            var id = Guid.NewGuid().ToString();
            var idTest = await FindIdAsync(id);
            if (idTest != null)
            {
                await CreateAsync(cmd);
            }
            var dto = await CreateSpecificAsync(cmd, id);
            return await _repo.AddAsync(dto);
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var idTest = await GetByIdAsync(id);
                await _repo.DeleteByIdAsync(id);

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        public async Task<IEnumerable<RankingDto>> GetAllAsync()
        {
            return await _repo.GetItems();
        }

        public async Task<RankingDto?> GetByIdAsync(string id)
        {
            try
            {
                return await _repo.GetItemById(id);

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        public async Task<RankingDto?> FindIdAsync(string id)
        {
            try
            {
                return await _repo.GetItemById(id);

            }
            catch (NotInDbException)
            {
                return null;
            }
        }

        public async Task UpdateAsync(UpdateRankingCmd cmd)
        {
            try
            {
                var idTest = await GetByIdAsync(cmd.Id);
            }
            catch (Exception)
            {
                throw new InvalidIdException();
            }
            var dto = await UpdateSpecificAsync(cmd);

            await _repo.UpdateAsync(dto);
        }
    }
}
