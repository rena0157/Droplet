// ReaderTest.cs
// By: Adam Renaud
// Created: 2019-08-10

using Droplet.Core.Inp;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests
{
    /// <summary>
    /// Test class that holds a reader method for reading
    /// an inp file
    /// </summary>
    public class ReaderTest : TestBase
    {
        private const string Filename = @".\TestFiles\test.inp";

        [Fact]
        public void ReadTest()
        {
            var project = new InpProject(Filename);
            Logger.WriteLine(project.ToInpString());
        }

        public ReaderTest(ITestOutputHelper logger) : base(logger)
        {

        }
    }
}
