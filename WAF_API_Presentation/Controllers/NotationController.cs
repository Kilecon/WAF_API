using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Application.Services.NotationService;
using WAF_API_Domain.Notation.Commands;
using WAF_API_Domain.Notation.Dtos;
using WAF_API_Exceptions.ApplicationExceptions;
using WAF_API_Exceptions.DomainExceptions;
using WAF_API_Exceptions.InfrastructureExceptions;

namespace WAF_API_Presentation.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class NotationController(INotationService noteService) : ControllerBase
    {
        /// <summary>
        /// Defines the _noteService
        /// </summary>
        private readonly INotationService _noteService = noteService;

        /// <summary>
        /// Retrieves all "NotationDto" Documents
        /// </summary>
        /// <returns>A list of "NotationDto" Documents</returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<NotationDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NotationDto>>> GetNotes()
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
        /// Retrieves a "NotationDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "NotationDto" Document</param>
        /// <returns>The "NotationDto" Document with the specified ID</returns>
        [HttpGet("GetById{id}")]
        [ProducesResponseType(typeof(NotationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<NotationDto>> GetNoteById(string id)
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
        /// Creates a new "NotationDto" Documents
        /// </summary>
        /// <param name="note">The note to be added</param>
        /// <returns>The created "NotationDto" Documents</returns>
        [HttpPost("Post")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateNote([FromQuery] CreateNotationCmd note)
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

        ///// <summary>
        ///// Updates a "NotationDto" Document by its ID
        ///// </summary>
        ///// <param name="note">The note<see cref="UpdateNotationCmd"/></param>
        ///// <returns>No content if the update is successful</returns>
        //[HttpPut]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(418)]
        //[ProducesResponseType(420)]
        //public async Task<ActionResult> UpdateNote([FromQuery] UpdateNotationCmd note)
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
        /// Deletes a "NotationDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "NotationDto" Document to delete</param>
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

        [HttpGet("GetByQuestionId{questionId}")]
        [ProducesResponseType(typeof(NotationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NotationDto>>> GetByQuestionId(string questionId)
        {
            try
            {
                var Note = await _noteService.GetByQuestionIdAsync(questionId);
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
        
        [HttpGet("GetAllDares")]
        [ProducesResponseType(typeof(NotationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NotationDto>>> GetDareItems()
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
        
        [HttpGet("GetAllParanoias")]
        [ProducesResponseType(typeof(NotationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NotationDto>>> GetParanoiaItems()
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
        
        [HttpGet("GetAllNeverHaveIEver")]
        [ProducesResponseType(typeof(NotationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NotationDto>>> GetNeverHaveIEverItems()
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
        
        [HttpGet("GetAllTruth")]
        [ProducesResponseType(typeof(NotationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NotationDto>>> GetTruthItems()
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
        
        [HttpGet("GetAllWouldYouRather")]
        [ProducesResponseType(typeof(NotationDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<NotationDto>>> GetWouldYouRatherItems()
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