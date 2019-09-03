// InpLib
// InertialTerms.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-09:25 AM
// By: Adam Renaud
// 
// ============================================================

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Indicates how the inertial terms in the St. Venant momentum equation
    /// will be handled
    /// </summary>
    public enum InertialTerms
    {
        /// <summary>
        /// reduces the terms as flow comes closer to being critical and
        /// ignores them when flow is supercritical
        /// </summary>
        Dampen,

        /// <summary>
        /// Maintains these terms at their full value
        /// </summary>
        Keep,

        /// <summary>
        /// Drops the terms altogether from the momentum equation
        /// </summary>
        Ignore
    }
}
