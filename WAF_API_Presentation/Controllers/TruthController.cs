using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAF_API_Application.Services.TruthService;
using WAF_API_Domain.Truth.Dtos;
using WAF_API_Domain.Truth.Commands;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.DomainExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;
using WAF_API_Domain.Dare.Dtos;

namespace WAF_API_Presentation.Controllers
{
    /// <summary>
    /// Controller for managing "TruthDto" Documents
    /// </summary>
    [Route("API/[controller]")]
    [ApiController]
    public class TruthController(ITruthService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly ITruthService _noteService = noteService;

        /// <summary>
        /// Retrieves all "TruthDto" Documents
        /// </summary>
        /// <returns>A list of "TruthDto" Documents</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TruthDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<TruthDto>>> GetNotes()
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
        /// Retrieves a "TruthDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "TruthDto" Document</param>
        /// <returns>The "TruthDto" Document with the specified ID</returns>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(TruthDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<TruthDto>> GetNoteById(string id)
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
        /// Retrieves a "TruthDto" Document by its ID
        /// </summary>
        /// <param name="count">The number of the "TruthDto" Document we want to get</param>
        /// <returns>The "TruthDto" Document</returns>
        [HttpGet("Get/{count}")]
        [ProducesResponseType(typeof(TruthDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<TruthDto>> GetSeveralNotes(int count, string difficulty)
        {
            try
            {
                var Note = await _noteService.GetSeveralAsync(count, difficulty);
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
        /// Creates a new "TruthDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "TruthDto" Documents</returns>
        [HttpPost("Post")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateTruthCmd note)
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
        /// Creates a new "CreateTruthDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "CreateTruthDto" Documents</returns>
        [HttpPost("PostManyTruth")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNotes([FromBody] IEnumerable<CreateTruthCmd> note)
        {
            try
            {
                var result = await _noteService.UpsertMany(note);
                             
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
        /// Updates a "DareDto" Document by its ID
        /// </summary>
        /// <param name="note">The note<see cref="UpdateTruthCmd"/></param>
        /// <returns>No content if the update is successful</returns>
        [HttpPut("Update{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> UpdateNote([FromQuery] UpdateTruthCmd note)
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
        /// Deletes a "TruthDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "TruthDto" Document to delete</param>
        /// <returns>No content if the deletion is successful</returns>
        [HttpDelete("Delete{id}")]
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
