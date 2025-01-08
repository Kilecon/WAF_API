using Microsoft.AspNetCore.Mvc;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.DomainExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAF_API_Application.Services.WouldYouRatherService;
using WAF_API_Domain.WouldYouRather.Dtos;
using WAF_API_Domain.WouldYouRather.Commands;

namespace WAF_API_Presentation.Controllers
{
    /// <summary>
    /// Controller for managing "WouldYouRatherDto" Documents
    /// </summary>
    [Route("API/[controller]")]
    [ApiController]
    public class WouldYouRatherController(IWouldYouRatherService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly IWouldYouRatherService _noteService = noteService;

        /// <summary>
        /// Retrieves all "WouldYouRatherDto" Documents
        /// </summary>
        /// <returns>A list of "WouldYouRatherDto" Documents</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<WouldYouRatherDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<WouldYouRatherDto>>> GetNotes()
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
        /// Retrieves a "WouldYouRatherDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "WouldYouRatherDto" Document</param>
        /// <returns>The "WouldYouRatherDto" Document with the specified ID</returns>
        [HttpGet("GetById{id}")]
        [ProducesResponseType(typeof(WouldYouRatherDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<WouldYouRatherDto>> GetNoteById(string id)
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
        /// Retrieves a "WouldYouRatherDto>" Document by its ID
        /// </summary>
        /// <param name="count">The number of the "WouldYouRatherDto>" Document we want to get</param>
        /// <returns>The "WouldYouRatherDto>" Document</returns>
        [HttpGet("Get{count}")]
        [ProducesResponseType(typeof(WouldYouRatherDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<WouldYouRatherDto>> GetSeveralNotes(int count)
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
        /// Creates a new "DareDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "DareDto" Documents</returns>
        [HttpPost("Post")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateWouldYouRatherCmd note)
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
        [HttpPost("UpsertMany")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNotes([FromBody] IEnumerable<CreateWouldYouRatherCmd> note)
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
        /// Updates a "WouldYouRatherDto" Document by its ID
        /// </summary>
        /// <param name="note">The note<see cref="UpdateWouldYouRatherCmd"/></param>
        /// <returns>No content if the update is successful</returns>
        [HttpPut("Update{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> UpdateNote([FromQuery] UpdateWouldYouRatherCmd note)
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
        /// Deletes a "WouldYouRatherDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "WouldYouRatherDto" Document to delete</param>
        /// <returns>No content if the deletion is successful</returns>
        [HttpDelete("DeleteById{id}")]
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
