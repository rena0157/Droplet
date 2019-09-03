// InpLibTests
// InertialTermsExtensionsTests.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-09:34 AM
// By: Adam Renaud
// 
// ============================================================

using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Options.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Options.Extensions
{
    public class InertialTermsExtensionsTests : TestBase
    {

        [Theory]
        [InlineData("PARTIAL", InertialTerms.Dampen)]
        [InlineData("FULL", InertialTerms.Ignore)]
        [InlineData("NONE", InertialTerms.Keep)]
        public void FromInpStringTest(string value, InertialTerms expectedTerms)
        {
            const InertialTerms terms = InertialTerms.Ignore;
            var (result, newTerms) = terms.FromInpString(value);
            Assert.True(result);
            Assert.Equal(expectedTerms, newTerms);
        }

        public InertialTermsExtensionsTests(ITestOutputHelper logger) : base(logger)
        {
        }
    }
}
