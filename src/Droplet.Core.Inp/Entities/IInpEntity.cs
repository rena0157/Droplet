using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Entity Interface
    /// </summary>
    public interface IInpEntity
    {
        /// <summary>
        /// The name of the entity
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The Desciption of the entity
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The entity's tag
        /// </summary>
        string Tag { get; set; }
    }
}
