// RoutingModels.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Flow Routing Models in SWMM5
    /// </summary>
    public enum RoutingModels
    {
        SteadyFlow,

        KinematicWave,

        DynamicWave
    }
}
