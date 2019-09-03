// InpOptionsSection.cs
// By: Adam Renaud
// Created: 2019-08-09

using Droplet.Core.Inp.Options.Extensions;
using Droplet.Core.Inp;
using System;
using System.Text;

namespace Droplet.Core.Inp.Parsers
{
    /// <summary>
    /// Class that builds, parses and writes the options section
    /// of an inp file
    /// </summary>
    public class InpOptionsSection : InpSection
    {
        #region Private Fields

        /// <summary>
        /// Temp holding place for the start date
        /// </summary>
        private DateTime _startDate;

        /// <summary>
        /// Temp holding place for the report start date
        /// </summary>
        private DateTime _reportStartDate;

        /// <summary>
        /// Temp holding place for the end date
        /// </summary>
        private DateTime _endDate;

        #endregion

        /// <summary>
        /// Default constructor for the inp options section
        /// </summary>
        /// <param name="project">The project that the options data will be relating to</param>
        public InpOptionsSection(InpProject project) : base(project)
        {

        }

        /// <summary>
        /// Parse a line from the options section
        /// </summary>
        /// <param name="line">The line that is being parsed</param>
        /// <returns>Returns: False if the line is not recognized</returns>
        protected override bool ParseLine(string line)
        {
            // Get the tokens from the line
            var tokens = GetTokens(line);

            // There must be exactly 2 tokens in an options line
            if (tokens.Length != 2) return false;

            // Switch statement that parses the line
            switch (tokens[0])
            {
                case "FLOW_UNITS":
                    {
                        var (result, flowUnits) = Project.FlowUnits.FromInpString(tokens[1]);
                        if (result) Project.FlowUnits = flowUnits;
                        return result;
                    }

                case "INFILTRATION":
                    {
                        var (result, value) = Project.InfiltrationMethod.FromInpString(tokens[1]);
                        if (result) Project.InfiltrationMethod = value;
                        return result;
                    }

                case "FLOW_ROUTING":
                    {
                        var (result, value) = Project.RoutingModel.FromInpString(tokens[1]);
                        if (result) Project.RoutingModel = value;
                        return result;
                    }

                case "LINK_OFFSETS":
                    {
                        var (result, value) = Project.LinkOffsetsOption.FromInpString(tokens[1]);
                        if (result) Project.LinkOffsetsOption = value;
                        return result;
                    }

                case "MIN_SLOPE":
                    {
                        if (!double.TryParse(tokens[1], out var result)) return false;
                        Project.MinSlope = result;
                        return true;
                    }

                case "ALLOW_PONDING":
                    {
                        var (result, value) = Project.AllowPonding.FromInpString(tokens[1]);
                        if (result) Project.AllowPonding = value;
                        return result;
                    }

                case "SKIP_STEADY_STATE":
                    {
                        var (result, value) = Project.SkipSteadyState.FromInpString(tokens[1]);
                        if (result) Project.SkipSteadyState = value;
                        return result;
                    }

                // Store the value and combine it later with the start time
                case "START_DATE": return DateTime.TryParse(tokens[1], out _startDate);

                case "START_TIME":
                    {
                        // Combine the start date and the start time
                        var time = DateTime.Parse(tokens[1]);
                        _startDate.CombineTime(time);

                        Project.StartDate = _startDate;
                        return true;
                    }

                // Store the value and combine it later with the report start time
                case "REPORT_START_DATE": return DateTime.TryParse(tokens[1], out _reportStartDate);

                case "REPORT_START_TIME":
                    {
                        _reportStartDate.CombineTime(DateTime.Parse(tokens[1]));
                        Project.ReportStartTime = _reportStartDate;
                        return true;
                    }

                case "END_DATE": return DateTime.TryParse(tokens[1], out _endDate);

                case "END_TIME":
                    {
                        _endDate.CombineTime(DateTime.Parse(tokens[1]));
                        Project.EndDate = _endDate;
                        return true;
                    }

                case "SWEEP_START":
                    {
                        if (!DateTime.TryParse(tokens[1], out var sweepStart)) return false;
                        Project.SweepingStart = sweepStart;
                        return true;
                    }

                case "SWEEP_END":
                    {
                        if (!DateTime.TryParse(tokens[1], out var sweepEnd)) return false;
                        Project.SweepingEnd = sweepEnd;
                        return true;
                    }

                case "DRY_DAYS":
                    {
                        Project.DryDays = TimeSpan.FromDays(double.Parse(tokens[1]));
                        return true;
                    }

                case "REPORT_STEP":
                    {
                        if (!TimeSpan.TryParse(tokens[1], out var step)) return false;
                        Project.ReportStep = step;
                        return true;
                    }

                case "WET_STEP":
                    {
                        if (!TimeSpan.TryParse(tokens[1], out var step)) return false;
                        Project.WetStep = step;
                        return true;
                    }

                case "DRY_STEP":
                    {
                        if (!TimeSpan.TryParse(tokens[1], out var step)) return false;
                        Project.DryStep = step;
                        return true;
                    }

                case "ROUTING_STEP":
                    {
                        if (!TimeSpan.TryParse(tokens[1], out var step)) return false;
                        Project.RoutingStep = step;
                        return true;
                    }

                case "RULE_STEP":
                    {
                        if (!TimeSpan.TryParse(tokens[1], out var step)) return false;
                        Project.RuleStep = step;
                        return true;
                    }

                case "INERTIAL_DAMPING":
                    {
                        var (result, value) = Project.InertialTerms.FromInpString(tokens[1]);
                        if (result) Project.InertialTerms = value;
                        return result;
                    }

                case "NORMAL_FLOW_LIMITED":
                    {
                        var (result, value) = Project.NormalFlowOption.FromInpString(tokens[1]);
                        if (result) Project.NormalFlowOption = value;
                        return result;
                    }

                case "FORCE_MAIN_EQUATION":
                    {
                        var (result, value) = Project.ForcemainEquation.FromInpString(tokens[1]);
                        if (result) Project.ForcemainEquation = value;
                        return result;
                    }

                case "VARIABLE_STEP":
                    {
                        if (!double.TryParse(tokens[1], out var result)) return false;
                        Project.VariableStep = result;
                        return true;
                    }

                case "LENGTHENING_STEP":
                    {
                        if (!double.TryParse(tokens[1], out var value)) return false;
                        Project.LengtheningStep = value;
                        return true;
                    }

                case "MIN_SURFAREA":
                    {
                        if (!double.TryParse(tokens[1], out var value)) return false;
                        Project.MinSurfaceArea = value;
                        return true;
                    }

                case "MAX_TRIALS":
                    {
                        if (!int.TryParse(tokens[1], out var value)) return false;
                        Project.MaxTrials = value;
                        return true;
                    }

                case "HEAD_TOLERANCE":
                    {
                        if (!double.TryParse(tokens[1], out var value)) return false;
                        Project.HeadTolerance = value;
                        return true;
                    }

                case "SYS_FLOW_TOL":
                    {
                        if (!double.TryParse(tokens[1], out var value)) return false;
                        Project.SystemFlowTotal = value;
                        return true;
                    }

                case "LAT_FLOW_TOL":
                    {
                        if (!double.TryParse(tokens[1], out var value)) return false;
                        Project.LateralFlowTotal = value;
                        return true;
                    }

                case "MINIMUM_STEP":
                    {
                        if (!double.TryParse(tokens[1], out var value)) return false;
                        Project.MinimumStep = value;
                        return true;
                    }

                case "THREADS":
                    {
                        if (!int.TryParse(tokens[1], out var value)) return false;
                        Project.NumberOfThreads = value;
                        return true;
                    }

                // If the line does not match anything then the parsing was not 
                // successful and return false
                default:
                    return false;
            }

        }

