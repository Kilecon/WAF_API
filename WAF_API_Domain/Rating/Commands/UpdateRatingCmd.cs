namespace WAF_API_Domain.Rating.Commands
{
    using WAF_API_Domain.Commands;

    /// <summary>
    /// Defines the <see cref="UpdateRatingCmd" />
    /// </summary>
    [Obsolete]
    public class UpdateRatingCmd : IdCmd
    {
        public string? SentenceId { get; set; }
        public decimal Rating { get; set; }
    }
}
