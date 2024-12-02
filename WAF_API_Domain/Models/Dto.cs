namespace WAF_API_Domain.Models
{
    /// <summary>
    /// Defines the <see cref="Dto" />
    /// </summary>
    public abstract class Dto
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the LastUpdateUnixTimestamp
        /// </summary>
        public long LastUpdateUnixTimestamp { get; set; }
    }
}
