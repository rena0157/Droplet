// InpLib
// InpTableSection.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// By: Adam Renaud
// 
// ============================================================

using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Parsers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests
{
    /// <summary>
    /// Public Test class for the <see cref="Aquifer"/> class
    /// </summary>
    public class AquiferTests : InpFileTests
    {
        /// <summary>
        /// Default constructor that initializes the class and
        /// obtains a logger from XUnit
        /// </summary>
        /// <param name="logger">The logger obtained from XUnit</param>
        public AquiferTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Testing the <see cref="InpEntity.ToInpString"/> method as implemented for
        /// <see cref="Aquifer"/>. This test will create an inp string from the passes aquifer and
        /// then try to re-read the string to recreate the aquifer. The newly created aquifer should
        /// be equal to the original aquifer.
        /// </summary>
        /// <param name="expectedString">Expected inp string. Not used in this test</param>
        /// <param name="aquifer">The aquifer that will be used in this test</param>
        [Theory]
        [ClassData(typeof(ParserData))]
        public void ToInpStringTests(string expectedString, Aquifer aquifer)
        {
            // adding this statement so that the non-usage of the expected string
            // does not give a compiler warning
            if (string.IsNullOrEmpty(expectedString))
                throw new System.ArgumentException("message", nameof(expectedString));

            // Create the inp string from the aquifer and add
            // a new line to the end for the parser to read the line
            var inpString = aquifer.ToInpString() + "\n";

            // Set the inp string as the file lines variable
            Reader.SetData(inpString);

            // Create, read and parse the project including the Aquifer
            // string that was created above.
            var project = new InpProject();
            var parser = new InpTableSection(project, "AQUIFERS");
            parser.ReadSection(Reader);

            // Get the aquifer that was created from the inp string
            var aqiferFromString = project.Entities.FirstOrDefault(e => e is Aquifer);

            // This created aquifer should be equal to the aquifer
            // that was originally passed to the test
            Assert.Equal(aquifer, aqiferFromString);
        }

        #endregion

        #region TestData

        /// <summary>
        /// Data for <see cref="AquiferTests.ParserTests(string, Aquifer)"/> tests
        /// </summary>
        private class ParserData : IEnumerable<object[]>
        {
            /// <summary>
            /// The data that will be passed to <see cref="AquiferTests.ParserTests(string, Aquifer)"/> tests
            /// </summary>
            /// <returns></returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    // Aqifer as taken from an inp file
                    // ;;Name           Por    WP     FC     Ksat   Kslope Tslope ETu    ETs    Seep   Ebot   Egw    Umc    ETupat 
                    "Test             0.5    0.15   0.30   5.0    10.0   15.0   0.35   14.0   0.002  0.0    10.0   0.30         \n",
                    
                    // The expected aquifer from the above string
                    new Aquifer
                    {
                        Name = "Test",
                        Porosity = 0.5,
                        WiltingPoint = 0.15,
                        FieldCapacity = 0.3,
                        Conductivity = 5.0,
                        ConductivitySlope = 10.0,
                        TensionSlope = 15.0,
                        UpperEvaportationFraction = 0.35,
                        LowerEvaporationDepth = 14.0,
                        LowerGroundWaterLossRate = 0.002,
                        BottomElevation = 0.0,
                        WaterTableElevation = 10,
                        UnsaturatedZoneMoisture = 0.3,
                        Description = ""
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
