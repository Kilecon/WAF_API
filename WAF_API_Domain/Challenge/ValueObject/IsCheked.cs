namespace WAF_API_Domain.Note.ValueObject
{
    /// <summary>
    /// Defines the <see cref="IsChecked" />
    /// </summary>
    public class IsChecked
    {
        /// <summary>
        /// Gets a value indicating whether Value
        /// </summary>
        public bool Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IsChecked"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="bool"/></param>
        public IsChecked(bool value)
        {
            Value = value;
        }
    }
}
