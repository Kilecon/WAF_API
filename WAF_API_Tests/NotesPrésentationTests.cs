namespace WAF_API_Tests
{


    /// <summary>
    /// Defines the <see cref="NotesPrésentationTests" />
    /// </summary>
    public class NotesPrésentationTests
    {
        ///// <summary>
        ///// Defines the _mockNoteService
        ///// </summary>
        //private readonly Mock<INoteService> _mockNoteService;

        ///// <summary>
        ///// Defines the _controller
        ///// </summary>
        //private readonly NotesController _controller;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="NotesPrésentationTests"/> class.
        ///// </summary>
        //public NotesPrésentationTests()
        //{
        //    _mockNoteService = new Mock<INoteService>();
        //    _controller = new NotesController(_mockNoteService.Object);
        //}

        ///// <summary>
        ///// The GetNotes_ReturnsOk_WhenNotesExist
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetNotes_ReturnsOk_WhenNotesExist()
        //{
        //    // Arrange
        //    var comments = new List<ChallengeDto>
        //    {
        //        new ChallengeDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Test Note 1.", Description = "Description 1." },
        //        new ChallengeDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b36a", Sentence = "Test Note 2.", Description = "Description 2." }
        //    };
        //    _mockNoteService.Setup(service => service.GetAllAsync()).ReturnsAsync(comments);

        //    // Act
        //    var result = await _controller.GetNotes();

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<IEnumerable<ChallengeDto>>>(result);
        //    var requestResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(200, requestResult.StatusCode);
        //    Assert.Equal(comments, requestResult.Value);
        //}

        ///// <summary>
        ///// The GetNotes_ReturnsEnhanceYourCalm_WhenExceptionThrown
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetNotes_ReturnsEnhanceYourCalm_WhenExceptionThrown()
        //{
        //    // Arrange
        //    _mockNoteService.Setup(service => service.GetAllAsync()).ThrowsAsync(new Exception());

        //    // Act
        //    var result = await _controller.GetNotes();

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<IEnumerable<ChallengeDto>>>(result);
        //    var statusCodeResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(420, statusCodeResult.StatusCode);
        //}

        ///// <summary>
        ///// The GetNoteById_ReturnsOk_WhenNoteExists
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetNoteById_ReturnsOk_WhenNoteExists()
        //{
        //    // Arrange
        //    var comment = new ChallengeDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Test Note.", Description = "Description." };
        //    _mockNoteService.Setup(service => service.GetByIdAsync("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a")).ReturnsAsync(comment);

        //    // Act
        //    var result = await _controller.GetNoteById("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a");
        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<ChallengeDto>>(result);
        //    var requestResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(200, requestResult.StatusCode);
        //    Assert.Equal(comment, requestResult.Value);
        //}

        //[Fact]
        //public async Task GetNoteById_ReturnsOk_WhenNoteNotExists()
        //{
        //    _mockNoteService.Setup(service => service.GetByIdAsync("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b33a")).ThrowsAsync(new NotInDbException());

        //    // Act
        //    var result = await _controller.GetNoteById("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b33a");
        //    var err = new NotInDbException();
        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<ChallengeDto>>(result);
        //    var requestResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(404, requestResult.StatusCode);
        //    Assert.Equal(err.Message, requestResult.Value);
        //}

        ///// <summary>
        ///// The GetNoteById_ReturnsBadRequest_WhenInvalidId
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task GetNoteById_ReturnsBadRequest_WhenInvalidId()
        //{
        //    // Arrange
        //    _mockNoteService.Setup(service => service.GetByIdAsync("invalid")).ThrowsAsync(new InvalidIdException("Invalid ID"));

        //    // Act
        //    var result = await _controller.GetNoteById("invalid");

        //    // Assert
        //    var actionResult = Assert.IsType<ActionResult<ChallengeDto>>(result);
        //    var badRequestResult = Assert.IsType<ObjectResult>(actionResult.Result);
        //    Assert.Equal(400, badRequestResult.StatusCode);
        //    Assert.Equal("Invalid ID", badRequestResult.Value);
        //}

        ///// <summary>
        ///// The CreateNote_ReturnsCreated
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task CreateNote_ReturnsCreated()
        //{
        //    // Arrange
        //    var newNote = new CreateNoteCmd { Sentence = "New Note.", Description = "New Description." };
        //    var createdNote = new ChallengeDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "New Note.", Description = "New Description." };
        //    _mockNoteService.Setup(service => service.CreateAsync(It.IsAny<CreateNoteCmd>())).ReturnsAsync(createdNote);

        //    // Act
        //    var result = await _controller.CreateNote(newNote);

        //    // Assert
        //    var actionResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
        //    Assert.IsType<ChallengeDto>(actionResult.Value);
        //    var returnValue = (ChallengeDto)actionResult.Value;
        //    Assert.Equal("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", returnValue.Id);
        //    Assert.Equal("New Note.", returnValue.Sentence);
        //    Assert.Equal("New Description.", returnValue.Description);
        //}

        ///// <summary>
        ///// The CreateNote_ReturnsCreated_WhenEmptyCommand
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task CreateNote_ReturnsCreated_WhenEmptyCommand()
        //{
        //    // Arrange
        //    var invalidNote = new CreateNoteCmd(); // Empty Command
        //    var createdNote = new ChallengeDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Test Note.", Description = "Test Description." };
        //    _mockNoteService.Setup(service => service.CreateAsync(It.IsAny<CreateNoteCmd>())).ReturnsAsync(createdNote);

        //    // Act
        //    var result = await _controller.CreateNote(invalidNote);

        //    // Assert
        //    var actionResult = Assert.IsType<ObjectResult>(result);
        //    Assert.Equal(StatusCodes.Status201Created, actionResult.StatusCode);
        //    Assert.IsType<ChallengeDto>(actionResult.Value);
        //    var returnValue = (ChallengeDto)actionResult.Value;
        //    Assert.Equal("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", returnValue.Id);
        //    Assert.Equal("Test Note.", returnValue.Sentence);
        //    Assert.Equal("Test Description.", returnValue.Description);
        //}

        ///// <summary>
        ///// The UpdateNote_ReturnsNoContent_WhenUpdatedSuccessfully
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task UpdateNote_ReturnsNoContent_WhenUpdatedSuccessfully()
        //{
        //    // Arrange
        //    var updateNoteCmd = new UpdateNoteCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Updated Note.", Description = "Updated Description.", IsChecked = true };
        //    _mockNoteService.Setup(service => service.GetByIdAsync("7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a")).ReturnsAsync(new ChallengeDto { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a" });
        //    _mockNoteService.Setup(service => service.UpdateAsync(It.IsAny<UpdateNoteCmd>())).Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.UpdateNote(updateNoteCmd);

        //    // Assert
        //    var actionResult = Assert.IsType<StatusCodeResult>(result);
        //    Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        //}

        ///// <summary>
        ///// The DeleteNote_ReturnsNoContent_WhenDeletedSuccessfully
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task DeleteNote_ReturnsNoContent_WhenDeletedSuccessfully()
        //{
        //    // Arrange
        //    var commentId = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";
        //    _mockNoteService.Setup(service => service.GetByIdAsync(commentId)).ReturnsAsync(new ChallengeDto { Id = commentId });
        //    _mockNoteService.Setup(service => service.DeleteAsync(commentId)).Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.DeleteNote(commentId);

        //    // Assert
        //    var actionResult = Assert.IsType<StatusCodeResult>(result);
        //    Assert.Equal(StatusCodes.Status204NoContent, actionResult.StatusCode);
        //}
    }
}
