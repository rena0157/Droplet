using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Parsers;
using Droplet.Core.Inp.Tests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Entities
{
    /// <summary>
    /// Class that contains generic tests for all
    /// <see cref="InpEntity"/>s
    /// </summary>
    public class InpEntityTests : InpFileTests
    {
        #region Constructors

        /// <summary>
        /// Default Constructor for this test class
        /// that accepts a logger from Xunit DI
        /// </summary>
        /// <param name="logger">The logger that is passed from Xunit</param>
        public InpEntityTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region EntityTests

        /// <summary>
        /// Base test method for testing <see cref="InpEntity"/> classes
        /// parsing from inp files
        /// </summary>
        /// <param name="inpString">The inp string of an entity</param>
        /// <param name="expectedEntity">The expected entity that should be created from the string</param>
        [Theory]
        [ClassData(typeof(EntityParserTestData))]
        public void EntityParserTests(string inpString, InpEntity expectedEntity)
        {
            var project = new InpProject();
            var parser = new InpTableSection(project, expectedEntity.InpTableName);
            Reader.SetData(inpString);
            parser.ReadSection(Reader);

            var entity = project.Entities.FirstOrDefault();

            Assert.Equal(expectedEntity, entity);
        }

        #endregion

        #region OtherTests

        /// <summary>
        /// Testing the <see cref="InpEntity.ToInpString"/> method
        /// </summary>
        /// <param name="entityType">The entity type that will be tested</param>
        [Theory]
        [InlineData(typeof(Aquifer))]
        [InlineData(typeof(Subcatchment))]
        public void ToInpStringTests(Type entityType)
        {
            var entity = (InpEntity)Activator.CreateInstance(entityType);
            var inpString = entity.ToInpString() + "\n";
            Reader.SetData(inpString);

            var project = new InpProject();
            var parser = new InpTableSection(project, entity.InpTableName);
            parser.ReadSection(Reader);

            Assert.Equal(entity, project.Entities.FirstOrDefault());
        }

        #endregion

        #region Test Data

        /// <summary>
        /// Test data for <see cref="EntityParserTests(string, InpEntity)"/> tests
        /// </summary>
        private class EntityParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Get the inp string and expected entity that
            /// should be generated from that string
            /// </summary>
            /// <returns>Returns: an inp string and the respective entity that
            /// should be generated from that string</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Aquifer Test Data
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

                // Groundwater Test Data
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

                // Outfall Test Data
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

                // Subcatchment Test Data
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
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
