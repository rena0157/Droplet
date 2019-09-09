using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The different possible flow units that can be used in the
    /// simultaion and results
    /// 
    /// US Units.
    /// CFS: cubic feet per second 
    /// GPM: gallons per minutes
    /// MGD: million gallons per day
    ///
    /// SI Units.
    /// CMS: cubic meters per second
    /// LPS: liters per second
    /// MLD: million liters per day 
    /// </summary>
    public enum FlowUnits
    {
        LitersPerSecond,

        CubicFeetPerSecond,

        GallonsPerMinute,

        MillionGallonsPerDay,

        CubicMetersPerSecond,

        MilltionLitersPerDay
    }
}
