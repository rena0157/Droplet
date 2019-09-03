using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Parsers;
using System;
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
        /// <summary>
        /// Default Constructor for this test class
        /// that accepts a logger from Xunit DI
        /// </summary>
        /// <param name="logger">The logger that is passed from Xunit</param>
        public InpEntityTests(ITestOutputHelper logger) : base(logger)
        {
        }

        [Theory]
        [InlineData(typeof(Aquifer))]
        [InlineData(typeof(Subcatchment))]
        public void ToInpStringTests(Type entityType)
        {
            var entity = (InpEntity)Activator.CreateInstance(entityType);
            var inpString = entity.ToInpString() + "\n";
            FileLinesFromString(inpString);

            var project = new InpProject();
            var parser = new InpTableSection(project, entity.InpTableName);
            parser.ReadSection(this);

            Assert.Equal(entity, project.Entities.FirstOrDefault());
        }
    }
}
