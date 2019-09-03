using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Parsers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Entities
{
    public class SubcatchmentTests : InpFileTests
    {
        /// <summary>
        /// Default constructor for subcatchment tests
        /// </summary>
        /// <param name="logger">The logger that is passed from XUnit</param>
        public SubcatchmentTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Tests for the parsing of the <see cref="Subcatchment"/> entity from the
        /// subcatchment table
        /// </summary>
        /// <param name="inpString">The inp string that will be parsed</param>
        /// <param name="expectedSubcatchment">The expected subcatchment from the inp string that is passed</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string inpString, Subcatchment expectedSubcatchment)
        {
            // Place the string into the filelines array
            FileLinesFromString(inpString);

            // Create the project and parser
            var project = new InpProject();
            var parser = new InpTableSection(project, "SUBCATCHMENTS");

            // Read the section that contains the subcatchments
            parser.ReadSection(this);

            // Assert that the subcatchment equals the expected subcatchment
            Assert.Equal(expectedSubcatchment, project
                .Entities
                .FirstOrDefault(e => e is Subcatchment));
        }

        /// <summary>
        /// Testing the <see cref="InpEntity.ToInpString"/> method as implemented
        /// for the subcatchment class
        /// </summary>
        /// <param name="inpString"></param>
        /// <param name="subcatchment"></param>
        public void ToInpStringTests(string inpString, Subcatchment subcatchment)
        {
            // Create an inp string from the passed subcatchment and
            // send it to the file lines so it can be read later on
            FileLinesFromString(subcatchment.ToInpString() + "\n");
        }

        #endregion

        #region TestData

        /// <summary>
        /// Private class that holds the data for the parser tests
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // subcatchment with description
                yield return new object[]
                {
                    @";;Name           Rain Gage        Outlet           Area     %Imperv  Width    %Slope   CurbLen  SnowPack        
;;-------------- ---------------- ---------------- -------- -------- -------- -------- -------- ----------------
;My Subcatchment
1                *                myStorage        5        25       500      0.5      0                        ",

                    new Subcatchment
                    {
                        Name = "1",
                        Description = "My Subcatchment" + Environment.NewLine,
                        RainGaugeName = "*",
                        OutletName = "myStorage",
                        Area = 5,
                        PercentImpervious = 25,
                        Width = 500,
                        Slope = 0.5,
                        CurbLength = 0,
                    }
                };

                yield return new object[]
                {
                    @";This is a test
;To see what happens
3                *                1                5        50       500      0.5      0                        ",
                    new Subcatchment
                    {
                        Name = "3",
                        RainGaugeName = "*",
                        OutletName = "1",
                        Area = 5,
                        PercentImpervious = 50,
                        Width = 500,
                        Slope = 0.5,
                        CurbLength = 0,
                        Description = @";This is a test
;To see what happens"
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
