// InpBoolExtensionsTests.cs
// By: Adam Renaud
// Created: 2019-08-11

using Droplet.Core.Inp.Options.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Options.Extensions
{
    public class InpBoolExtensionTests : TestBase
    {
        /// <summary>
        /// Testing the InpBool Extension
        /// </summary>
        /// <param name="value">String value passed</param>
        /// <param name="expected">The expected outcome</param>
        [Theory]
        [InlineData("YES", true)]
        [InlineData("NO", false)]
        public void BoolExtension(string value, bool expected)
        {
            var ans = false;
            var (success, result) = ans.FromInpString(value);
            Assert.True(success);
            ans = result;
            Assert.Equal(expected, ans);
        }

        /// <summary>
        /// Testing what happens if we pass an unrecognized string
        /// to the extension
        /// </summary>
        [Fact]
        public void BoolExtension_NotRecognized()
        {
            var b = false;
            var (success, result) = b.FromInpString("This Wont Work");
            Assert.False(success);
        }

        public InpBoolExtensionTests(ITestOutputHelper logger) : base(logger)
        {
        }
    }
}
