using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    public class InpBoolOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">A logger that is passed form Xunit</param>
        public InpBoolOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Testing the parsing from a <see cref="string"/> to a <see cref="bool"/>
        /// using the <see cref="InpBoolOption.FromInpString(string)"/> Method
        /// </summary>
        /// <param name="value">The string value being tested</param>
        /// <param name="expectedValue">The expected boolean value</param>
        [Theory]
        [InlineData("YES", true)]
        [InlineData("NO", false)]
        public void BoolParserTests(string value, bool expectedValue) 
            => Assert.Equal(expectedValue, InpBoolOption.FromInpString(value));

        /// <summary>
        /// Testing the parsing of the <see cref="AllowPondingOption"/>
        /// </summary>
        /// <param name="value">A string value from an inp file</param>
        /// <param name="expectedValue">The expected value of the option</param>
        [Theory]
        [ClassData(typeof(AllowPondingTestData))]
        public void AllowPondingTests(string value, bool expectedValue)
        {
            Initialize(value);
            var project = new InpProject();
            var parser = new InpParser();
            var reader = new InpFileReader(MemoryStream);
            parser.ParseFile(project, reader);

            var option = project.Database.GetOption<AllowPondingOption>();

            Assert.Equal(expectedValue, option.Value);
        }


        #endregion  

        #region Test Data

        /// <summary>
        /// Test data for the <see cref="AllowPondingTests(string, bool)"/> tests
        /// </summary>
        private class AllowPondingTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // True
                yield return new object[]
                {
                    @"[OPTIONS]
ALLOW_PONDING        YES
",

                    true
                };

                // False
                yield return new object[]
                {
                    @"[OPTIONS]
ALLOW_PONDING        NO
",

                    false
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
