using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services;
using WAF_API_Application.Services.DareService;
using WAF_API_Application.Services.NeverHaveIEverService;
using WAF_API_Application.Services.ParanoiaService;
using WAF_API_Application.Services.Ranking;
using WAF_API_Application.Services.TruthService;
using WAF_API_Application.Services.WouldYouRatherService;
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
        private readonly IDareRepository _dareRepository;
        private readonly IParanoiaRepository _paranoiaRepository;
        private readonly INeverHaveIEverRepository _neverHaveIEverRepository;
        private readonly ITruthRepository _truthRepository;
        private readonly IWouldYouRatherRepository _wouldYouRatherRepository;

        public RankingRepository(IMongoDatabase database, IDareRepository dareRepo, IParanoiaRepository paranoiaRepo,
            INeverHaveIEverRepository neverHaveIEverRepo, ITruthRepository truthRepo, IWouldYouRatherRepository wouldYouRatherRepo)
        {
            _collection = database.GetCollection<RankingDto>("Notations");
            _dareRepository = dareRepo;
            _paranoiaRepository = paranoiaRepo;
            _neverHaveIEverRepository = neverHaveIEverRepo;
            _truthRepository = truthRepo;
            _wouldYouRatherRepository = wouldYouRatherRepo;
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
            Console.WriteLine(typeof(DareDto).Name);
            var filter = Builders<RankingDto>.Filter.Eq("QuestionTypeName", typeof(DareDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetParanoiaItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("QuestionTypeName", typeof(SuggestionDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetNeverHaveIEverItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("QuestionTypeName", typeof(NeverHaveIEverDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetTruthItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("QuestionTypeName", typeof(TruthDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetWouldYouRatherItems()
        {
            var filter = Builders<RankingDto>.Filter.Eq("QuestionTypeName", typeof(WouldYouRatherDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<IEnumerable<RankingDto>> GetByQuestionId(string id)
        {
            var filter = Builders<RankingDto>.Filter.Eq("QuestionId", id);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents;
        }

        public async Task<(int totalCount, int likedCount)> GetRatingDataAsync(string questionId)
        {
            var filter = Builders<RankingDto>.Filter.Eq("questionId", questionId);

            var totalCount = (int)await _collection.CountDocumentsAsync(filter);
            var likedCount = (int)await _collection.CountDocumentsAsync(
                Builders<RankingDto>.Filter.And(filter, Builders<RankingDto>.Filter.Eq("isLiked", true))
            );

            return (totalCount, likedCount);
        }

        public async Task WatchForChanges()
        {
            // Store the initial timestamp
            long lastCheckedTimestamp = -1;

            while (true)
            {
                    var filter = Builders<RankingDto>.Filter.Gt("LastUpdateUnixTimestamp", lastCheckedTimestamp);

                    var latestDocuments = await _collection.Find(filter)
                        .SortByDescending(doc => doc.LastUpdateUnixTimestamp)
                        .ToListAsync();

                    if (latestDocuments.Any())
                    {
                        // Process the changes by grouping the documents by QuestionId
                        var groupedByQuestionId = latestDocuments
                            .GroupBy(doc => doc.QuestionId)
                            .ToDictionary(g => g.Key, g => g.ToList());

                        foreach (var group in groupedByQuestionId)
                        {
                            string questionId = group.Key;

                            // Get all RankingDto for the current questionId
                            var rankings = await _collection.Find(Builders<RankingDto>.Filter.Eq("QuestionId", questionId)).ToListAsync();

                            // Get the list of documents where isLiked is true for the current questionId
                            var likedRankings = rankings.Where(r => r.IsLiked).ToList();

                            // Estimate rating based on likedRankings
                            double estimatedRating = likedRankings.Count / (double)rankings.Count * 100;
                            int totalReviews = rankings.Count;

                            // Update all DTO repositories
                            await UpdateAllDtoRepositoriesAsync(questionId, estimatedRating, totalReviews);
                        }

                        // Update the lastCheckedTimestamp to the timestamp of the latest document processed
                        lastCheckedTimestamp = latestDocuments.Max(doc => doc.LastUpdateUnixTimestamp);
                    }

                await Task.Delay(360000);  // 5 seconds for testing (change to 3600000 for 1 hour delay)
            }
        }

        public async Task UpdateAllDtoRepositoriesAsync(string questionId, double rating, int totalCount)
        {

                // Update all DTO repositories with the provided rating and total count
                await Task.WhenAll(
                    _dareRepository.UpdateRatingAsync(questionId, rating, totalCount),
                    _paranoiaRepository.UpdateRatingAsync(questionId, rating, totalCount),
                    _neverHaveIEverRepository.UpdateRatingAsync(questionId, rating, totalCount),
                    _truthRepository.UpdateRatingAsync(questionId, rating, totalCount),
                    _wouldYouRatherRepository.UpdateRatingAsync(questionId, rating, totalCount)
                );
        }
    }
}