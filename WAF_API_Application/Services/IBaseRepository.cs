namespace WAF_API_Application.Services
{
    using WAF_API_Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IBaseRepository{TDto}" />
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public interface IBaseRepository<TDto> where TDto : Dto
    {
        /// <summary>
        /// The ToStoredDto
        /// </summary>
        /// <param name="item">The item<see cref="TDto"/></param>
        /// <returns>The <see cref="StoredDto{TDto}"/></returns>
        StoredDto<TDto> ToStoredDto(TDto item);

        /// <summary>
        /// The ToDto
        /// </summary>
        /// <param name="storedItem">The storedItem<see cref="StoredDto{TDto}"/></param>
        /// <returns>The <see cref="TDto"/></returns>
        TDto ToDto(StoredDto<TDto> storedItem);

        /// <summary>
        /// The GetItems
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{TDto}}"/></returns>
        Task<IEnumerable<TDto>> GetItems();

        /// <summary>
        /// The GetItemById
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        Task<TDto?> GetItemById(string id);

        /// <summary>
        /// The AddAsync
        /// </summary>
        /// <param name="item">The item<see cref="TDto"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        Task<TDto?> AddAsync(TDto item);

        /// <summary>
        /// The UpdateAsync
        /// </summary>
        /// <param name="item">The item<see cref="TDto"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task UpdateAsync(TDto item);

        /// <summary>
        /// The DeleteByIdAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task DeleteByIdAsync(string id);
    }
}
