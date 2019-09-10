// IInpDbObject.cs
// By: Adam Renaud
// Created: 2019-09-10

using System;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// Basic object that belongs to an <see cref="IInpDatabase"/>
    /// </summary>
    public interface IInpDbObject
    {
        /// <summary>
        /// The ID of the object
        /// </summary>
        Guid ID { get;}

        /// <summary>
        /// The database that the object belongs to
        /// </summary>
        IInpDatabase Database { get; }
    }
}
