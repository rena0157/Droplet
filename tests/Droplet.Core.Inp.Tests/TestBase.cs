using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests
{
    /// <summary>
    /// Base class for all test classes
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// Default Logger for TestBase
        /// </summary>
        protected ITestOutputHelper Logger;

        /// <summary>
        /// Default Constructor for the test base class
        /// </summary>
        /// <param name="logger">A logger that is passed from XUnit</param>
        public TestBase(ITestOutputHelper logger) { Logger = logger; }
    }
}
