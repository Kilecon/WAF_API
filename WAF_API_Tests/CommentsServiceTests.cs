namespace WAF_API_Application.Tests
{
    /// <summary>
    /// Defines the <see cref="CommentsServiceTests" />
    /// </summary>
    public class CommentsServiceTests
    {
        ///// <summary>
        ///// Defines the _mockFactory
        ///// </summary>
        //private readonly Mock<ICommentFactory> _mockFactory;

        ///// <summary>
        ///// Defines the _mockRepository
        ///// </summary>
        //private readonly Mock<IBaseRepository<CommentDto>> _mockRepository;

        ///// <summary>
        ///// Defines the _service
        ///// </summary>
        //private readonly CommentService _service;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="CommentsServiceTests"/> class.
        ///// </summary>
        //public CommentsServiceTests()
        //{
        //    _mockFactory = new Mock<ICommentFactory>();
        //    _mockRepository = new Mock<IBaseRepository<CommentDto>>();
        //    _service = new CommentService(_mockFactory.Object, _mockRepository.Object);
        //}

        ///// <summary>
        ///// The UpdateAsync_ShouldThrowInvalidIdException_WhenIdIsNotFound
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task UpdateAsync_ShouldThrowInvalidIdException_WhenIdIsNotFound()
        //{
        //    // Arrange
        //    var cmd = new UpdateCommentCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Updated Sentence", Description = "Updated Description" };
        //    _mockRepository.Setup(r => r.GetItemById(cmd.Id)).Throws(new NotInDbException("Comment not found"));

        //    var err = new InvalidIdException();

        //    // Act & Assert
        //    var exception = await Assert.ThrowsAsync<InvalidIdException>(() => _service.UpdateAsync(cmd));
        //    Assert.Equal(err.Message, exception.Message);
        //}

        ///// <summary>
        ///// The DeleteAsync_ShouldDeleteComment_WhenIdExists
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task DeleteAsync_ShouldDeleteComment_WhenIdExists()
        //{
        //    // Arrange
        //    var id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";
        //    var dto = new CommentDto { Id = id, Sentence = "Test Sentence", Description = "Test Description" };
        //    _mockRepository.Setup(r => r.GetItemById(id)).ReturnsAsync(dto);
        //    _mockRepository.Setup(r => r.DeleteByIdAsync(id)).Returns(Task.CompletedTask);

        //    // Act
        //    await _service.DeleteAsync(id);

        //    // Assert
        //    _mockRepository.Verify(r => r.DeleteByIdAsync(id), Times.Once);
        //}

        ///// <summary>
        ///// The DeleteAsync_ShouldThrowNotInDbException_WhenIdNotFound
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task DeleteAsync_ShouldThrowNotInDbException_WhenIdNotFound()
        //{
        //    // Arrange
        //    var id = "non-existent-id";
        //    _mockRepository.Setup(r => r.GetItemById(id)).Throws(new NotInDbException("Comment not found"));

        //    // Act & Assert
        //    var exception = await Assert.ThrowsAsync<NotInDbException>(() => _service.DeleteAsync(id));
        //    Assert.Equal("Comment not found", exception.Message);
        //}
    }
}
