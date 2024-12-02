namespace WAF_API_Présentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WAF_API_Domain.Note.Commands;
    using WAF_API_Domain.Note.Dtos;
    using WAF_API_Exceptions.ApplicationExceptions;
    using WAF_API_Exceptions.DomainExceptions;
    using WAF_API_Exceptions.InfrastructureExceptions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WAF_API_Application.Services.NoteService;

    /// <summary>
    /// Controller for managing "ChallengeDto" Documents
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController(IChallengeService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly IChallengeService _noteService = noteService;

        /// <summary>
        /// Retrieves all "ChallengeDto" Documents
        /// </summary>
        /// <returns>A list of "ChallengeDto" Documents</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ChallengeDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<ChallengeDto>>> GetNotes()
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
        /// Retrieves a "ChallengeDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "ChallengeDto" Document</param>
        /// <returns>The "ChallengeDto" Document with the specified ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ChallengeDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<ChallengeDto>> GetNoteById(string id)
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
        /// Creates a new "ChallengeDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "ChallengeDto" Documents</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateChallengeCmd note)
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
        /// Updates a "ChallengeDto" Document by its ID
        /// </summary>
        /// <param name="note">The note<see cref="UpdateChallengeCmd"/></param>
        /// <returns>No content if the update is successful</returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> UpdateNote([FromQuery] UpdateChallengeCmd note)
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
        /// Deletes a "ChallengeDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "ChallengeDto" Document to delete</param>
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
