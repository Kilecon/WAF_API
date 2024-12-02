namespace WAF_API_Exceptions.ApplicationExceptions
{
    using System;

    /// <summary>
    /// Defines the <see cref="InvalidIdException" />
    /// </summary>
    public class InvalidIdException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidIdException"/> class.
        /// </summary>
        public InvalidIdException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidIdException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public InvalidIdException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidIdException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="inner">The inner<see cref="Exception"/></param>
        public InvalidIdException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
