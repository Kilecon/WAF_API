using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services.NotationService;
using WAF_API_Domain.Difficulty.Commands;
using WAF_API_Domain.Notation.Commands;
using WAF_API_Domain.Notation.Factory;
using WAF_API_Domain.Notation.Dtos;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Application.Services.NotationService
{
    public class NotationService : INotationService
    {
        private INotationFactory _factory;
        private readonly INotationRepository<NotationDto> _repo;
        public NotationService(INotationFactory factory, INotationRepository<NotationDto> repo)
        {
            _factory = factory;
            _repo = repo;
        }

        protected Task<NotationDto> CreateSpecificAsync(CreateNotationCmd cmd, string id)
        {
            var notation = _factory.CreateIntance(cmd, id);

            return Task.FromResult(notation.ToDto());
        }

        protected Task<NotationDto> UpdateSpecificAsync(UpdateNotationCmd cmd)
        {
            var notation = _factory.UpdateIntance(cmd);

            return Task.FromResult(notation.ToDto());
        }

        public async Task<NotationDto?> CreateAsync(CreateNotationCmd cmd)
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
                var idTest = await FindIdAsync(id);
                await _repo.DeleteByIdAsync(id);

            }
            catch (NotInDbException)
            {
                throw;
            }
        }

        public async Task<NotationDto?> GetByIdAsync(string id)
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
        public async Task<NotationDto?> FindIdAsync(string id)
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

        public async Task<IEnumerable<NotationDto?>> GetByQuestionIdAsync(string id)
        {
            try
            {
                return await _repo.GetByQuestionId(id);

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<NotationDto?>> GetDareItemsAsync()
        {
            try
            {
                return await _repo.GetDareItems();

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<NotationDto?>> GetParanoiaItemsAsync()
        {
            try
            {
                return await _repo.GetParanoiaItems();

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<NotationDto?>> GetNeverHaveIEverItemsAsync()
        {
            try
            {
                return await _repo.GetNeverHaveIEverItems();

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<NotationDto?>> GetTruthItemsAsync()
        {
            try
            {
                return await _repo.GetTruthItems();

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<NotationDto?>> GetWouldYouRatherItemsAsync()
        {
            try
            {
                return await _repo.GetWouldYouRatherItems();

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        
        public Task<IEnumerable<NotationDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotationDto>> GetSeveralAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotationDto>> UpsertMany(IEnumerable<CreateNotationCmd> cmd)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotationDto>> UpsertMany(IEnumerable<CreateDifficultyCmd> cmd)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateNotationCmd note)
        {
            throw new NotImplementedException();
        }
    }
}
