using System;
using System.IO;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests
{
    /// <summary>
    /// A base class for tests that use a stream. This class uses a
    /// <see cref="MemoryStream"/> as a backing store to hold information
    /// </summary>
    public abstract class FileTestsBase : TestBase, IDisposable
    {
        /// <summary>
        /// Defaul Constructor that initializes this class
        /// </summary>
        /// <param name="logger">Accepts a logger</param>
        public FileTestsBase(ITestOutputHelper logger) : base(logger)
        {
            MemoryStream = new MemoryStream();
        }

        protected MemoryStream MemoryStream { get; }

        /// <summary>
        /// Initialize the <see cref="MemoryStream"/> object
        /// </summary>
        /// <param name="value">The string value that will be stored in the stream</param>
        protected virtual void Initialize(string value)
        {
            using (var writer = new StreamWriter(MemoryStream, leaveOpen: true))
            {
                writer.Write(value);
                writer.Flush();
            }
        }

        /// <summary>
        /// Implementing the <see cref="IDisposable"/> pattern
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)MemoryStream).Dispose();
        }
    }
}
