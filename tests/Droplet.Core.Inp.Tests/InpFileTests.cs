// InpFileTests.cs
// By: Adam Renaud
// Created: 2019-08-17

using System;
using System.IO;
using Droplet.Core.Inp.IO;
using Xunit;
using Xunit.Abstractions;
using Droplet.Core.Inp.Parsers;
using Droplet.Core.Inp.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Droplet.Core.Inp.Tests
{
    /// <summary>
    /// A testing class that inherits from <see cref="IInpReader"/> so that
    /// it can be passed to the <see cref="InpParser"/> and the contents
    /// of the filelines can be read
    /// </summary>
    public class InpFileTests : TestBase
    {
        /// <summary>
        /// The reader that can be used to read strings
        /// from an inp file and simulates the <see cref="InpReader"/> class
        /// </summary>
        protected InpStringReader Reader { get; set; }

        /// <summary>
        /// The default constructor for the <see cref="InpFileTests"/> class
        /// </summary>
        /// <param name="logger">The logger that is passed for Xunit</param>
        public InpFileTests(ITestOutputHelper logger) : base(logger)
        {
            Reader = new InpStringReader();
        }

        /// <summary>
        /// Base test method for testing <see cref="InpEntity"/> classes
        /// parsing from inp files
        /// </summary>
        /// <param name="inpString">The inp string of an entity</param>
        /// <param name="expectedEntity">The expected entity that should be created from the string</param>
        public void EntityParserTests(string inpString, InpEntity expectedEntity)
        {
            var project = new InpProject();
            var parser = new InpTableSection(project, expectedEntity.InpTableName);
            Reader.SetData(inpString);
            parser.ReadSection(Reader);

            var entity = project.Entities.FirstOrDefault();

            Assert.Equal(expectedEntity, entity);
        }

        #region Test Data

        /// <summary>
        /// Test data for <see cref="EntityParserTests(string, InpEntity)"/> tests
        /// </summary>
        private class EntityParserTestData : IEnumerable<object[]>
        {
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

                //
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

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
