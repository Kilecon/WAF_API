namespace WAF_API_Domain.ValueObject
{
    using WAF_API_Exceptions.ApplicationExceptions;
    using System;

    /// <summary>
    /// Defines the <see cref="Id" />
    /// </summary>
    public class Id
    {
        /// <summary>
        /// Gets the Value
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Id"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="string"/></param>
        public Id(string value)
        {
            try
            {
                Value = Guid.Parse(value).ToString();
            }
            catch (Exception)
            {
                throw new InvalidIdException();
            }
        }
    }

}
