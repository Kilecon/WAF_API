using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services.SuggestionService;
using WAF_API_Domain.Suggestion.Commands;
using WAF_API_Domain.Suggestion.Dtos;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.DomainExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;


namespace WAF_API_Presentation.Controllers
{
    
    [Route("API/[controller]")]
    [ApiController]
    public class SuggestionController(ISuggestionService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly ISuggestionService _noteService = noteService;

        /// <summary>
        /// Retrieves all "SuggestionDto" Documents
        /// </summary>
        /// <returns>A list of "SuggestionDto" Documents</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<SuggestionDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<SuggestionDto>>> GetNotes()
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
        /// Retrieves a "SuggestionDto" Document by its ID
        /// </summary>
        /// <param name="count">The number of the "SuggestionDto" Document we want to get</param>
        /// <returns>The "ParanoiaDto" Document</returns>
        [HttpGet("Get/{count}")]
        [ProducesResponseType(typeof(SuggestionDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<SuggestionDto>> GetSeveralNotes(int count)
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
        /// Retrieves a "SuggestionDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "SuggestionDto" Document</param>
        /// <returns>The "SuggestionDto" Document with the specified ID</returns>
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(SuggestionDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<SuggestionDto>> GetNoteById(string id)
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
        /// Creates a new "SuggestionDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "SuggestionDto" Documents</returns>
        [HttpPost("Post")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateSuggestionCmd note)
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
        /// Deletes a "SuggestionDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "SuggestionDto" Document to delete</param>
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