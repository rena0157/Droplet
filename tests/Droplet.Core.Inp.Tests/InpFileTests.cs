// InpFileTests.cs
// By: Adam Renaud
// Created: 2019-08-17

using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Parsers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

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

    }
}
