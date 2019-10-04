// IInpEntity.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Entity Interface
    /// </summary>
    public interface IInpEntity : IInpDbObject
    {
        /// <summary>
        /// The name of the entity
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The Description of the entity
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The entity's tag
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Convert this entity to a string
        /// </summary>
        /// <returns>Returns: An inp string</returns>
        string ToInpString();
    }
}
