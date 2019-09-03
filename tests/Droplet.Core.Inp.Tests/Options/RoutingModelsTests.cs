// RoutingModelsTests.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;
using Xunit;
using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Options.Extensions;
using Xunit.Abstractions;

namespace InpLibTests.Options
{
    public class RoutingModelsTests : TestBase
    {
        /// <summary>
        /// Theory to test the extension method for converting Inp Strings to 
        /// Routing Models
        /// </summary>
        /// <param name="value">The sting value</param>
        /// <param name="expected">The expected routing model</param>
        [Theory]
        [InlineData("STEADY", RoutingModels.SteadyFlow)]
        [InlineData("KINWAVE", RoutingModels.KinematicWave)]
        [InlineData("DYNWAVE", RoutingModels.DynamicWave)]
        public void FromInpStringTest(string value, RoutingModels expected)
        {
            var model = RoutingModels.SteadyFlow;
            var result = model.FromInpString(value);
            Assert.True(result.Item1);
            model = result.Item2;
            Assert.Equal(expected, model);
        }

        public RoutingModelsTests(ITestOutputHelper logger) : base(logger)
        {
        }
    }
}
