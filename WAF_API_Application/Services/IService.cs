namespace WAF_API_Application.Services
{
    using WAF_API_Domain.Commands;
    using WAF_API_Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IService{TDto, TCmd, TCmd2}" />
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TCmd"></typeparam>
    /// <typeparam name="TCmd2"></typeparam>
    public interface IService<TDto, TCmd, TCmd2> where TDto : Dto where TCmd : Cmd where TCmd2 : IdCmd
    {
        /// <summary>
        /// The CreateAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="TCmd"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        Task<TDto?> CreateAsync(TCmd cmd);

        /// <summary>
        /// The DeleteAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// The GetByIdAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        Task<TDto?> GetByIdAsync(string id);

        /// <summary>
        /// The FindIdAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        Task<TDto?> FindIdAsync(string id);

        /// <summary>
        /// The GetAllAsync
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{TDto}}"/></returns>
        Task<IEnumerable<TDto>> GetAllAsync();
        
        /// <summary>
        /// The GetSeveralAsync
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{TDto}}"/></returns>
        Task<IEnumerable<TDto>> GetSeveralAsync(int count);
        
        /// <summary>
        /// Performs an upsert operation for multiple items at once.
        /// </summary>
        /// <param name="items">The items to upsert<see cref="IEnumerable{TDto}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task<IEnumerable<TDto>>UpsertMany(IEnumerable<TCmd> cmd);
    }
}