        /// <summary>
        /// Write this section to an inp string
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public override string WriteSectionToInp()
        {
            var s = new StringBuilder();

            // Header
            s.AppendLine("[OPTIONS]");
            s.AppendLine(";;Option             Value");

            // General Options
            s.AppendLine(Project.FlowUnits.ToInpString());
            s.AppendLine(Project.InfiltrationMethod.ToInpString());
            s.AppendLine(Project.RoutingModel.ToInpString());
            s.AppendLine(Project.LinkOffsetsOption.ToInpString());
            s.AppendLine($"MIN_SLOPE            {Project.MinSlope}");
            s.AppendLine($"ALLOW_PONDING        {Project.AllowPonding.ToInpString()}");
            s.AppendLine($"SKIP_STEADY_STATE    {Project.SkipSteadyState.ToInpString()}");
            s.AppendLine($"");

            // Date Options
            s.AppendLine($"START_DATE           {Project.StartDate:dd'/'MM'/'yyyy}");
            s.AppendLine($"START_TIME           {Project.StartDate.TimeOfDay}");
            s.AppendLine($"REPORT_START_DATE    {Project.ReportStartTime:dd'/'MM'/'yyyy}");
            s.AppendLine($"REPORT_START_TIME    {Project.ReportStartTime.TimeOfDay}");
            s.AppendLine($"END_DATE             {Project.EndDate:dd'/'MM'/'yyyy}");
            s.AppendLine($"END_TIME             {Project.EndDate.TimeOfDay}");
            s.AppendLine($"SWEEP_START          {Project.SweepingStart:MM'/'dd}");
            s.AppendLine($"SWEEP_END            {Project.SweepingEnd:MM'/'dd}");
            s.AppendLine($"DRY_DAYS             {Project.DryDays.Days}");
            s.AppendLine($"REPORT_STEP          {Project.ReportStep}");
            s.AppendLine($"WET_STEP             {Project.WetStep}");
            s.AppendLine($"DRY_STEP             {Project.DryStep}");
            s.AppendLine($"ROUTING_STEP         {Project.RoutingStep}");
            s.AppendLine($"RULE_STEP            {Project.RuleStep}");

            // Dynamic Wave Options
            s.AppendLine(Project.InertialTerms.ToInpString());
            s.AppendLine(Project.NormalFlowOption.ToInpString());
            s.AppendLine(Project.ForcemainEquation.ToInpString());
            s.AppendLine($"VARIABLE_STEP        {Project.VariableStep}");
            s.AppendLine($"LENGTHENING_STEP     {Project.LengtheningStep}");
            s.AppendLine($"MIN_SURFAREA         {Project.MinSurfaceArea}");
            s.AppendLine($"MAX_TRIALS           {Project.MaxTrials}");
            s.AppendLine($"HEAD_TOLERANCE       {Project.HeadTolerance}");
            s.AppendLine($"SYS_FLOW_TOL         {Project.SystemFlowTotal}");
            s.AppendLine($"LAT_FLOW_TOL         {Project.LateralFlowTotal}");
            s.AppendLine($"MINIMUM_STEP         {Project.MinimumStep}");
            s.AppendLine($"THREADS              {Project.NumberOfThreads}");
            s.AppendLine("");

            return s.ToString();
        }


    }
}
