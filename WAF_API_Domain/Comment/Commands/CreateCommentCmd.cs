namespace WAF_API_Domain.Comment.Commands
{
    using WAF_API_Domain.Commands;

    /// <summary>
    /// Defines the <see cref="CreateCommentCmd" />
    /// </summary>
    public class CreateCommentCmd : Cmd
    {
        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string? Description { get; set; }
    }
}
