namespace WAF_API_Application.Services.CommentService
{
    using WAF_API_Application.Services;
    using WAF_API_Domain.Comment.Dtos;

    /// <summary>
    /// Defines the <see cref="ICommentRepository" />
    /// </summary>
    public interface ICommentRepository : IBaseRepository<CommentDto>
    {
    }
}
