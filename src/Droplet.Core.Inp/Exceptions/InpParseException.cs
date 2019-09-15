using System;

namespace Droplet.Core.Inp.Exceptions
{
    /// <summary>
    /// Exception that is thrown when there was an error parsing
    /// an inp file
    /// </summary>
    [Serializable]
    public class InpParseException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InpParseException() { }

        /// <summary>
        /// Default constructor that accepts a message that will be
        /// passed to the base class
        /// </summary>
        /// <param name="message">The message</param>
        public InpParseException(string message) : base(message) { }

        /// <summary>
        /// Constructor that accepts a message and an inner exception
        /// that will be passed to the base class
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner exception</param>
        public InpParseException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Implements the ability to be serialized
        /// </summary>
        /// <param name="info">The information</param>
        /// <param name="context">The context</param>
        protected InpParseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
