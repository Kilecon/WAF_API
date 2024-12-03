namespace WAF_API_Application.Tests
{

    /// <summary>
    /// Defines the <see cref="NotesDomainTests" />
    /// </summary>
    public class NotesDomainTests
    {
        ///// <summary>
        ///// Defines the _factory
        ///// </summary>
        //private readonly NoteFactory _factory;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="NotesDomainTests"/> class.
        ///// </summary>
        //public NotesDomainTests()
        //{
        //    _factory = new NoteFactory();
        //}

        ///// <summary>
        ///// The CreateIntance_ShouldCreateNoteAr_WhenCommandIsValid
        ///// </summary>
        //[Fact]
        //public void CreateIntance_ShouldCreateNoteAr_WhenCommandIsValid()
        //{
        //    // Arrange
        //    var cmd = new CreateNoteCmd { Sentence = "Valid Sentence.", Description = "Valid Description." };
        //    var id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a";

        //    // Act
        //    var result = _factory.CreateIntance(cmd, id);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(id, result.Id.Value);
        //    Assert.Equal(cmd.Sentence, result.Sentence.Value);
        //    Assert.Equal(cmd.Description, result.Description.Value);
        //    Assert.True(result.LastUpdateUnixTimestamp.Value > 0);
        //}

        ///// <summary>
        ///// The UpdateIntance_ShouldCreateNoteAr_WhenCommandIsValid
        ///// </summary>
        //[Fact]
        //public void UpdateIntance_ShouldCreateNoteAr_WhenCommandIsValid()
        //{
        //    // Arrange
        //    var cmd = new UpdateNoteCmd { Id = "7af6dfb8-aaf7-4ed6-ab2c-c7635c79b34a", Sentence = "Updated Sentence", Description = "Updated Description.", IsChecked = true };

        //    // Act
        //    var result = _factory.UpdateIntance(cmd);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(cmd.Id, result.Id.Value);
        //    Assert.Equal(cmd.Sentence, result.Sentence.Value);
        //    Assert.Equal(cmd.Description, result.Description.Value);
        //    Assert.True(result.LastUpdateUnixTimestamp.Value > 0);
        //}

        ///// <summary>
        ///// The UpdateIntance_ShouldThrowInvalidCommandException_WhenCommandIsInvalid
        ///// </summary>
        //[Fact]
        //public void UpdateIntance_ShouldThrowInvalidCommandException_WhenCommandIsInvalid()
        //{
        //    // Arrange
        //    var cmd = new UpdateNoteCmd { Id = "12345", Sentence = "Valid.", Description = "Updated Description.", IsChecked = true };

        //    var err = new InvalidIdException();
        //    // Act & Assert
        //    var exception = Assert.Throws<InvalidIdException>(() => _factory.UpdateIntance(cmd));
        //    Assert.Equal(err.Message, exception.Message);
        //}
    }
}
