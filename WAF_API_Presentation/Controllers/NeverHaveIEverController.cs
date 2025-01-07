using Microsoft.AspNetCore.Mvc;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.DomainExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAF_API_Application.Services.NeverHaveIEverService;
using WAF_API_Domain.NeverHaveIEver.Dtos;
using WAF_API_Domain.NeverHaveIEver.Commands;

namespace WAF_API_Presentation.Controllers
{
    
    /// <summary>
    /// Controller for managing "NeverHaveIEverDto" Documents
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NeverHaveIEvenController(INeverHaveIEverService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly INeverHaveIEverService _noteService = noteService;

        /// <summary>
        /// Retrieves all "NeverHaveIEverDto" Documents
        /// </summary>
        /// <returns>A list of "NeverHaveIEverDto" Documents</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NeverHaveIEverDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NeverHaveIEverDto>>> GetNotes()
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
        /// Retrieves a "NeverHaveIEverDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "NeverHaveIEverDto" Document</param>
        /// <returns>The "NeverHaveIEverDto" Document with the specified ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NeverHaveIEverDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<NeverHaveIEverDto>> GetNoteById(string id)
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
        /// Retrieves a "NeverHaveIEverDto" Document by its ID
        /// </summary>
        /// <param name="count">The number of the "NeverHaveIEverDto" Document we want to get</param>
        /// <returns>The "DareDto" Document</returns>
        [HttpGet("limit/{count}")]
        [ProducesResponseType(typeof(NeverHaveIEverDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<NeverHaveIEverDto>> GetSeveralNotes(int count)
        {
            try
            {
                var Note = await _noteService.GetSeveralAsync(count);
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
        /// Creates a new "NeverHaveIEverDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "NeverHaveIEverDto" Documents</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateNeverHaveIEverCmd note)
        {
            try
            {
                var result = await _noteService.CreateAsync(note);
                return StatusCode(201, result);
            }
            catch (Exception ex) when (ex is InvalidIdException || ex is InvalidCommandException)

            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }

        /// <summary>
        /// Updates a "NeverHaveIEverDto" Document by its ID
        /// </summary>
        /// <param name="note">The note<see cref="UpdateNeverHaveIEverCmd"/></param>
        /// <returns>No content if the update is successful</returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> UpdateNote([FromQuery] UpdateNeverHaveIEverCmd note)
        {
            try
            {
                var existingNote = await _noteService.GetByIdAsync(note.Id);
                await _noteService.UpdateAsync(note);
                return StatusCode(204);
            }
            catch (Exception ex) when (ex is InvalidIdException || ex is InvalidCommandException)

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
        /// Deletes a "NeverHaveIEverDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "NeverHaveIEverDto" Document to delete</param>
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
    }
}

