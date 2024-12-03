namespace WAF_API_Domain.Note.Commands
{
    using WAF_API_Domain.Commands;

    /// <summary>
    /// Defines the <see cref="CreateChallengeCmd" />
    /// </summary>
    public class CreateChallengeCmd : Cmd
    {
        public string? Sentence { get; set; }
        public string? Lang { get; set; }
        public IEnumerable<string>? Gamemodes { get; set; }

        public IEnumerable<string>? Categories { get; set; }
    }
}
