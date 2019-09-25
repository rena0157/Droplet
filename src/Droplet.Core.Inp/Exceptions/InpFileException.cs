using System;

namespace Droplet.Core.Inp.Exceptions
{

    /// <summary>
    /// Exception that is thrown if there is an error reading
    /// an inp file
    /// </summary>
    [Serializable]
    public class InpFileException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InpFileException() { }

        /// <summary>
        /// Default Constructor that accepts a message
        /// </summary>
        /// <param name="message">The message that will be passed to <see cref="Exception.Message"/></param>
        public InpFileException(string message) : base(message) { }

        /// <summary>
        /// Constructor that accepts a message and an inner <see cref="Exception"/>
        /// </summary>
        /// <param name="message">The message that will be passed to <see cref="Exception.Message"/></param>
        /// <param name="inner">The inner <see cref="Exception"/> that will become the <see cref="Exception.InnerException"/></param>
        public InpFileException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Protected constructor that allows this exception to be serialized
        /// </summary>
        /// <param name="info">The Serialization Information</param>
        /// <param name="context">The Streaming Context</param>
        protected InpFileException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
