using Microsoft.VisualBasic.CompilerServices;
using WAF_API_Domain.Commands;
using WAF_API_Domain.Models;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAF_API_Application.Services
{
 
    /// <summary>
    /// Defines the <see cref="BaseService{TDto, TCmd, TCmd2}" />
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TCmd"></typeparam>
    /// <typeparam name="TCmd2"></typeparam>
    public abstract class BaseService<TDto, TCmd, TCmd2> : IService<TDto, TCmd, TCmd2> where TDto : Dto where TCmd : Cmd where TCmd2 : IdCmd
    {
        /// <summary>
        /// Defines the _repo
        /// </summary>
        private readonly IBaseRepository<TDto> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TDto, TCmd, TCmd2}"/> class.
        /// </summary>
        /// <param name="repo">The repo<see cref="IBaseRepository{TDto}"/></param>
        public BaseService(IBaseRepository<TDto> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// The CreateAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="TCmd"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        public async Task<TDto?> CreateAsync(TCmd cmd)
        {
            var id = Guid.NewGuid().ToString();
            var idTest = await GetByIdAsync(id);
            if (idTest != null)
            {
                await CreateAsync(cmd);
            }
            var dto = await CreateSpecificAsync(cmd, id);
            return await _repo.AddAsync(dto);
        }
        

        /// <summary>
        /// The CreateListAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="TCmd"/></param>
        /// <returns>The <see cref="Task{IEnumerable<TDto>}"/></returns>
        public async Task<IEnumerable<TDto>> UpsertMany(IEnumerable<TCmd> cmds)
        {
            if (cmds == null || !cmds.Any())
            {
                throw new ArgumentException("The command list must not be null or empty.", nameof(cmds));
            }

            var dtos = new List<TDto>();

            foreach (var cmd in cmds)
            {
                var id = Guid.NewGuid().ToString();
                var idTest = await GetByIdAsync(id);

                if (idTest == null)
                {
                    var dto = await CreateSpecificAsync(cmd, id);
                    if (dto != null)
                    {
                        dtos.Add(dto);
                    }
                }
            }

            // Perform the bulk upsert operation
            await _repo.UpsertMany(dtos);

            return dtos;
        }


        /// <summary>
        /// The DeleteAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task"/></returns>
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

        /// <summary>
        /// The GetAllAsync
        /// </summary>
        /// <returns>The <see cref="Task{IEnumerable{TDto}}"/></returns>
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            return await _repo.GetItems();
        }
        
        /// <summary>
        /// The GetSeveralAsync
        /// </summary>
        /// <param name="count">The id<see cref="int"/></param>
        /// <returns>The <see cref="Task{IEnumerable{TDto}}"/></returns>
        public async Task<IEnumerable<TDto>> GetSeveralAsync(int count)
        {
            try
            {
                return await _repo.GetSeveralItems(count);

            }
            catch (NotInDbException)
            {
                throw;
            }
        }
        

        /// <summary>
        /// The GetByIdAsync
        /// </summary>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        public async Task<TDto?> GetByIdAsync(string id)
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

        /// <summary>
        /// The UpdateAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="TCmd2"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task UpdateAsync(TCmd2 cmd)
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

        /// <summary>
        /// The CreateSpecificAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="TCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        protected abstract Task<TDto> CreateSpecificAsync(TCmd cmd, string id);

        /// <summary>
        /// The UpdateSpecificAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="TCmd2"/></param>
        /// <returns>The <see cref="Task{TDto}"/></returns>
        protected abstract Task<TDto> UpdateSpecificAsync(TCmd2 cmd);
    }
}
