namespace WAF_API_Domain.Comment.ValueObject
{
    /// <summary>
    /// Defines the <see cref="Title" />
    /// </summary>
    public class Title
    {
        /// <summary>
        /// Gets the Value
        /// </summary>
        public string? Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Title"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="string"/></param>
        public Title(string value)
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
