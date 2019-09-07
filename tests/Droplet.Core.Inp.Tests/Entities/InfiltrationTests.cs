using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Parsers;
using Droplet.Core.Inp.Tests;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Entities
{
    public class InfiltrationTests : InpFileTests
    {
        /// <summary>
        /// Default Constructor for <see cref="InfiltrationTests"/>
        /// </summary>
        /// <param name="logger">Logger passed from XUnit</param>
        public InfiltrationTests(ITestOutputHelper logger) : base(logger)
        {
            
        }

        #region Tests

        /// <summary>
        /// Testing the parsing of <see cref="CurveNumberInfiltration"/>,
        /// <see cref="GreenAmptInfiltration"/> and <see cref="HortonInfiltration"/>
        /// </summary>
        /// <param name="fileString">The inp string that will be parsed</param>
        /// <param name="expected">The expected infiltration data</param>
        /// <param name="method">The infiltration method that will be used to parse the data</param>
        [Theory]
        [ClassData(typeof(InfiltrationTestData))]
        public void InfiltrationParserTests(string fileString, InfiltrationData expected, InfiltrationMethods method)
        {
            // Set the file lines for this tester
            Reader.SetData(fileString);

            // Create the project and set the infiltration method
            var project = new InpProject
            {
                InfiltrationMethod = method
            };

            // Create a subcatchment and set its name
            var subcatchment = new Subcatchment
            {
                Name = "1"
            };

            // Add the subcatchment to the list of entities in the project
            project.Entities.Add(subcatchment);

            // Read and parse the section
            var parser = new InpTableSection(project, "INFILTRATION");
            parser.ReadSection(Reader);

            // Asser that the correct entity was parsed
            Assert.Equal(expected, subcatchment.InfiltrationOptions);
        }

        #endregion

        #region TestData

        /// <summary>
        /// Test data for <see cref="InfiltrationTests"/>
        /// </summary>
        private class InfiltrationTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Gets the test data for <see cref="InfiltrationTests"/>
            /// </summary>
            /// <returns>Returns: a string that represents the contents of an inp file
            /// and the respective expected Infiltration data</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Curve Number infiltration
                yield return new object[]
                {
                    // String from inp file
                    "1                80         0.5        7         \n",

                    // Expected Curvenumber infiltration
                    new CurveNumberInfiltration
                    {
                        ReferencedEntityNames = new List<string> {"1"},
                        CurveNumber = 80,
                        DryingTime = TimeSpan.FromDays(7)
                    },

                    // The infiltration method that is used
                    InfiltrationMethods.CurveNumber
                };

                // Horton Infiltration method
                yield return new object[]
                {
                    // String from inp file
                    "1                80         0.5        7          7          0         \n",

                    // Expected Horton infiltration data
                    new HortonInfiltration
                    {
                        ReferencedEntityNames = new List<string> {"1"},
                        MaxRate = 80,
                        MinRate = 0.5,
                        Decay = 7,
                        DryTime = TimeSpan.FromDays(7),
                        MaxInfiltrationVolume = 0
                    },

                    // Using the Horton Infiltration 
                    InfiltrationMethods.Horton
                };

                // Green Ampt
                yield return new object[]
                {
                    // String form an inp file
                    "1                80         0.5        7         \n",

                    // The expected green ampt
                    new GreenAmptInfiltration
                    {
                        ReferencedEntityNames = new List<string> {"1"},
                        SuctionHead = 80,
                        HydraulicConductivity = 0.5,
                        InternalDeficit = 7
                    },

                    InfiltrationMethods.GreenAmpt
                };
            }

            /// <summary>
            /// Get the enumerator for this class
            /// </summary>
            /// <returns>Returns: The enumerator</returns>
            IEnumerator IEnumerable.GetEnumerator() 
                => GetEnumerator();
        }

        #endregion
    }
}
