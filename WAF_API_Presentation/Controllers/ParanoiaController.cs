using Microsoft.AspNetCore.Mvc;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.DomainExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAF_API_Application.Services.DareService;
using WAF_API_Application.Services.ParanoiaService;
using WAF_API_Domain.Paranoia.Dtos;
using WAF_API_Domain.Paranoia.Commands;
using WAF_API_Domain.Dare.Dtos;
namespace WAF_API_Presentation.Controllers
{
    /// <summary>
    /// Controller for managing "ParanoiaDto" Documents
    /// </summary>
    [Route("API/[controller]")]
    [ApiController]
    public class ParanoiaController(IParanoiaService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly IParanoiaService _noteService = noteService;

        /// <summary>
        /// Retrieves all "ParanoiaDto" Documents
        /// </summary>
        /// <returns>A list of "ParanoiaDto" Documents</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ParanoiaDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<ParanoiaDto
        >>> GetNotes()
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
        /// Retrieves a "ParanoiaDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "ParanoiaDto" Document</param>
        /// <returns>The "ParanoiaDto" Document with the specified ID</returns>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(ParanoiaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<ParanoiaDto>> GetNoteById(string id)
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
        /// Retrieves a "ParanoiaDto" Document by its ID
        /// </summary>
        /// <param name="count">The number of the "ParanoiaDto" Document we want to get</param>
        /// <param name="difficulty"></param>
        /// <returns>The "ParanoiaDto" Document</returns>
        [HttpGet("Get/{count}")]
        [ProducesResponseType(typeof(ParanoiaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<ParanoiaDto>> GetSeveralNotes(int count, string difficulty)
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
        /// Creates a new "ParanoiaDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "ParanoiaDto" Documents</returns>
        [HttpPost("Post")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateParanoiaCmd note)
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
        /// Creates a new "CreateParanoiaDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "CreateParanoiaDto" Documents</returns>
        [HttpPost("PostManyParanoia")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNotes([FromBody] IEnumerable<CreateParanoiaCmd> note)
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
        /// Updates a "ParanoiaDto" Document by its ID
        /// </summary>
        /// <param name="note">The note<see cref="UpdateParanoiaCmd"/></param>
        /// <returns>No content if the update is successful</returns>
        [HttpPut("Update{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> UpdateNote([FromQuery] UpdateParanoiaCmd note)
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
        /// Deletes a "ParanoiaDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "ParanoiaDto" Document to delete</param>
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
