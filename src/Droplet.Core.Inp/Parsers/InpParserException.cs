// InpLib
// InpParserException.cs
// 
// ============================================================
// 
// Created: 2019-08-18
// Last Updated: 2019-08-18-09:43 AM
// By: Adam Renaud
// 
// ============================================================

using System;
using System.Runtime.Serialization;

namespace Droplet.Core.Inp.Parsers
{
    /// <summary>
    /// Exception for the Inp Parser
    /// </summary>
    public class InpParserException : Exception
    {
        /// <summary>
        /// Default Constructor that takes no arguments
        /// </summary>
        public InpParserException()
        {
        }

        /// <summary>
        /// Constructor that takes in two arguments that
        /// are passed to the base constructor
        /// </summary>
        /// <param name="info">The serialization Informatino passed to the base class</param>
        /// <param name="context">The context information that is passed to the base class</param>
        protected InpParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Constructor that accepts a message for the exception
        /// </summary>
        /// <param name="message">A message that will be displayed to the user</param>
        public InpParserException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor that accepts a message for the user to see as well
        /// as an inner exception that is passed to the base constructor
        /// </summary>
        /// <param name="message">The message that will be passed to the user</param>
        /// <param name="innerException">The inner exception that will be passed to the base class</param>
        public InpParserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
