using Droplet.Core.Inp.Utilities;
using System;
using System.Globalization;
using System.Resources;

namespace Droplet.Core.Inp.Exceptions
{
    /// <summary>
    /// Exception that is thrown when there was an error parsing
    /// an inp file
    /// </summary>
    [Serializable]
    public class InpParseException : Exception
    {
        #region Internal Helpers

        /// <summary>
        /// Create a new <see cref="InpParseException"/> with the default Culture appropriate message
        /// </summary>
        /// <param name="type">The type where the exception occurred</param>
        /// <returns>Returns: an <see cref="InpParseException"/> with the default message set</returns>
        internal static InpParseException CreateWithStandardMessage(Type type)
        {
            try
            {
                // Get the message from the resource manager
                var message = new InpResourceManager().GetString("InpParseException.DefaultMessage", CultureInfo.CurrentCulture);

                // Return a new inp parse exception
                return new InpParseException(message + type?.FullName);
            }
            catch(MissingManifestResourceException)
            {
                return new InpParseException();
            }
            catch(InvalidOperationException)
            {
                return new InpParseException();
            }
            catch (MissingSatelliteAssemblyException)
            {
                return new InpParseException();
            }
        }

        /// <summary>
        /// Create a new <see cref="InpParseException"/> with the default Culture appropriate message 
        /// and include the inner <see cref="Exception"/>
        /// </summary>
        /// <param name="type">The type where the exception occurred</param>
        /// <param name="inner">The inner Exception</param>
        /// <returns>Returns: A new <see cref="InpParseException"/></returns>
        internal static InpParseException CreateWithStandardMessage(Type type, Exception inner)
        {
            try
            {
                // Get message from the resource manager
                var message = new InpResourceManager().GetString("InpParseException.DefaultMessage", CultureInfo.CurrentCulture);

                // Return the exception and set the message and the inner exception
                return new InpParseException(message + type?.FullName, inner);
            }
            // Catch any other exceptions that could occur because of the above
            catch (MissingManifestResourceException)
            {
                return new InpParseException();
            }
            catch (InvalidOperationException)
            {
                return new InpParseException();
            }
            catch (MissingSatelliteAssemblyException)
            {
                return new InpParseException();
            }
        }

        /// <summary>
        /// Create a new <see cref="InpParseException"/> with the default Culture appropriate message and include 
        /// the inner exception
        /// </summary>
        /// <param name="nameofMember">The name of the member being parsed</param>
        /// <param name="type">The type where the exception occurred</param>
        /// <param name="inner">The inner exception</param>
        /// <returns>Returns: A new <see cref="InpParseException"/></returns>
        internal static InpParseException CreateWithStandardMessage(string nameofMember, Type type)
        {
            try
            {
                // Get message from the resource manager
                var message = new InpResourceManager().GetString("InpParseException.MessageWithNameAndType", CultureInfo.CurrentCulture);

                // Return the exception and set the message and the inner exception
                return new InpParseException(message + type?.FullName + " " + nameofMember);
            }
            // Catch any other exceptions that could occur because of the above
            catch (MissingManifestResourceException)
            {
                return new InpParseException();
            }
            catch (InvalidOperationException)
            {
                return new InpParseException();
            }
            catch (MissingSatelliteAssemblyException)
            {
                return new InpParseException();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public InpParseException()
        {
        }

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

        #endregion
    }
}
