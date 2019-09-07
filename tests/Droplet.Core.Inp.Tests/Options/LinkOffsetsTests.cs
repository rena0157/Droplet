// LinkOffsetsTests.cs
// By: Adam Renaud
// Created: 2019-08-10

using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Options.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    public class LinkOffsetsTests : TestBase
    {
        [Theory]
        [InlineData("DEPTH", LinkOffsets.Depth)]
        [InlineData("ELEVATION", LinkOffsets.Elevation)]
        public void FromInpStringTest(string value, LinkOffsets e)
        {
            var offsetOption = LinkOffsets.Depth;
            var result = offsetOption.FromInpString(value);
            Assert.True(result.Item1);
            offsetOption = result.Item2;
            Assert.Equal(e, offsetOption);
        }

        public LinkOffsetsTests(ITestOutputHelper logger) : base(logger)
        {
        }
    }
}
