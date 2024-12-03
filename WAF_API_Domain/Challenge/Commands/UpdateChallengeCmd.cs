namespace WAF_API_Domain.Note.Commands
{
    using WAF_API_Domain.Commands;

    /// <summary>
    /// Defines the <see cref="UpdateChallengeCmd" />
    /// </summary>
    public class UpdateChallengeCmd : IdCmd
    {
        public string? Sentence { get; set; }
        public string? Lang { get; set; }
        public IEnumerable<string>? Gamemodes { get; set; }

        public IEnumerable<string>? Categories { get; set; }
        public bool IsChecked { get; set; }
    }
}
