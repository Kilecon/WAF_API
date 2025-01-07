using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services.Ranking;
using WAF_API_Domain.Dare.Dtos;
using WAF_API_Domain.Models;
using WAF_API_Domain.NeverHaveIEver.Dtos;
using WAF_API_Domain.Paranoia.Dtos;
using WAF_API_Domain.Ranking.Models;
using WAF_API_Domain.Truth.Dtos;
using WAF_API_Domain.WouldYouRather.Dtos;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Infrastructure.Repositories
{
    public class RankingRepository : IRankingRepository<RankingDto>
    {
        /// <summary>
        /// Defines the _collection
        /// </summary>
        private readonly IMongoCollection<RankingDto> _collection;

        public RankingRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<RankingDto>("Notations");
        }

        public async Task<RankingDto> AddAsync(RankingDto item)
        {
            await _collection.InsertOneAsync(item);
            var result = await GetItemById(item.Id);
            return result;
        }

        public async Task DeleteByIdAsync(string id)
        {
            var filter = Builders<RankingDto>.Filter.And(
                Builders<RankingDto>.Filter.Eq("Id", id));

            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new NotInDbException($"Cannot Delete \"{typeof(RankingDto).Name}\" " +
                    $"Document with \"{id}\" Id, Document not found.");
            }
        }

        /// <summary>
        /// The GetItemById
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        public async Task<RankingDto> GetItemById(string id)
        {
            var filter = Builders<RankingDto>.Filter.And(
                Builders<RankingDto>.Filter.Eq("Id", id));

            var result = await _collection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotInDbException($"\"{typeof(RankingDto).Name}\" Document with \"{id}\" Id not found.");
            }
            return result;
        }

        /// <summary>
        /// The GetItems
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{RankingDto}}"/></returns>
        public async Task<IEnumerable<RankingDto>> GetDareItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("TypeName", typeof(DareDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetParanoiaItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("TypeName", typeof(ParanoiaDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetNeverHaveIEverItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("TypeName", typeof(NeverHaveIEverDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetTruthItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("TypeName", typeof(TruthDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetWouldYouRatherItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("TypeName", typeof(WouldYouRatherDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetByQuestionId(string id)
        {
            var filter = Builders<RankingDto>.Filter.Eq("QuestionId", id);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }
    }
}