﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Commands;
using WAF_API_Domain.Suggestion.Commands;
using WAF_API_Domain.Suggestion.Factory;
using WAF_API_Domain.Suggestion.Dtos;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Application.Services.SuggestionService
{
    public class SuggestionService :  ISuggestionService
    {
        private ISuggestionFactory _factory;
        private readonly ISuggestionRepository<SuggestionDto> _repo;
        public SuggestionService(ISuggestionFactory factory, ISuggestionRepository<SuggestionDto> repo)
        {
            _factory = factory;
            _repo = repo;
        }

        protected Task<SuggestionDto> CreateSpecificAsync(CreateSuggestionCmd cmd, string id)
        {
            var suggestion = _factory.CreateIntance(cmd, id);

            return Task.FromResult(suggestion.ToDto());
        }
        

        public async Task<SuggestionDto?> CreateAsync(CreateSuggestionCmd cmd)
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

        public async Task<SuggestionDto?> GetByIdAsync(string id)
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

        public async Task<SuggestionDto?> FindIdAsync(string id)
        {
            try
            {
                return await _repo.GetItemById(id);
            }
            catch (NotInDbException)
            {
                return null;
            }        }

        public Task<IEnumerable<SuggestionDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SuggestionDto>> GetSeveralAsync(int count, string difficulty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SuggestionDto>> UpsertMany(IEnumerable<CreateSuggestionCmd> cmd)
        {
            throw new NotImplementedException();
        }
    }
}
