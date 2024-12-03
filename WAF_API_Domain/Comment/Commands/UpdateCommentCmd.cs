namespace WAF_API_Domain.Comment.Commands
{
    using WAF_API_Domain.Commands;

    /// <summary>
    /// Defines the <see cref="UpdateCommentCmd" />
    /// </summary>
    public class UpdateCommentCmd : IdCmd
    {
        /// <summary>
        /// Gets or sets the Sentence
        /// </summary>
        public string? Sentence { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string? Description { get; set; }
    }
}
