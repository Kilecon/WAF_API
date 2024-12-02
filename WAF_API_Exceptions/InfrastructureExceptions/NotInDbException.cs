namespace WAF_API_Exceptions.InfrastructureExceptions
{
    using System;

    /// <summary>
    /// Defines the <see cref="NotInDbException" />
    /// </summary>
    public class NotInDbException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotInDbException"/> class.
        /// </summary>
        public NotInDbException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotInDbException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public NotInDbException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotInDbException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="inner">The inner<see cref="Exception"/></param>
        public NotInDbException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
