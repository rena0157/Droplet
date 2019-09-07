﻿// InpLibTests
// NormalFlowCriterionTests.cs
// 
// ============================================================
// 
// Created: 2019-08-18
// Last Updated: 2019-08-18-09:33 AM
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
    public class NormalFlowCriterionTests : InpFileTests
    {
        /// <summary>
        /// Default Constructor for the Normal Flow Criterion Tests
        /// </summary>
        /// <param name="logger">Logger passed from XUnit</param>
        public NormalFlowCriterionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        [Theory]
        [ClassData(typeof(ParserData))]
        public void ParserTests(string s, NormalFlowCriterion expected)
        {
            Reader.SetData(s);
            var project = new InpProject();
            var parser = new InpOptionsSection(project);

            parser.ReadSection(Reader);

            Assert.Equal(expected, project.NormalFlowOption);
        }

        #endregion

        #region TestData

        private class ParserData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"NORMAL_FLOW_LIMITED  FROUDE",

                    NormalFlowCriterion.Froude
                };

                yield return new object[]
                {
                    @"",

                    NormalFlowCriterion.Slope
                };
            }

            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        #endregion
    }
}
