using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Parsers;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Entities
{
    /// <summary>
    /// Tests for the <see cref="Outfall"/> class
    /// </summary>
    public class OutfallTests : InpFileTests
    {
        #region Constructors

        /// <summary>
        /// Default Constructor for the <see cref="OutfallTests"/> class
        /// that accepts a logger from Xunit
        /// </summary>
        /// <param name="logger">The logger that is passed from DI</param>
        public OutfallTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Tests

        /// <summary>
        /// Testing the parser for the <see cref="Outfall"/> class.
        /// </summary>
        /// <param name="inpString">The string that will generate an outfall from an inp file</param>
        /// <param name="expectedOutfall">The expected outfall to be generated from the above string</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string inpString, Outfall expectedOutfall)
        {
            // Place the inp string into the file lines array
            FileLinesFromString(inpString);

            // Create and read the project including the 
            var project = new InpProject();
            var parser = new InpTableSection(project, expectedOutfall.InpTableName);
            parser.ReadSection(this);

            // Get the generated outfall
            var outfall = project.Entities.FirstOrDefault();

            // Assert that the generated outfall is equal
            // to the expected outfall passed into the test
            Assert.Equal(expectedOutfall, outfall);
        }

        #endregion

        #region TestData

        /// <summary>
        /// Data container class that holds the data for the 
        /// parser tests in this test class
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Get enumerator implementation that returns
            /// a string that is from an inp file containing an outfall
            /// and an expected outfall that the parser should generate from the
            /// supplied string.
            /// </summary>
            /// <returns>Returns: An InpString and an Outfall</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Testing the parser with a default object
                yield return new object[]
                {
                    // The string below represents an outfall from an inp file
                    // ;;Name           Elevation  Type       Stage Data       Gated    Route To        
                    "2                0          FIXED      1                NO       1               \n",

                    // The outfall that should be generated from
                    // the string above
                    new Outfall
                    {
                        Name = "2",
                        InvertElevation = 0,
                        BoundaryCondition = OutfallBoundaryConditions.Fixed,
                        WaterElevationFixed = 1,
                        TideGate = false,
                        SubcatchmentNameRoutedTo = "1"
                    }
                };
            }

            /// <summary>
            /// Default Implementation of the GetEnumerator Method
            /// </summary>
            /// <returns>Returns: The GetEnumerator from above</returns>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
