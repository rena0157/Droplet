using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Interface that defines a class that will host entity data
    /// </summary>
    public interface IEntityDataHost<T> where T : class
    {
        /// <summary>
        /// Add entity data to it's host
        /// </summary>
        /// <param name="entityData">The data that will be added to this host</param>
        void AddEntityData(T entityData);
    }
}
