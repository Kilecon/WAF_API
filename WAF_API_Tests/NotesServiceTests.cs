namespace WAF_API_Application.Tests
{
    using Moq;
    using WAF_API_Application.Services;
    using WAF_API_Domain.Note.Commands;
    using WAF_API_Domain.Note.Dtos;
    using WAF_API_Domain.Note.Factory;
    using WAF_API_Exceptions.ApplicationExceptions;
    using WAF_API_Exceptions.InfrastructureExceptions;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="NotesServiceTests" />
    /// </summary>
    public class NotesServiceTests
    {
        /// <summary>
        /// Defines the _mockFactory
        /// </summary>
        private readonly Mock<INoteFactory> _mockFactory;

        /// <summary>
        /// Defines the _mockRepository
        /// </summary>
        private readonly Mock<IBaseRepository<ChallengeDto>> _mockRepository;

        /// <summary>
        /// Defines the _service
        /// </summary>
        private readonly NoteService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesServiceTests"/> class.
        /// </summary>
        public NotesServiceTests()
        {
            _mockFactory = new Mock<INoteFactory>();
            _mockRepository = new Mock<IBaseRepository<ChallengeDto>>();
            _service = new NoteService(_mockFactory.Object, _mockRepository.Object);
        }

        /// <summary>
        /// The UpdateAsync_ShouldThrowInvalidIdException_WhenIdIsNotFound
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task UpdateAsync_ShouldThrowInvalidIdException_WhenIdIsNotFound()
        {
            // Arrange
            var cmd = new UpdateNoteCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "Updated Title", Description = "Updated Description" };
            _mockRepository.Setup(r => r.GetItemById(cmd.Id)).Throws(new NotInDbException("Note not found"));

            var err = new InvalidIdException();

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidIdException>(() => _service.UpdateAsync(cmd));
            Assert.Equal(err.Message, exception.Message);
        }

        /// <summary>
        /// The DeleteAsync_ShouldDeleteNote_WhenIdExists
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task DeleteAsync_ShouldDeleteNote_WhenIdExists()
        {
            // Arrange
            var id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";
            var dto = new ChallengeDto { Id = id, Title = "Test Title", Description = "Test Description" };
            _mockRepository.Setup(r => r.GetItemById(id)).ReturnsAsync(dto);
            _mockRepository.Setup(r => r.DeleteByIdAsync(id)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteAsync(id);

            // Assert
            _mockRepository.Verify(r => r.DeleteByIdAsync(id), Times.Once);
        }

        /// <summary>
        /// The DeleteAsync_ShouldThrowNotInDbException_WhenIdNotFound
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        [Fact]
        public async Task DeleteAsync_ShouldThrowNotInDbException_WhenIdNotFound()
        {
            // Arrange
            var id = "non-existent-id";
            _mockRepository.Setup(r => r.GetItemById(id)).Throws(new NotInDbException("Note not found"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<NotInDbException>(() => _service.DeleteAsync(id));
            Assert.Equal("Note not found", exception.Message);
        }
    }
}
