namespace WAF_API_Domain.Models
{
    /// <summary>
    /// Defines the <see cref="StoredDto{TDto}" />
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    public class StoredDto<TDto> where TDto : Dto
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the TypeName
        /// </summary>
        public string? TypeName { get; set; }

        /// <summary>
        /// Gets or sets the Payload
        /// </summary>
        public TDto? Payload { get; set; }

        /// <summary>
        /// Gets or sets the LastUpdateUnixTimestamp
        /// </summary>
        public long LastUpdateUnixTimestamp { get; set; }
    }
}
