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
        /// The Desciption of the entity
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The entity's tag
        /// </summary>
        string Tag { get; }
    }
}
