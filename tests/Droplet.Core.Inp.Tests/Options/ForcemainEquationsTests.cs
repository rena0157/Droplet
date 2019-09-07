// InpLibTests
// ForcemainEquationsTests.cs
// 
// ============================================================
// 
// Created: 2019-08-18
// Last Updated: 2019-08-18-09:22 AM
// By: Adam Renaud
// 
// ============================================================

using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Parsers;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Test class for <see cref="ForcemainEquations"/> and its parser
    /// </summary>
    public class ForcemainEquationsTests : InpFileTests
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">The logger that will be passed to the constructor via XUnit</param>
        public ForcemainEquationsTests(ITestOutputHelper logger) : base(logger)
        {

        }

        /// <summary>
        /// Testing the parser for the Forcemain equations
        /// </summary>
        /// <param name="s">The string that is passed from the class data
        /// that represents a line from an inp file</param>
        /// <param name="expected">The expected value of the forcemain equation from the string</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string s, ForcemainEquations expected)
        {
            Reader.SetData(s);
            var project = new InpProject();
            var parser = new InpOptionsSection(project);
            parser.ReadSection(Reader);

            Assert.Equal(expected, project.ForcemainEquation);
        }

        #region TestData

        /// <summary>
        /// Class test data for <see cref="ForcemainEquationsTests.ParserTests"/>
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// The Data that will be passed to the test
            ///
            /// Contains a string and the expected result from the test
            /// </summary>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Darcy-Weisbach
                yield return new object[]
                {
                    @"FORCE_MAIN_EQUATION  D-W
                     ",

                    ForcemainEquations.DarcyWeisbach
                };

                // Hazen Williams
                yield return new object[]
                {
                    @"FORCE_MAIN_EQUATION  H-W
                     ",

                    ForcemainEquations.HazenWilliams
                };
            }

            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        #endregion
    }
}
