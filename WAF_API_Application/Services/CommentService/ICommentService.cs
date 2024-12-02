namespace WAF_API_Application.Services.CommentService
{
    using WAF_API_Domain.Comment.Commands;
    using WAF_API_Domain.Comment.Dtos;
    using System.Threading.Tasks;
    using WAF_API_Application.Services;

    /// <summary>
    /// Defines the <see cref="ICommentService" />
    /// </summary>
    public interface ICommentService : IService<CommentDto, CreateCommentCmd, UpdateCommentCmd>
    {
        /// <summary>
        /// The UpdateAsync
        /// </summary>
        /// <param name="comment">The comment<see cref="UpdateCommentCmd"/></param>
        /// <returns>The <see cref="Task"/></returns>
        Task UpdateAsync(UpdateCommentCmd comment);
    }
}
