using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services.Ranking;
using WAF_API_Domain.Ranking.Commands;
using WAF_API_Domain.Ranking.Models;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.DomainExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController(IRankingService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly IRankingService _noteService = noteService;

        /// <summary>
        /// Retrieves all "RankingDto" Documents
        /// </summary>
        /// <returns>A list of "RankingDto" Documents</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RankingDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RankingDto>>> GetNotes()
        {
            try
            {
                var notes = await _noteService.GetAllAsync();
                return StatusCode(200, notes);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }

        /// <summary>
        /// Retrieves a "RankingDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "RankingDto" Document</param>
        /// <returns>The "RankingDto" Document with the specified ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RankingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<RankingDto>> GetNoteById(string id)
        {
            try
            {
                var Note = await _noteService.GetByIdAsync(id);
                return StatusCode(200, Note);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }

        /// <summary>
        /// Creates a new "RankingDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "RankingDto" Documents</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateRankingCmd note)
        {
            var result = await _noteService.CreateAsync(note);
            return StatusCode(201, result);
            //try
            //{
            //    var result = await _noteService.CreateAsync(note);
            //    return StatusCode(201, result);
            //}
            //catch (Exception ex) when (ex is InvalidIdException || ex is InvalidCommandException)

            //{
            //    return StatusCode(400, ex.Message);
            //}
            //catch (Exception)
            //{
            //    return StatusCode(420, "Enhance Your Calm !");
            //}
        }

        ///// <summary>
        ///// Updates a "RankingDto" Document by its ID
        ///// </summary>
        ///// <param name="note">The note<see cref="UpdateRankingCmd"/></param>
        ///// <returns>No content if the update is successful</returns>
        //[HttpPut]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(418)]
        //[ProducesResponseType(420)]
        //public async Task<ActionResult> UpdateNote([FromQuery] UpdateRankingCmd note)
        //{
        //    try
        //    {
        //        var existingNote = await _noteService.GetByIdAsync(note.Id);
        //        await _noteService.UpdateAsync(note);
        //        return StatusCode(204);
        //    }
        //    catch (Exception ex) when (ex is InvalidIdException || ex is InvalidCommandException)

        //    {
        //        return StatusCode(400, ex.Message);
        //    }
        //    catch (NotInDbException ex)
        //    {
        //        return StatusCode(404, ex.Message);
        //    }
        //    catch (StoreInDbException ex)
        //    {
        //        return StatusCode(418, ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(420, "Enhance Your Calm !");
        //    }
        //}

        /// <summary>
        /// Deletes a "RankingDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "RankingDto" Document to delete</param>
        /// <returns>No content if the deletion is successful</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> DeleteNote(string id)
        {
            try
            {
                var existingNote = await _noteService.GetByIdAsync(id);
                await _noteService.DeleteAsync(id);
                return StatusCode(204);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }

        [HttpGet("{questionId}")]
        [ProducesResponseType(typeof(RankingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RankingDto>>> GetByQuestionId(string id)
        {
            try
            {
                var Note = await _noteService.GetByQuestionIdAsync(id);
                return StatusCode(200, Note);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }
        
        [HttpGet("dare")]
        [ProducesResponseType(typeof(RankingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RankingDto>>> GetDareItems()
        {
            try
            {
                var Note = await _noteService.GetDareItemsAsync();
                return StatusCode(200, Note);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }
        
        [HttpGet("paranoia")]
        [ProducesResponseType(typeof(RankingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RankingDto>>> GetParanoiaItems()
        {
            try
            {
                var Note = await _noteService.GetParanoiaItemsAsync();
                return StatusCode(200, Note);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }
        
        [HttpGet("never_have_i_ever")]
        [ProducesResponseType(typeof(RankingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RankingDto>>> GetNeverHaveIEverItems()
        {
            try
            {
                var Note = await _noteService.GetNeverHaveIEverItemsAsync();
                return StatusCode(200, Note);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }
        
        [HttpGet("truth")]
        [ProducesResponseType(typeof(RankingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RankingDto>>> GetTruthItems()
        {
            try
            {
                var Note = await _noteService.GetTruthItemsAsync();
                return StatusCode(200, Note);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }
        
        [HttpGet("would_you_rather")]
        [ProducesResponseType(typeof(RankingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RankingDto>>> GetWouldYouRatherItems()
        {
            try
            {
                var Note = await _noteService.GetWouldYouRatherItemsAsync();
                return StatusCode(200, Note);
            }
            catch (InvalidIdException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (NotInDbException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (StoreInDbException ex)
            {
                return StatusCode(418, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }
    }
}