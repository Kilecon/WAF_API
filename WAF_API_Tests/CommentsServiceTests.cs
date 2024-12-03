namespace WAF_API_Application.Tests
{
    /// <summary>
    /// Defines the <see cref="RatingsServiceTests" />
    /// </summary>
    public class RatingsServiceTests
    {
        ///// <summary>
        ///// Defines the _mockFactory
        ///// </summary>
        //private readonly Mock<IRatingFactory> _mockFactory;

        ///// <summary>
        ///// Defines the _mockRepository
        ///// </summary>
        //private readonly Mock<IBaseRepository<RatingDto>> _mockRepository;

        ///// <summary>
        ///// Defines the _service
        ///// </summary>
        //private readonly RatingService _service;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="RatingsServiceTests"/> class.
        ///// </summary>
        //public RatingsServiceTests()
        //{
        //    _mockFactory = new Mock<IRatingFactory>();
        //    _mockRepository = new Mock<IBaseRepository<RatingDto>>();
        //    _service = new RatingService(_mockFactory.Object, _mockRepository.Object);
        //}

        ///// <summary>
        ///// The UpdateAsync_ShouldThrowInvalidIdException_WhenIdIsNotFound
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task UpdateAsync_ShouldThrowInvalidIdException_WhenIdIsNotFound()
        //{
        //    // Arrange
        //    var cmd = new UpdateRatingCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Updated Sentence", Description = "Updated Description" };
        //    _mockRepository.Setup(r => r.GetItemById(cmd.Id)).Throws(new NotInDbException("Rating not found"));

        //    var err = new InvalidIdException();

        //    // Act & Assert
        //    var exception = await Assert.ThrowsAsync<InvalidIdException>(() => _service.UpdateAsync(cmd));
        //    Assert.Equal(err.Message, exception.Message);
        //}

        ///// <summary>
        ///// The DeleteAsync_ShouldDeleteRating_WhenIdExists
        ///// </summary>
        ///// <returns>The <see cref="Task"/></returns>
        //[Fact]
        //public async Task DeleteAsync_ShouldDeleteRating_WhenIdExists()
        //{
        //    // Arrange
        //    var id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";
        //    var dto = new RatingDto { Id = id, Sentence = "Test Sentence", Description = "Test Description" };
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
        //    _mockRepository.Setup(r => r.GetItemById(id)).Throws(new NotInDbException("Rating not found"));

        //    // Act & Assert
        //    var exception = await Assert.ThrowsAsync<NotInDbException>(() => _service.DeleteAsync(id));
        //    Assert.Equal("Rating not found", exception.Message);
        //}
    }
}
