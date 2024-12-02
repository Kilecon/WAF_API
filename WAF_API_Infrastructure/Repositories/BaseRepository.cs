namespace WAF_API_Infrastructure.Repositories
{
    using MongoDB.Driver;
    using WAF_API_Application.Services;
    using WAF_API_Domain.Models;
    using WAF_API_Exceptions.InfrastructureExceptions;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

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
            _collection = database.GetCollection<StoredDto<TDto>>("SharedDocuments");
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
    }
}
