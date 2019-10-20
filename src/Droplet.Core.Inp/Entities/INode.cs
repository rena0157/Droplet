namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Interface that defines the X, Y and Z coordinates for a node
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// The X coordinate of the node
        /// </summary>
        double X { get; }

        /// <summary>
        /// The Y coordinate of the node
        /// </summary>
        double Y { get; }

        /// <summary>
        /// The Z coordinate of the node
        /// </summary>
        double Z { get; }
    }
}
