namespace WAF_API_Présentation.Controllers
{
    using WAF_API_Application.Services;
    using WAF_API_Domain.Rating.Commands;
    using WAF_API_Domain.Rating.Dtos;
    using WAF_API_Exceptions.ApplicationExceptions;
    using WAF_API_Exceptions.DomainExceptions;
    using WAF_API_Exceptions.InfrastructureExceptions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WAF_API_Application.Services.RatingService;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for managing "RatingDto" Documents
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController(IRatingService commentService) : ControllerBase
    {
        /// <summary>
        /// Defines the _commentService
        /// </summary>
        private readonly IRatingService _commentService = commentService;

        /// <summary>
        /// Retrieves all "RatingDto" Documents
        /// </summary>
        /// <returns>A list of "RatingDto" Documents</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RatingDto>), 200)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetRatings()
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
        /// Retrieves a "RatingDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "RatingDto" Document</param>
        /// <returns>The "RatingDto" Document with the specified ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RatingDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult<RatingDto>> GetRatingById(string id)
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
        /// Creates a new "RatingDto" Documents
        /// </summary>
        /// <param name="comment">The comment to be added</param>
        /// <returns>The created "RatingDto" Documents</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> CreateRating([FromQuery] CreateRatingCmd comment)
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
        /// Updates a "RatingDto" Document by its ID
        /// </summary>
        /// <param name="comment">The "RatingDto" Document to update</param>
        /// <returns>No content if the update is successful</returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> UpdateRating([FromQuery] UpdateRatingCmd comment)
        {
            try
            {
                var existingRating = await _commentService.GetByIdAsync(comment.Id);
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
        /// Deletes a "RatingDto" Document by its ID
        /// </summary>
        /// <param name="id">The ID of the "RatingDto" Document to delete</param>
        /// <returns>No content if the deletion is successful</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(418)]
        [ProducesResponseType(420)]
        public async Task<ActionResult> DeleteRating(string id)
        {
            try
            {
                var existingRating = await _commentService.GetByIdAsync(id);
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
