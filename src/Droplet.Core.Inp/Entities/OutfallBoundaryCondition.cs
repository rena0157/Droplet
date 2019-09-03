// OutfallBoundaryCondition.cs
// By: Adam Renaud
// Created: 2019-09-01

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Outfall boundary conditions for the <see cref="Outfall"/> class
    /// </summary>
    public enum OutfallBoundaryConditions
    {
        Free,

        Normal,

        Fixed,

        Tidal,

        Timeseries
    }
}
