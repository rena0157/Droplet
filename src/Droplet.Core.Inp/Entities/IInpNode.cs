// InpLib
// IInpNode.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-01:02 PM
// By: Adam Renaud
// 
// ============================================================

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// An interface that describes a node/point
    /// </summary>
    public interface IInpNode
    {
        /// <summary>
        /// The X coordinate of the entity
        /// </summary>
        double X { get; set; }

        /// <summary>
        /// The Y Coordinate of the entity
        /// </summary>
        double Y { get; set; }
    }
}
