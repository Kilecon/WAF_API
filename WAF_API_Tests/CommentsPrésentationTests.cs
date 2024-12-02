namespace WAF_API_Tests
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using WAF_API_Application.Services;
    using WAF_API_Domain.Comment.Commands;
    using WAF_API_Domain.Comment.Dtos;
    using WAF_API_Exceptions.ApplicationExceptions;
    using WAF_API_Exceptions.DomainExceptions;
    using WAF_API_Exceptions.InfrastructureExceptions;
    using WAF_API_Présentation.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="CommentsPrésentationTests" />
    /// </summary>
    public class CommentsPrésentationTests
    {
        /// <summary>
        /// Defines the _mockCommentService
        /// </summary>
        private readonly Mock<ICommentService> _mockCommentService;

        /// <summary>
        /// Defines the _controller
        /// </summary>
        private readonly CommentsController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsPrésentationTests"/> class.
        /// </summary>
        public CommentsPrésentationTests()
        {
            _mockCommentService = new Mock<ICommentService>();
            _controller = new CommentsController(_mockCommentService.Object);
        }

        /// <summary>
        /// The GetComments_ReturnsOk_WhenCommentsExist
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task GetComments_ReturnsOk_WhenCommentsExist()
        {
            // Arrange
            var comments = new List<CommentDto>
            {
                new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "Test Comment 1.", Description = "Description 1." },
                new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b36a", Title = "Test Comment 2.", Description = "Description 2." }
            };
            _mockCommentService.Setup(service => service.GetAllAsync()).ReturnsAsync(comments);

            // Act
            var result = await _controller.GetComments();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CommentDto>>>(result);
            var requestResult = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(200, requestResult.StatusCode);
            Assert.Equal(comments, requestResult.Value);
        }

        /// <summary>
        /// The GetComments_ReturnsEnhanceYourCalm_WhenExceptionThrown
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task GetComments_ReturnsEnhanceYourCalm_WhenExceptionThrown()
        {
            // Arrange
            _mockCommentService.Setup(service => service.GetAllAsync()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetComments();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CommentDto>>>(result);
            var statusCodeResult = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(420, statusCodeResult.StatusCode);
        }

        /// <summary>
        /// The GetCommentById_ReturnsOk_WhenCommentExists
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task GetCommentById_ReturnsOk_WhenCommentExists()
        {
            // Arrange
            var comment = new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "Test Comment.", Description = "Description." };
            _mockCommentService.Setup(service => service.GetByIdAsync("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a")).ReturnsAsync(comment);

            // Act
            var result = await _controller.GetCommentById("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a");
            // Assert
            var actionResult = Assert.IsType<ActionResult<CommentDto>>(result);
            var requestResult = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(200, requestResult.StatusCode);
            Assert.Equal(comment, requestResult.Value);
        }

        /// <summary>
        /// The GetCommentById_ReturnsBadRequest_WhenInvalidId
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task GetCommentById_ReturnsBadRequest_WhenInvalidId()
        {
            // Arrange
            _mockCommentService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new InvalidIdException("Invalid ID"));

            // Act
            var result = await _controller.GetCommentById("invalid");

            // Assert
            var actionResult = Assert.IsType<ActionResult<CommentDto>>(result);
            var badRequestResult = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Invalid ID", badRequestResult.Value);
        }
        [Fact]
        public async Task GetCommentById_ReturnsNotFound_WhenNotInDb()
        {
            // Arrange
            _mockCommentService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new NotInDbException());

            // Act
            var result = await _controller.GetCommentById("invalid");
            var err = new NotInDbException();

            // Assert
            var actionResult = Assert.IsType<ActionResult<CommentDto>>(result);
            var notFoundResult = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
            Assert.Equal(err.Message, notFoundResult.Value);
        }
        [Fact]
        public async Task GetCommentById_ReturnsTeapot_WhenDbIssues()
        {
            // Arrange
            _mockCommentService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new StoreInDbException());

            // Act
            var result = await _controller.GetCommentById("invalid");
            var err = new StoreInDbException();

            // Assert
            var actionResult = Assert.IsType<ActionResult<CommentDto>>(result);
            var resultt = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(418, resultt.StatusCode);
            Assert.Equal(err.Message, resultt.Value);
        }

        [Fact]
        public async Task GetCommentById_ReturnsCalm_WhenExcept()
        {
            // Arrange
            _mockCommentService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetCommentById("invalid");

            // Assert
            var actionResult = Assert.IsType<ActionResult<CommentDto>>(result);
            var resultt = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(420, resultt.StatusCode);
            Assert.Equal("Enhance Your Calm !", resultt.Value);
        }

        /// <summary>
        /// The CreateComment_ReturnsCreated
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task CreateComment_ReturnsCreated()
        {
            // Arrange
            var newComment = new CreateCommentCmd { Title = "New Comment.", Description = "New Description." };
            var createdComment = new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "New Comment.", Description = "New Description." };
            _mockCommentService.Setup(service => service.CreateAsync(It.IsAny<CreateCommentCmd>())).ReturnsAsync(createdComment);

            // Act
            var result = await _controller.CreateComment(newComment);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
            Assert.IsType<CommentDto>(actionResult.Value);
            var returnValue = (CommentDto)actionResult.Value;
            Assert.Equal("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", returnValue.Id);
            Assert.Equal("New Comment.", returnValue.Title);
            Assert.Equal("New Description.", returnValue.Description);
        }

        [Fact]
        public async Task CreateComment_ReturnsBadRequest()
        {
            // Arrange
            var newComment = new CreateCommentCmd { Title = "New Comment.", Description = "New Description." };
            var createdComment = new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "New Comment.", Description = "New Description." };
            _mockCommentService.Setup(service => service.CreateAsync(It.IsAny<CreateCommentCmd>())).ThrowsAsync(new InvalidCommandException());

            // Act
            var result = await _controller.CreateComment(newComment);
            var err = new InvalidCommandException();

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
            Assert.Equal(err.Message, actionResult.Value);
        }

        [Fact]
        public async Task CreateComment_ReturnsCalm()
        {
            // Arrange
            var newComment = new CreateCommentCmd { Title = "New Comment.", Description = "New Description." };
            var createdComment = new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "New Comment.", Description = "New Description." };
            _mockCommentService.Setup(service => service.CreateAsync(It.IsAny<CreateCommentCmd>())).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.CreateComment(newComment);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(420, actionResult.StatusCode);
            Assert.Equal("Enhance Your Calm !", actionResult.Value);
        }


        /// <summary>
        /// The CreateComment_ReturnsCreated_WhenEmptyCommand
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task CreateComment_ReturnsCreated_WhenEmptyCommand()
        {
            // Arrange
            var invalidComment = new CreateCommentCmd(); // Empty Command
            var createdComment = new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "Test Comment.", Description = "Test Description." };
            _mockCommentService.Setup(service => service.CreateAsync(It.IsAny<CreateCommentCmd>())).ReturnsAsync(createdComment);

            // Act
            var result = await _controller.CreateComment(invalidComment);

            // Assert
            var actionResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
            Assert.IsType<CommentDto>(actionResult.Value);
            var returnValue = (CommentDto)actionResult.Value;
            Assert.Equal("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", returnValue.Id);
            Assert.Equal("Test Comment.", returnValue.Title);
            Assert.Equal("Test Description.", returnValue.Description);
        }

        /// <summary>
        /// The UpdateComment_ReturnsNoContent_WhenUpdatedSuccessfully
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task UpdateComment_ReturnsNoContent_WhenUpdatedSuccessfully()
        {
            // Arrange
            var updateCommentCmd = new UpdateCommentCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "Updated Comment.", Description = "Updated Description." };
            _mockCommentService.Setup(service => service.GetByIdAsync("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a")).ReturnsAsync(new CommentDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a" });
            _mockCommentService.Setup(service => service.UpdateAsync(It.IsAny<UpdateCommentCmd>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateComment(updateCommentCmd);

            // Assert
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        }

        /// <summary>
        /// The DeleteComment_ReturnsNoContent_WhenDeletedSuccessfully
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task DeleteComment_ReturnsNoContent_WhenDeletedSuccessfully()
        {
            // Arrange
            var commentId = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";
            _mockCommentService.Setup(service => service.GetByIdAsync(commentId)).ReturnsAsync(new CommentDto { Id = commentId });
            _mockCommentService.Setup(service => service.DeleteAsync(commentId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteComment(commentId);

            // Assert
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        }
    }
}
