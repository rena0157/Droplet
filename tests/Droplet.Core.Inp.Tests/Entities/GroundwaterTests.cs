using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Parsers;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Entities
{
    public class GroundwaterTests : InpFileTests
    {
        /// <summary>
        /// Default Constructor that obtains a logger from Xunit
        /// </summary>
        /// <param name="logger">The logger that is passed from Xunit</param>
        public GroundwaterTests(ITestOutputHelper logger) : base(logger)
        {

        }

        #region Tests

        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string inpString, Groundwater expectedGroundwater)
        {
            FileLinesFromString(inpString);

            var subcatchment = new Subcatchment
            {
                Name = "1"
            };

            var project = new InpProject();
            project.Entities.Add(subcatchment);

            var parser = new InpTableSection(project, "GROUNDWATER");
            parser.ReadSection(this);

            Assert.Equal(expectedGroundwater, subcatchment.GroundwaterData);
        }

        #endregion

        #region TestData

        /// <summary>
        /// Test data for the <see cref="GroundwaterTests.ParserTests(string, Groundwater)"/> tests
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    // ;;Subcatchment   Aquifer          Node             Esurf  A1     B1     A2     B2     A3     Dsw    Egwt   Ebot   Wgr    Umc   
                    "1                Test             *                0      0      0      0      0      0      0      *     \n",

                    // Expected Groundwater from the inp string above
                    new Groundwater
                    {
                        ReferencedEntityNames = new List<string> {"3", "Test", "*"},
                        SurfaceElevation = 0.0,
                        InfluenceMultiplier = 0.0,
                        InfluenceExponent = 0.0,
                        TailWaterInfluenceMultiplier = 0.0,
                        TailWaterInfluenceExponent = 0.0,
                        CombinedMultiplier = 0.0,
                        SurfaceWaterDepth = 0.0,
                        MinWaterTableElevation = 0.0,
                        ElevationOfAquiferBottom = 0.0,
                        UnsaturatedZoneMoisture = 0.0
                    }

                };
            }

            /// <summary>
            /// Implementation of the <see cref="IEnumerable"/> interface
            /// </summary>
            /// <returns>Returns: the enumerator for this class</returns>
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

    }
}
