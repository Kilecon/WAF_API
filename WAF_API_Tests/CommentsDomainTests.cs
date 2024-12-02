namespace WAF_API_Application.Tests
{
    using WAF_API_Domain.Comment.Commands;
    using WAF_API_Domain.Comment.Factory;
    using WAF_API_Exceptions.ApplicationExceptions;

    /// <summary>
    /// Defines the <see cref="CommentsDomainTests" />
    /// </summary>
    public class CommentsDomainTests
    {
        /// <summary>
        /// Defines the _factory
        /// </summary>
        private readonly CommentFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsDomainTests"/> class.
        /// </summary>
        public CommentsDomainTests()
        {
            _factory = new CommentFactory();
        }

        /// <summary>
        /// The CreateIntance_ShouldCreateCommentAr_WhenCommandIsValid
        /// </summary>
        [Fact]
        public void CreateIntance_ShouldCreateCommentAr_WhenCommandIsValid()
        {
            // Arrange
            var cmd = new CreateCommentCmd { Title = "Valid Title.", Description = "Valid Description." };
            var id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";

            // Act
            var result = _factory.CreateIntance(cmd, id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id.Value);
            Assert.Equal(cmd.Title, result.Title.Value);
            Assert.Equal(cmd.Description, result.Description.Value);
            Assert.True(result.LastUpdateUnixTimestamp.Value > 0);
        }

        /// <summary>
        /// The UpdateIntance_ShouldCreateCommentAr_WhenCommandIsValid
        /// </summary>
        [Fact]
        public void UpdateIntance_ShouldCreateCommentAr_WhenCommandIsValid()
        {
            // Arrange
            var cmd = new UpdateCommentCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Title = "Updated Title", Description = "Updated Description." };

            // Act
            var result = _factory.UpdateIntance(cmd);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cmd.Id, result.Id.Value);
            Assert.Equal(cmd.Title, result.Title.Value);
            Assert.Equal(cmd.Description, result.Description.Value);
            Assert.True(result.LastUpdateUnixTimestamp.Value > 0);
        }

        /// <summary>
        /// The UpdateIntance_ShouldThrowInvalidCommandException_WhenCommandIsInvalid
        /// </summary>
        [Fact]
        public void UpdateIntance_ShouldThrowInvalidCommandException_WhenCommandIsInvalid()
        {
            // Arrange
            var cmd = new UpdateCommentCmd { Id = "12345", Title = "Valid.", Description = "Updated Description." };

            var err = new InvalidIdException();
            // Act & Assert
            var exception = Assert.Throws<InvalidIdException>(() => _factory.UpdateIntance(cmd));
            Assert.Equal(err.Message, exception.Message);
        }
    }
}
