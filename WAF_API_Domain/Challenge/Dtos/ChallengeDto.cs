namespace WAF_API_Domain.Note.Dtos
{
    using WAF_API_Domain.Models;

    /// <summary>
    /// Defines the <see cref="ChallengeDto" />
    /// </summary>
    public class ChallengeDto : Dto
    {
        public string? Sentence { get; set; }
        public string? Lang { get; set; }
        public IEnumerable<string>? Gamemodes { get; set; }

        public IEnumerable<string>? Categories { get; set; }
        public bool IsCheked { get; set; }
    }
}
