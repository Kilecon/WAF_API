namespace WAF_API_Domain.ValueObject
{
    using System;

    /// <summary>
    /// Defines the <see cref="LastUpdateUnixTimestamp" />
    /// </summary>
    public class LastUpdateUnixTimestamp
    {
        /// <summary>
        /// Gets the Value
        /// </summary>
        public long Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LastUpdateUnixTimestamp"/> class.
        /// </summary>
        public LastUpdateUnixTimestamp()
        {
            Value = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
    }
}
