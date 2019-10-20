using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit.Abstractions;
using Xunit;

namespace Droplet.Core.Inp.Tests.Entities
{
    abstract public class EntityTests : FileTestsBase
    {
        #region Constructor

        public EntityTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Tests

        /// <summary>
        /// Testing the equality of a parsed <see cref="IInpEntity"/> when compared to <paramref name="expected"/>. 
        /// in this test <paramref name="inpString"/> will be parsed into a <see cref="IInpProject"/> and then the 
        /// <paramref name="expected"/> name will be used to get the actual <typeparamref name="T"/> from the <see cref="IInpProject.Database"/> 
        /// using <see cref="IInpDatabase.GetEntities{T}"/> and then will be asserted using <see cref="Assert.Equal(T, T)"/>
        /// </summary>
        /// <typeparam name="T">The type of the entity being tested</typeparam>
        /// <param name="inpString">The inp <see cref="string"/> that will be parsed into the project</param>
        /// <param name="expected">The expected <see cref="IInpEntity"/></param>
        public virtual void ParserTest_ValidInpString_ShouldMatchExpected<T>(string inpString, T expected) where T : IInpEntity
        {
            // Get the project using the inp string and get the entity using the entity name
            var project = SetupProject(inpString);
            var entity = project.Database.GetEntities<T>().FirstOrDefault(e => e.Name == expected.Name);

            // Assert that the entity is not null and matches the expected entity
            Assert.NotNull(entity);
            Assert.Equal(expected, entity);
        }

        #endregion
    }
}
