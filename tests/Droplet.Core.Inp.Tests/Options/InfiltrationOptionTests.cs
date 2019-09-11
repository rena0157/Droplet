using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    public class InfiltrationOptionTests : FileTestsBase
    {
        public InfiltrationOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        public void ParserTests(string value)
        {

        }

        #endregion

        #region Test Data

        private class ParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"",

                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
