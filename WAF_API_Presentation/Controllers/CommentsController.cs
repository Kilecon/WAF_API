namespace WAF_API_Présentation.Controllers
{
    using WAF_API_Application.Services;
    using WAF_API_Domain.Comment.Commands;
    using WAF_API_Domain.Comment.Dtos;
    using WAF_API_Exceptions.ApplicationExceptions;
    using WAF_API_Exceptions.DomainExceptions;
    using WAF_API_Exceptions.InfrastructureExceptions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WAF_API_Application.Services.CommentService;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for managing "CommentDto" Documents
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentService commentService) : ControllerBase
    {
        /// <summary>
        /// Defines the _commentService
        /// </summary>
        private readonly ICommentService _commentService = commentService;

        /// <summary>
        /// Retrieves all "CommentDto" Documents
        /// </summary>
        /// <returns>A list of "CommentDto" Documents</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CommentDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
        {
            try
            {
                var comments = await _commentService.GetAllAsync();
                return StatusCode(200, comments);
            }
            catch (Exception)
            {
                return StatusCode(420, "Enhance Your Calm !");
            }
        }

        /// <summary>
        /// Retrieves a "CommentDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "CommentDto" Document</param>
        /// <returns>The "CommentDto" Document with the specified ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommentDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<CommentDto>> GetCommentById(string id)
        {
            try
            {
                var comment = await _commentService.GetByIdAsync(id);
                return StatusCode(200, comment);
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
        /// Creates a new "CommentDto" Documents
        /// </summary>
        /// <param name="comment">The comment to be added</param>
        /// <returns>The created "CommentDto" Documents</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateComment([FromQuery] CreateCommentCmd comment)
        {
            try
            {
                var result = await _commentService.CreateAsync(comment);
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
        /// Updates a "CommentDto" Document by its ID
        /// </summary>
        /// <param name="comment">The "CommentDto" Document to update</param>
        /// <returns>No content if the update is successful</returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> UpdateComment([FromQuery] UpdateCommentCmd comment)
        {
            try
            {
                var existingComment = await _commentService.GetByIdAsync(comment.Id);
                await _commentService.UpdateAsync(comment);
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
                return StatusCode(420, $"Enhance Your Calm !");
            }
        }

        /// <summary>
        /// Deletes a "CommentDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "CommentDto" Document to delete</param>
        /// <returns>No content if the deletion is successful</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> DeleteComment(string id)
        {
            try
            {
                var existingComment = await _commentService.GetByIdAsync(id);
                await _commentService.DeleteAsync(id);
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
