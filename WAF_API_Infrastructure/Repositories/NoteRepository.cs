namespace WAF_API_Infrastructure.Repositories
{
    using MongoDB.Driver;
    using WAF_API_Application.Services.NoteService;
    using WAF_API_Domain.Note.Dtos;

    /// <summary>
    /// Defines the <see cref="NoteRepository" />
    /// </summary>
    public class NoteRepository(IMongoDatabase database) : BaseRepository<ChallengeDto>(database), IChallengeRepository
    {
    }
}
