using MongoDB.Driver;
using WAF_API_Application.Services;
using WAF_API_Domain.Models;
using WAF_API_Exceptions.InfrastructureExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace WAF_API_Infrastructure.Repositories
{


    /// <summary>
    /// Defines the <see cref="BaseRepository{TDto}" />
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public abstract class BaseRepository<TDto> : IBaseRepository<TDto> where TDto : Dto
    {
        /// <summary>
        /// Defines the _collection
        /// </summary>
        private readonly IMongoCollection<StoredDto<TDto>> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TDto}"/> class.
        /// </summary>
        /// <param name="database">The database<see cref="IMongoDatabase"/></param>
        public BaseRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<StoredDto<TDto>>("WAF_GAMEPLAY");
        }

        /// <summary>
        /// The ToStoredDto
        /// </summary>
        /// <param name="item">The item<see cref="TDto"/></param>
        /// <returns>The <see cref="StoredDto{TDto}"/></returns>
        public StoredDto<TDto> ToStoredDto(TDto item)
        {
            //item.Id = Guid.NewGuid().ToString();
            //item.LastUpdateUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            return new StoredDto<TDto>
            {
                Id = item.Id,
                TypeName = typeof(TDto).Name,
                Payload = item,
                LastUpdateUnixTimestamp = item.LastUpdateUnixTimestamp
            };
        }

        /// <summary>
        /// The UpdateStoredDto
        /// </summary>
        /// <param name="item">The item<see cref="TDto"/></param>
        /// <returns>The <see cref="StoredDto{TDto}"/></returns>
        public StoredDto<TDto> UpdateStoredDto(TDto item)
        {
            item.LastUpdateUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            return new StoredDto<TDto>
            {
                Id = item.Id,
                TypeName = typeof(TDto).Name,
                Payload = item,
                LastUpdateUnixTimestamp = item.LastUpdateUnixTimestamp
            };
        }

        /// <summary>
        /// The ToDto
        /// </summary>
        /// <param name="storedItem">The storedItem<see cref="StoredDto{TDto}"/></param>
        /// <returns>The <see cref="TDto"/></returns>
        public TDto ToDto(StoredDto<TDto> storedItem)
        {

            if (storedItem == null)
            {
                throw new NotInDbException($"The \"{typeof(TDto).Name}\" document is not in the database.");
            }
            if (storedItem.Payload == null)
            {
                throw new StoreInDbException($"The \"{typeof(TDto).Name}\" document is broken in the database.");
            }

            return storedItem.Payload;
        }

        /// <summary>
        /// The AddAsync
        /// </summary>
        /// <param name="item">The item<see cref="TDto"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        public async Task<TDto?> AddAsync(TDto item)
        {
            var storedItem = ToStoredDto(item);

            var filter = Builders<StoredDto<TDto>>.Filter.And(
                Builders<StoredDto<TDto>>.Filter.Eq("Id", storedItem.Id),
                Builders<StoredDto<TDto>>.Filter.Eq("TypeName", typeof(TDto).Name)
            );

            var existingItem = await _collection.Find(filter).FirstOrDefaultAsync();

            //if (existingItem != null)
            //{
            //    await AddAsync(item);
            //}

            await _collection.InsertOneAsync(storedItem);
            var result = await GetItemById(storedItem.Id);
            return result;
        }

        /// <summary>
        /// The DeleteByIdAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task DeleteByIdAsync(string id)
        {
            var filter = Builders<StoredDto<TDto>>.Filter.And(
                Builders<StoredDto<TDto>>.Filter.Eq("Id", id),
                Builders<StoredDto<TDto>>.Filter.Eq("TypeName", typeof(TDto).Name)
            );

            var result = await _collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new NotInDbException($"Cannot Delete \"{typeof(TDto).Name}\" Document with \"{id}\" Id, Document not found.");
            }
        }

        /// <summary>
        /// The GetItemById
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        public async Task<TDto?> GetItemById(string id)
        {
            var filter = Builders<StoredDto<TDto>>.Filter.And(
                Builders<StoredDto<TDto>>.Filter.Eq("Id", id),
                Builders<StoredDto<TDto>>.Filter.Eq("TypeName", typeof(TDto).Name)
            );

            var result = await _collection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotInDbException($"\"{typeof(TDto).Name}\" Document with \"{id}\" Id not found.");
            }
            return ToDto(result);
        }

        /// <summary>
        /// The GetItems
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{TDto}}"/></returns>
        public async Task<IEnumerable<TDto>> GetItems()
        {
            var filter = Builders<StoredDto<TDto>>.Filter.Eq("TypeName", typeof(TDto).Name);
            var documents = await _collection.Find(filter).ToListAsync();

            return documents.Select(doc => ToDto(doc));
        }

        /// <summary>
        /// The UpdateAsync
        /// </summary>
        /// <param name="item">The item<see cref="TDto"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task UpdateAsync(TDto item)
        {
            var filter = Builders<StoredDto<TDto>>.Filter.And(
                Builders<StoredDto<TDto>>.Filter.Eq("Id", item.Id),
                Builders<StoredDto<TDto>>.Filter.Eq("TypeName", typeof(TDto).Name)
            );

            var storedItem = UpdateStoredDto(item);

            var result = await _collection.ReplaceOneAsync(
                filter,
                storedItem,
                new ReplaceOptions { IsUpsert = true }
            );

            if (result.MatchedCount == 0)
            {
                throw new NotInDbException($"\"{typeof(TDto).Name}\"Document not found.");
            }
        }

        public async Task<IEnumerable<TDto>> GetSeveralItems(int number, string difficultyName)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Le nombre d'éléments doit être supérieur à 0.", nameof(number));
            }

            var pipeline = new[]
                {
                new BsonDocument("$match", new BsonDocument("TypeName", typeof(TDto).Name)),
                new BsonDocument("$match", new BsonDocument("Payload.DifficultyName", difficultyName)),
                new BsonDocument("$sample", new BsonDocument("size", number))
                };

            var documents = await _collection.Aggregate<StoredDto<TDto>>(pipeline).ToListAsync();

            return documents.Select(doc => ToDto(doc));
        }
        
        /// <summary>
        /// Performs an upsert operation for multiple items at once, using aggregation to filter or process data.
        /// </summary>
        /// <param name="items">The list of items to upsert<see cref="IEnumerable{TDto}"/></param>
        /// <returns>The <see cref="Task{IEnumerable{TDto}}"/></returns>
        public async Task<IEnumerable<TDto>> UpsertMany(IEnumerable<TDto> items)
        {
            if (items == null || !items.Any())
            {
                throw new ArgumentException("The items collection must not be null or empty.", nameof(items));
            }

            // Step 1: Aggregate to find existing items matching the IDs of the input items
            var itemIds = items.Select(item => item.Id).ToList();
            var pipeline = new[]
            {
                new BsonDocument("$match", new BsonDocument
                {
                    { "TypeName", typeof(TDto).Name },
                    { "Id", new BsonDocument("$in", new BsonArray(itemIds)) }
                })
            };

            var existingItems = await _collection.Aggregate<StoredDto<TDto>>(pipeline).ToListAsync();
            var existingItemIds = existingItems.Select(e => e.Id).ToHashSet();

            // Step 2: Create upsert operations
            var operations = new List<WriteModel<StoredDto<TDto>>>();
            foreach (var item in items)
            {
                var storedItem = UpdateStoredDto(item);

                var filter = Builders<StoredDto<TDto>>.Filter.And(
                    Builders<StoredDto<TDto>>.Filter.Eq("Id", storedItem.Id),
                    Builders<StoredDto<TDto>>.Filter.Eq("TypeName", typeof(TDto).Name)
                );

                var update = Builders<StoredDto<TDto>>.Update
                    .SetOnInsert(x => x.Id, storedItem.Id)
                    .Set(x => x.Payload, storedItem.Payload)
                    .Set(x => x.LastUpdateUnixTimestamp, storedItem.LastUpdateUnixTimestamp)
                    .Set(x => x.TypeName, storedItem.TypeName);

                var upsertOperation = new UpdateOneModel<StoredDto<TDto>>(filter, update) { IsUpsert = true };
                operations.Add(upsertOperation);
            }

            // Step 3: Perform bulk upsert
            if (operations.Any())
            {
                await _collection.BulkWriteAsync(operations, new BulkWriteOptions { IsOrdered = false });
            }

            // Step 4: Return updated items
            var updatedItems = await _collection.Aggregate<StoredDto<TDto>>(pipeline).ToListAsync();
            return updatedItems.Select(ToDto);
        }

        public async Task UpdateRatingAsync(string questionId, double rating, int totalReviews)
        {
            // Format the value as a string in the "rating//totalReviews" format
            string formattedRating = $"{rating:F2}//{totalReviews}";

            // Build the filter to find the document with the corresponding _id
            var filter = Builders<StoredDto<TDto>>.Filter.Eq("_id", questionId);

            // Build the update with the formatted string for the Payload.Rating field
            var update = Builders<StoredDto<TDto>>.Update.Set("Payload.Rating", formattedRating);

                var result = await _collection.UpdateOneAsync(filter, update);
        }
    }
}