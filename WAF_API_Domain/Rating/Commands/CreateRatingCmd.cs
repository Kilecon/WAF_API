namespace WAF_API_Domain.Rating.Commands
{
    using WAF_API_Domain.Commands;

    /// <summary>
    /// Defines the <see cref="CreateRatingCmd" />
    /// </summary>
    public class CreateRatingCmd : Cmd
    {
        public string? SentenceId { get; set; }
        public decimal Rating { get; set; }
    }
}
