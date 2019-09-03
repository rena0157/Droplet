// RoutingModelsExtensions.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Flow Routing Extensions Class
    /// </summary>
    public static class RoutingModelsExtension
    {
        private const string Steady = "STEADY";
        private const string KinematicWave = "KINWAVE";
        private const string DynamicWave = "DYNWAVE";

        /// <summary>
        /// Parse a Routing Model from an string that is from an Inp File
        /// </summary>
        /// <returns>Returns: a tuple that contains a bool if the operation is succefull and the value of the operation</returns>
        public static (bool, RoutingModels) FromInpString(this RoutingModels model, string value)
        {
            switch (value)
            {
                case Steady: return (true, RoutingModels.SteadyFlow);
                case KinematicWave: return (true, RoutingModels.KinematicWave);
                case DynamicWave: return (true, RoutingModels.DynamicWave);
                default: return (false, RoutingModels.SteadyFlow);
            }
        }

        /// <summary>
        /// Convert this value to an inp string
        /// </summary>
        /// <param name="model">The value that will be converted</param>
        /// <returns>Returns: an inp string with this value</returns>
        public static string ToInpString(this RoutingModels model)
        {
            string s;
            switch (model)
            {
                case RoutingModels.SteadyFlow:
                    s = Steady;
                    break;
                case RoutingModels.KinematicWave:
                    s = KinematicWave;
                    break;
                case RoutingModels.DynamicWave:
                    s = DynamicWave;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), model, null);
            }

            return $"FLOW_ROUTING         {s}";
        }
    }
}
