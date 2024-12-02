namespace WAF_API_Exceptions.InfrastructureExceptions
{
    using System;

    /// <summary>
    /// Defines the <see cref="StoreInDbException" />
    /// </summary>
    public class StoreInDbException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreInDbException"/> class.
        /// </summary>
        public StoreInDbException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreInDbException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public StoreInDbException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreInDbException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="inner">The inner<see cref="Exception"/></param>
        public StoreInDbException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
