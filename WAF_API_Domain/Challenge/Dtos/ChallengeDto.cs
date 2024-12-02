namespace WAF_API_Domain.Note.Dtos
{
    using WAF_API_Domain.Models;

    /// <summary>
    /// Defines the <see cref="ChallengeDto" />
    /// </summary>
    public class ChallengeDto : Dto
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
        /// Gets or sets a value indicating whether IsCheked
        /// </summary>
        public bool IsCheked { get; set; }
    }
}
