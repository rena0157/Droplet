using Droplet.Core.Inp.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests
{
    /// <summary>
    /// A Base class for all tests in this library
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// A logger that can be used to log to the test console
        /// </summary>
        protected ITestOutputHelper Logger { get; }

        /// <summary>
        /// Default Constructor for the test class
        /// </summary>
        /// <param name="logger">The logger that is passed from XUnit</param>
        public TestBase(ITestOutputHelper logger)
        {
            Logger = logger;
        }

        // [Fact]
        public void ReaderTest()
        {
            var project = new InpProject(@"C:\Dev\Droplet\tests\Droplet.Core.Inp.Tests\TestFiles\test.inp");
        }
    }
}
