using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services;
using WAF_API_Application.Services.SuggestionService;
using WAF_API_Domain.Models;
using WAF_API_Domain.Suggestion.Dtos;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Infrastructure.Repositories
{
    public class SuggestionRepository : ISuggestionRepository<SuggestionDto>, IBaseRepository<SuggestionDto>
    {
        private readonly IMongoCollection<SuggestionDto> _collection;

        public SuggestionRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<SuggestionDto>("WAF_PLAYERS_SUGGESTIONS");
        }

        public async Task<SuggestionDto> AddAsync(SuggestionDto item)
        {
            await _collection.InsertOneAsync(item);
            var result = await GetItemById(item.Id);
            return result;
        }

        public Task UpdateAsync(SuggestionDto item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string id)
        {
            var filter = Builders<SuggestionDto>.Filter.And(
                Builders<SuggestionDto>.Filter.Eq("Id", id));

            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new NotInDbException($"Cannot Delete \"{typeof(SuggestionDto).Name}\" " +
                    $"Document with \"{id}\" Id, Document not found.");
            }
        }

        public Task<IEnumerable<SuggestionDto>> GetSeveralItems(int count)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SuggestionDto>> UpsertMany(IEnumerable<SuggestionDto> items)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRatingAsync(string questionId, double rating, int totalReviews)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetItemById
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        public async Task<SuggestionDto> GetItemById(string id)
        {
            var filter = Builders<SuggestionDto>.Filter.And(
                Builders<SuggestionDto>.Filter.Eq("Id", id));

            var result = await _collection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotInDbException($"\"{typeof(SuggestionDto).Name}\" Document with \"{id}\" Id not found.");
            }
            return result;
        }

        public StoredDto<SuggestionDto> ToStoredDto(SuggestionDto item)
        {
            throw new NotImplementedException();
        }

        public SuggestionDto ToDto(StoredDto<SuggestionDto> storedItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetItems
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{SuggestionDto}}"/></returns>
        public async Task<IEnumerable<SuggestionDto>> GetItems()
        {
            var filter = Builders<SuggestionDto>.Filter.Empty;
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

    }
}
