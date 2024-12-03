namespace WAF_API_Tests
{

    /// <summary>
    /// Defines the <see cref="RatingsPrésentationTests" />
    /// </summary>
    public class RatingsPrésentationTests
    {
        ///// <summary>
        ///// Defines the _mockRatingService
        ///// </summary>
        //private readonly Mock<IRatingService> _mockRatingService;

        ///// <summary>
        ///// Defines the _controller
        ///// </summary>
        //private readonly RatingsController _controller;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="RatingsPrésentationTests"/> class.
        ///// </summary>
        //public RatingsPrésentationTests()
        //{
        //    _mockRatingService = new Mock<IRatingService>();
        //    _controller = new RatingsController(_mockRatingService.Object);
        //}

        ///// <summary>
        ///// The GetRatings_ReturnsOk_WhenRatingsExist
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetRatings_ReturnsOk_WhenRatingsExist()
        //{
        //    // Arrange
        //    var comments = new List<RatingDto>
        //    {
        //        new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Test Rating 1.", Description = "Description 1." },
        //        new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b36a", Sentence = "Test Rating 2.", Description = "Description 2." }
        //    };
        //    _mockRatingService.Setup(service => service.GetAllAsync()).ReturnsAsync(comments);

        //    // Act
        //    var result = await _controller.GetRatings();

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<IEnumerable<RatingDto>>>(result);
        //    var requestResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(200, requestResult.StatusCode);
        //    Assert.Equal(comments, requestResult.Value);
        //}

        ///// <summary>
        ///// The GetRatings_ReturnsEnhanceYourCalm_WhenExceptionThrown
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetRatings_ReturnsEnhanceYourCalm_WhenExceptionThrown()
        //{
        //    // Arrange
        //    _mockRatingService.Setup(service => service.GetAllAsync()).ThrowsAsync(new Exception());

        //    // Act
        //    var result = await _controller.GetRatings();

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<IEnumerable<RatingDto>>>(result);
        //    var statusCodeResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(420, statusCodeResult.StatusCode);
        //}

        ///// <summary>
        ///// The GetRatingById_ReturnsOk_WhenRatingExists
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetRatingById_ReturnsOk_WhenRatingExists()
        //{
        //    // Arrange
        //    var comment = new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Test Rating.", Description = "Description." };
        //    _mockRatingService.Setup(service => service.GetByIdAsync("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a")).ReturnsAsync(comment);

        //    // Act
        //    var result = await _controller.GetRatingById("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a");
        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<RatingDto>>(result);
        //    var requestResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(200, requestResult.StatusCode);
        //    Assert.Equal(comment, requestResult.Value);
        //}

        ///// <summary>
        ///// The GetRatingById_ReturnsBadRequest_WhenInvalidId
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetRatingById_ReturnsBadRequest_WhenInvalidId()
        //{
        //    // Arrange
        //    _mockRatingService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new InvalidIdException("Invalid ID"));

        //    // Act
        //    var result = await _controller.GetRatingById("invalid");

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<RatingDto>>(result);
        //    var badRequestResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(400, badRequestResult.StatusCode);
        //    Assert.Equal("Invalid ID", badRequestResult.Value);
        //}
        //[Fact]
        //public async Task GetRatingById_ReturnsNotFound_WhenNotInDb()
        //{
        //    // Arrange
        //    _mockRatingService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new NotInDbException());

        //    // Act
        //    var result = await _controller.GetRatingById("invalid");
        //    var err = new NotInDbException();

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<RatingDto>>(result);
        //    var notFoundResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(404, notFoundResult.StatusCode);
        //    Assert.Equal(err.Message, notFoundResult.Value);
        //}
        //[Fact]
        //public async Task GetRatingById_ReturnsTeapot_WhenDbIssues()
        //{
        //    // Arrange
        //    _mockRatingService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new StoreInDbException());

        //    // Act
        //    var result = await _controller.GetRatingById("invalid");
        //    var err = new StoreInDbException();

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<RatingDto>>(result);
        //    var resultt = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(418, resultt.StatusCode);
        //    Assert.Equal(err.Message, resultt.Value);
        //}

        //[Fact]
        //public async Task GetRatingById_ReturnsCalm_WhenExcept()
        //{
        //    // Arrange
        //    _mockRatingService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new Exception());

        //    // Act
        //    var result = await _controller.GetRatingById("invalid");

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<RatingDto>>(result);
        //    var resultt = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(420, resultt.StatusCode);
        //    Assert.Equal("Enhance Your Calm !", resultt.Value);
        //}

        ///// <summary>
        ///// The CreateRating_ReturnsCreated
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task CreateRating_ReturnsCreated()
        //{
        //    // Arrange
        //    var newRating = new CreateRatingCmd { Sentence = "New Rating.", Description = "New Description." };
        //    var createdRating = new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "New Rating.", Description = "New Description." };
        //    _mockRatingService.Setup(service => service.CreateAsync(It.IsAny<CreateRatingCmd>())).ReturnsAsync(createdRating);

        //    // Act
        //    var result = await _controller.CreateRating(newRating);

        //    // Assert
        //    var actionResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
        //    Assert.IsType<RatingDto>(actionResult.Value);
        //    var returnValue = (RatingDto)actionResult.Value;
        //    Assert.Equal("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", returnValue.Id);
        //    Assert.Equal("New Rating.", returnValue.Sentence);
        //    Assert.Equal("New Description.", returnValue.Description);
        //}

        //[Fact]
        //public async Task CreateRating_ReturnsBadRequest()
        //{
        //    // Arrange
        //    var newRating = new CreateRatingCmd { Sentence = "New Rating.", Description = "New Description." };
        //    var createdRating = new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "New Rating.", Description = "New Description." };
        //    _mockRatingService.Setup(service => service.CreateAsync(It.IsAny<CreateRatingCmd>())).ThrowsAsync(new InvalidCommandException());

        //    // Act
        //    var result = await _controller.CreateRating(newRating);
        //    var err = new InvalidCommandException();

        //    // Assert
        //    var actionResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status400BadRequest, actionResult.StatusCode);
        //    Assert.Equal(err.Message, actionResult.Value);
        //}

        //[Fact]
        //public async Task CreateRating_ReturnsCalm()
        //{
        //    // Arrange
        //    var newRating = new CreateRatingCmd { Sentence = "New Rating.", Description = "New Description." };
        //    var createdRating = new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "New Rating.", Description = "New Description." };
        //    _mockRatingService.Setup(service => service.CreateAsync(It.IsAny<CreateRatingCmd>())).ThrowsAsync(new Exception());

        //    // Act
        //    var result = await _controller.CreateRating(newRating);

        //    // Assert
        //    var actionResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(420, actionResult.StatusCode);
        //    Assert.Equal("Enhance Your Calm !", actionResult.Value);
        //}


        ///// <summary>
        ///// The CreateRating_ReturnsCreated_WhenEmptyCommand
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task CreateRating_ReturnsCreated_WhenEmptyCommand()
        //{
        //    // Arrange
        //    var invalidRating = new CreateRatingCmd(); // Empty Command
        //    var createdRating = new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Test Rating.", Description = "Test Description." };
        //    _mockRatingService.Setup(service => service.CreateAsync(It.IsAny<CreateRatingCmd>())).ReturnsAsync(createdRating);

        //    // Act
        //    var result = await _controller.CreateRating(invalidRating);

        //    // Assert
        //    var actionResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
        //    Assert.IsType<RatingDto>(actionResult.Value);
        //    var returnValue = (RatingDto)actionResult.Value;
        //    Assert.Equal("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", returnValue.Id);
        //    Assert.Equal("Test Rating.", returnValue.Sentence);
        //    Assert.Equal("Test Description.", returnValue.Description);
        //}

        ///// <summary>
        ///// The UpdateRating_ReturnsNoContent_WhenUpdatedSuccessfully
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task UpdateRating_ReturnsNoContent_WhenUpdatedSuccessfully()
        //{
        //    // Arrange
        //    var updateRatingCmd = new UpdateRatingCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Updated Rating.", Description = "Updated Description." };
        //    _mockRatingService.Setup(service => service.GetByIdAsync("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a")).ReturnsAsync(new RatingDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a" });
        //    _mockRatingService.Setup(service => service.UpdateAsync(It.IsAny<UpdateRatingCmd>())).Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.UpdateRating(updateRatingCmd);

        //    // Assert
        //    var actionResult = Assert.IsType<StatusCodeResult>(result);
        //    Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        //}

        ///// <summary>
        ///// The DeleteRating_ReturnsNoContent_WhenDeletedSuccessfully
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task DeleteRating_ReturnsNoContent_WhenDeletedSuccessfully()
        //{
        //    // Arrange
        //    var commentId = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";
        //    _mockRatingService.Setup(service => service.GetByIdAsync(commentId)).ReturnsAsync(new RatingDto { Id = commentId });
        //    _mockRatingService.Setup(service => service.DeleteAsync(commentId)).Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.DeleteRating(commentId);

        //    // Assert
        //    var actionResult = Assert.IsType<StatusCodeResult>(result);
        //    Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        //}
    }
}
