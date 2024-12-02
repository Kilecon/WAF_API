namespace WAF_API_Infrastructure.Repositories
{
    using MongoDB.Driver;
    using WAF_API_Application.Services;
    using WAF_API_Application.Services.CommentService;
    using WAF_API_Domain.Comment.Dtos;

    /// <summary>
    /// Defines the <see cref="CommentRepository" />
    /// </summary>
    public class CommentRepository(IMongoDatabase database) : BaseRepository<CommentDto>(database), ICommentRepository
    {
    }
}
