using Droplet.Core.Inp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using System.Collections;

namespace Droplet.Core.Inp.Tests.Entities
{
    public class SubcatchmentTests : EntityTests
    {
        #region Constructors

        public SubcatchmentTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Tests

        private const string ValidInpString_WithoutComments = @"[SUBCATCHMENTS]
5                *                *                5        25       500      0.5      0 
";

        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTest_StandardSubcatchmentWithoutComments_ShouldMatchValue(string inpString, Subcatchment expected)
            => ParserTest_ValidInpString_ShouldMatchExpected(inpString, expected);

        private class ParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    ValidInpString_WithoutComments,
                    new Subcatchment
                    {
                        Name = "5",
                        RainGageName = "*",
                        OutletName = "*",
                        Area = 5,
                        PercentImperv = 25,
                        Width = 500,
                        PercentSlope = 0.5,
                        CurbLength = 0
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
