// InpProject.cs
// By: Adam Renaud
// Created: 2019-08-09

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Parsers;

namespace Droplet.Core.Inp
{
    /// <summary>
    /// The main Project class for an Inp Project
    /// </summary>
    public class InpProject
    {
        #region Constructors

        /// <summary>
        /// Blank Constructor for the InpProject Class. This constructor
        /// initializes all of the data structures for the class and assigns
        /// all of the default values for the Options.
        /// </summary>
        public InpProject()
        {
            Entities = new List<InpEntity>();

            // Setting Defaults
            FlowUnits = FlowUnits.LitersPerSecond;
            MaxTrials = 8;
            HeadTolerance = 0.0015; // Meters
            NumberOfThreads = 1;
        }

        /// <summary>
        /// Create and Parse an <c>*.inp</c> file from a filename
        /// </summary>
        /// <param name="filename">The file that will be read</param>
        public InpProject(string filename) : this()
        {
            // Set the project file from the filename
            ProjectFile = filename;

            // Set the project name from the filename
            ProjectName = Path.GetFileNameWithoutExtension(filename);

            // Check to see if the filename ends with the correct extension
            if (!filename.EndsWith(".inp"))
                throw new FileLoadException("The wrong file type has been passed");

            // Check to see if the filename even exists
            if (!File.Exists(filename))
                throw new FileNotFoundException("The filename provided cannot be found");

            // If all of the above tests pass then create a parser and parse the project
            using (var reader
                = new InpReader(File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                var parser = new InpParser(reader);
                parser.ParseProject(this);
            }
        }

        #endregion

        #region Project Options

        /// <summary>
        /// The <see cref="FlowUnits"/> that the project is using
        /// </summary>
        public FlowUnits FlowUnits { get; set; }

        /// <summary>
        /// The <see cref="InfiltrationMethods"/> that is set for the project
        /// </summary>
        public InfiltrationMethods InfiltrationMethod { get; set; }

        /// <summary>
        /// The routing model that is used by the project
        /// </summary>
        /// <value></value>
        public RoutingModels RoutingModel { get; set; }

        /// <summary>
        /// The link offsets option that is used by this project
        /// </summary>
        public LinkOffsets LinkOffsetsOption { get; set; }

        /// <summary>
        /// The Min slope option for this project
        /// </summary>
        public double MinSlope { get; set; }

        /// <summary>
        /// The Allow Ponding setting for this project
        /// </summary>
        public bool AllowPonding { get; set; }

        /// <summary>
        /// The Skip Steady Stage setting for this project
        /// </summary>
        public bool SkipSteadyState { get; set; }

        /// <summary>
        /// The Start date of the simulation
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the simulation
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The report start time
        /// </summary>
        public DateTime ReportStartTime { get; set; }

        /// <summary>
        /// The day of the year when street sweeping operations begin.
        /// </summary>
        public DateTime SweepingStart { get; set; }

        /// <summary>
        /// The day of the year when street sweeping operations end.
        /// </summary>
        public DateTime SweepingEnd { get; set; }

        /// <summary>
        /// The number of days with no rainfall prior to the start of the 
        /// simulation. This value is used to compute an initial buildup of pollutant load
        /// on the surface of subcatchments.
        /// </summary>
        public TimeSpan DryDays { get; set; }

        /// <summary>
        /// The time interval for reporting results
        /// </summary>
        public TimeSpan ReportStep { get; set; }

        /// <summary>
        /// The time step used to compute runoff from subcatchments during
        /// peroids of rainfall, or when ponded water still remains on the surface, or
        /// when Low impact development controls are still infiltrating or evaporating runoff
        /// </summary>
        public TimeSpan WetStep { get; set; }

        /// <summary>
        /// The time step used for runoff computation during periods when there
        /// is no railfall, no ponded water, and low impact development controls are dry.
        /// This must be greater or equal to the <see cref="WetStep"/> parameter
        /// </summary>
        public TimeSpan DryStep { get; set; }

        /// <summary>
        /// The time step used for routing flows and water quality consituents through the conveyance
        /// system. The Dynamic wave routing requires a much smaller time step than other methods
        /// of flow routing
        /// </summary>
        public TimeSpan RoutingStep { get; set; }

        /// <summary>
        /// The time step length used for evaluating Control Rules. The default is 0
        /// which means that controls are evaluated at every routing time step.
        /// </summary>
        public TimeSpan RuleStep { get; set; }

        /// <summary>
        /// Indicates how the inertial terms in the St. Venant momentum equation will be
        /// handled.
        /// </summary>
        public InertialTerms InertialTerms { get; set; }

        /// <summary>
        /// Selects the basis used to determine
        /// when supercritical flow occurs in a conduit.
        /// </summary>
        public NormalFlowCriterion NormalFlowOption { get; set; }

        /// <summary>
        /// Selects which equation will be used to compute frictional losses
        /// during pressurized flow for conduits that have been assigned a circular
        /// Force main cross-section.
        /// </summary>
        public ForcemainEquations ForcemainEquation { get; set; }

        /// <summary>
        /// The saftey factor for the variable time step used at each
        /// routing time period. The variable time step is computed so as to
        /// satisy the Courant condition within each conduit. A typical adjustment factor
        /// would be 75% to provide some margin of conservatism. The computed variable time step
        /// will not be less than the minimum variable step discussed below.
        /// </summary>
        public double VariableStep { get; set; }

        /// <summary>
        /// The is a time step in seconds, used to artifically length conduits so
        /// that they meet the Courant stability criterion under full-flow conditions.
        /// As this value is decreased, fewer conduits will require lengthening. A value of 0
        /// means that no conduits will be lengthened.
        /// </summary>
        public double LengtheningStep { get; set; }

        /// <summary>
        /// The is a min. surface area used at nodes when computing changes in
        /// water depth. If 0 is entered, then the default value of 12.566 sq. ft
        /// or 1.167 sq. m is used. The is the area of a 4-ft diameter manhole. The value
        /// entered should be in square feet or square meters.
        /// </summary>
        public double MinSurfaceArea { get; set; }

        /// <summary>
        /// The maximum number of trials that SWMM uses at each time step to
        /// reach convergence when updating hydraulic heads at the conveyance system's
        /// nodes. The default is 8.
        /// </summary>
        public int MaxTrials { get; set; }

        /// <summary>
        /// When the difference in computed head at each node between successive
        /// trials is below this value the flow solution for the current time
        /// step is assumed to have converged. The default tolerance is 0.005 ft
        /// or (0.0015 m)
        /// </summary>
        public double HeadTolerance { get; set; }

        public double SystemFlowTotal { get; set; }

        public double LateralFlowTotal { get; set; }

        public double MinimumStep { get; set; }

        /// <summary>
        /// The selects the number of paralled computing threads to use on machines
        /// equiped with multi-core processors. The default is 1.
        /// </summary>
        /// <value></value>
        public int NumberOfThreads { get; set; }

        #endregion

        /// <summary>
        /// The name of the project that was loaded
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// The Path to where the project is stored on Disk
        /// </summary>
        public string ProjectFile { get; set; }

        /// <summary>
        /// A list of all the entities in this project
        /// </summary>
        public List<InpEntity> Entities { get; set; }

        /// <summary>
        /// Write this project to an inp string
        /// </summary>
        /// <returns></returns>
        public string ToInpString()
        {
            var s = new StringBuilder();
            var optionsSec = new InpOptionsSection(this);

            // Title
            s.AppendLine("[TITLE]");
            s.AppendLine(";;Project Title/Notes");
            s.AppendLine("");

            // Options
            s.AppendLine(optionsSec.WriteSectionToInp());

            return s.ToString();
        }
    }
}
