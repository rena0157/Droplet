﻿using Droplet.Core.Inp.Entities;
using System.Collections.Generic;

namespace Droplet.Core.Inp
{
    /// <summary>
    /// Interface for an InpProject
    /// </summary>
    public interface IInpProject
    {
        /// <summary>
        /// The name of the InpFile
        /// </summary>
        string InpFile { get; }

        /// <summary>
        /// The name of the InpProject
        /// </summary>
        string ProjectName { get; }

        /// <summary>
        /// The options in this project
        /// </summary>
        List<IInpOption> Options { get; }

        /// <summary>
        /// The entities in this project
        /// </summary>
        List<IInpEntity> Entities { get; }
    }
}
