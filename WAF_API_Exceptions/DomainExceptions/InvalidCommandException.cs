namespace WAF_API_Exceptions.DomainExceptions
{
    using System;

    /// <summary>
    /// Defines the <see cref="InvalidCommandException" />
    /// </summary>
    public class InvalidCommandException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCommandException"/> class.
        /// </summary>
        public InvalidCommandException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCommandException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public InvalidCommandException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCommandException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="inner">The inner<see cref="Exception"/></param>
        public InvalidCommandException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
