namespace WAF_API_Domain.Comment.Factory
{
    using WAF_API_Domain.Comment.Commands;
    using WAF_API_Domain.Comment.Entities;

    /// <summary>
    /// Defines the <see cref="ICommentFactory" />
    /// </summary>
    public interface ICommentFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateCommentCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="CommentAr"/></returns>
        CommentAr CreateIntance(CreateCommentCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateCommentCmd"/></param>
        /// <returns>The <see cref="CommentAr"/></returns>
        CommentAr UpdateIntance(UpdateCommentCmd cmd);
    }
}
