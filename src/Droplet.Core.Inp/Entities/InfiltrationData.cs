using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Base class that binds together <see cref="CurveNumberInfiltration"/>,
    /// <see cref="GreenAmptInfiltration"/> and <see cref="HortonInfiltration"/>
    /// </summary>
    public abstract class InfiltrationData : InpEntityData
    {
        #region Public Properties

        /// <summary>
        /// The default inp table name for the classes that
        /// inherit this type (<see cref="CurveNumberInfiltration"/>, <see cref="HortonInfiltration"/>
        /// and <see cref="GreenAmptInfiltration"/>)
        /// </summary>
        public override string InpTableName => "INFILTRATION";

        #endregion
    }
}
