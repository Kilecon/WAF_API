namespace WAF_API_Domain.Comment.ValueObject
{
    /// <summary>
    /// Defines the <see cref="Sentence" />
    /// </summary>
    public class Sentence
    {
        /// <summary>
        /// Gets the Value
        /// </summary>
        public string? Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sentence"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="string"/></param>
        public Sentence(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Value = "Untitled comment";
                return;
            }

            Value = char.ToUpper(value[0]) + value.Substring(1);
        }
    }
}
