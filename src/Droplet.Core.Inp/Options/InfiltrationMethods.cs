// InfiltrationMethods.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Different Infiltration Methods that the SWMM5 engine provides
    /// </summary>
    public enum InfiltrationMethods
    {
        Horton,

        ModifiedHorton,

        GreenAmpt,

        ModifiedGreenAmpt,

        CurveNumber
    }
}
