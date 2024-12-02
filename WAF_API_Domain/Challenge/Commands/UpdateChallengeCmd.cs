namespace WAF_API_Domain.Note.Commands
{
    using WAF_API_Domain.Commands;

    /// <summary>
    /// Defines the <see cref="UpdateChallengeCmd" />
    /// </summary>
    public class UpdateChallengeCmd : IdCmd
    {
        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsChecked
        /// </summary>
        public bool IsChecked { get; set; }
    }
}
