﻿using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// A class that holds the Option Data for an inp option
    /// </summary>
    public class InpOption<T> : InpOption where T : struct
    {
        /// <summary>
        /// Constructor that passes the arguments to the base class
        /// </summary>
        /// <param name="row">the row that will be used to construct the option</param>
        /// <param name="database">the database that this option belongs to</param>
        internal InpOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = default;
        }

        /// <summary>
        /// Public Constructor that accepts a name and a value
        /// </summary>
        /// <param name="value">The value for the option</param>
        public InpOption(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The value of the option
        /// </summary>
        [NotNull]
        public virtual T Value { get; set; }


        /// <summary>
        /// Parse the Row into the Value type
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: the parsed value for <see cref="Value"/></returns>
        internal protected virtual T ParseRow(IInpTableRow row)
        {
            // The base class cannot parse the value because
            // it doesn't know what the value type is and needs to be overridden
            // in derived classes
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Base class for the generic <see cref="InpOption{T}"/> class
    /// </summary>
    public class InpOption : InpEntity
    {
        /// <summary>
        /// The header name for the options section
        /// </summary>
        internal const string HeaderName = "OPTIONS";

        /// <summary>
        /// The amount that option strings are padded in inp files
        /// </summary>
        internal const int OptionStringPadding = 21;

        /// <summary>
        /// Default Constructor for the options type
        /// </summary>
        public InpOption() : base()
        {
        }

        /// <summary>
        /// Constructor from a table row and a database
        /// </summary>
        /// <param name="row">The row that this option will be constructed from</param>
        /// <param name="database">The database that this object will be constructed from</param>
        public InpOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// Create an <see cref="InpOption"/> from the <paramref name="optionName"/>, a <see cref="IInpTableRow"/>,
        /// and a <see cref="IInpDatabase"/> reference.
        /// </summary>
        /// <param name="optionName">The name of the option that will be created</param>
        /// <param name="database">The <see cref="IInpDatabase"/> that the option will belong to</param>
        /// <param name="row">The <see cref="IInpTableRow"/> that will be used to build the <see cref="InpOption"/></param>
        /// <returns>Returns: an option that is refereed to by the <paramref name="optionName"/> that is passed</returns>
        internal static InpOption? CreateFromOptionName(string optionName, IInpTableRow row, IInpDatabase database) => optionName switch
        {
            // Flow Units Option
            FlowUnitsOption.OptionName => new FlowUnitsOption(row, database),

            // Infiltration Option
            InfiltrationOption.OptionName => new InfiltrationOption(row, database),

            // Flow Routing Option
            FlowRoutingOption.OptionName => new FlowRoutingOption(row, database),

            // Link Offset Option
            LinkOffsetOption.OptionName => new LinkOffsetOption(row, database),

            // Min Slope Option
            MinSlopeOption.OptionName => new MinSlopeOption(row, database),

            // Allow Ponding Option
            AllowPondingOption.OptionName => new AllowPondingOption(row, database),

            // Skip Steady State Option
            SkipSteadyStateOption.OptionName => new SkipSteadyStateOption(row, database),

            // Start Date Time, Sets the Start Date and Start Time
            StartDateTimeOption.StartDateName => new StartDateTimeOption(row, database),
            // Sets the time of the StartDateTime Option, if it is not null
            StartDateTimeOption.StartTimeName => database.GetOption<StartDateTimeOption>()
                                                         ?.AddTime(TimeSpan.Parse(row[1], CultureInfo.CurrentCulture)),

            // Report Start Date, Sets the Report Start Date
            ReportStartDateTimeOption.DateOptionName => new ReportStartDateTimeOption(row, database),
            // Report Start Time, Sets the Report Start Time
            ReportStartDateTimeOption.TimeOptionName => database.GetOption<ReportStartDateTimeOption>()
                                                                ?.AddTime(TimeSpan.Parse(row[1], CultureInfo.CurrentCulture)),

            // End Date, Sets the End Date
            EndDateTimeOption.DateOptionName => new EndDateTimeOption(row, database),
            // End Date, Sets the End Time
            EndDateTimeOption.TimeOptionName => database.GetOption<EndDateTimeOption>()
                                                        ?.AddTime(TimeSpan.Parse(row[1], CultureInfo.CurrentCulture)),

            // Sweeping Start & End Options
            SweepingStartDateTimeOption.OptionName => new SweepingStartDateTimeOption(row, database),
            SweepingEndDateTimeOption.OptionName => new SweepingEndDateTimeOption(row, database),

            // Dry Days Option
            DryDaysOption.OptionName => new DryDaysOption(row, database),

            // Report Step Option
            ReportStepOption.OptionName => new ReportStepOption(row, database),

            // Wet Weather Step Option
            WetWeatherStepOption.OptionName => new WetWeatherStepOption(row, database),

            // Dry Weather Step Option
            DryWeatherStepOption.OptionName => new DryWeatherStepOption(row, database),

            // Routing Time Step Option
            RoutingStepOption.OptionName => new RoutingStepOption(row, database),

            // Control Rule Time Step Option
            ControlRuleStepOption.OptionName => new ControlRuleStepOption(row, database),

            // Add the Conduit Lengthening Step Option
            ConduitLengtheningStepOption.OptionName => new ConduitLengtheningStepOption(row, database),

            // Inertial Terms Option
            InertialTermsOption.OptionName => new InertialTermsOption(row, database),

            // Min Surface Area Option
            MinSurfaceAreaOption.OptionName => new MinSurfaceAreaOption(row, database),

            // Max trials option
            MaxTrialsOption.OptionName => new MaxTrialsOption(row, database),

            // Head Tolerance option
            HeadToleranceOption.OptionName => new HeadToleranceOption(row, database),
            
            // Thread Count Option
            ThreadCountOption.OptionName => new ThreadCountOption(row, database),
            
            // Variable step option
            VariableStepOption.OptionName => new VariableStepOption(row, database),

            // TODO: Add exception here "Option Not Recognized"
            _ => new InpOption()
        };
    }
}
