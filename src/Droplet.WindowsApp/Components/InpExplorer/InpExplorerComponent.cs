using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Options;
using Droplet.Core.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Droplet.WindowsApp.Components.InpExplorer
{
    /// <summary>
    /// A component that can be used to explore an inp file
    /// </summary>
    public class InpExplorerComponent : ComponentBase<InpExplorerView>
    {

        #region Private Members

        private string _filePath;
        private ObservableCollection<InpOption> _options;
        private InpProjectsService _inpProjectService;
        private IInpProject _inpProject;
        private ObservableCollection<IInpEntity> _selectedEntities;
        private Dictionary<string, Type> _entityTypes;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public InpExplorerComponent()
        {
            _entityTypes = new Dictionary<string, Type>();
        }

        /// <summary>
        /// Initializes a new <see cref="InpExplorerComponent"/> and also 
        /// accepts the view component that will be shown
        /// </summary>
        /// <param name="view">The view that will be shown</param>
        public InpExplorerComponent(InpProjectsService inpProjectsService, InpExplorerView view) : base(view)
        {
            _inpProjectService = inpProjectsService;
            Init();
        }

        protected override void Init()
        {
            FilePath = "";
            base.Init();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The file path for this component
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged();
                try
                {
                    OpenProject(value);
                }
                catch
                {
                    return;
                }
            }
        }

        /// <summary>
        /// The command that will set the <see cref="FilePath"/> using the <see cref="GetFilePathCommand"/>
        /// </summary>
        public ICommand BrowseCommand
        {
            get => new RelayCommand<object>((o) => FilePath = GetFilePathCommand());
        }

        /// <summary>
        /// Method that gets a filename from the <see cref="OpenFileDialog"/>
        /// </summary>
        /// <returns>Returns: The filename</returns>
        private string GetFilePathCommand()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Pick an inp file",
            };

            var result = openFileDialog.ShowDialog();

            if (result ?? false)
            {
                return openFileDialog.FileName;
            }

            else return "";
        }

        private object _dataGridContext;

        /// <summary>
        /// The context that the Data grid will bind to
        /// </summary>
        public object DataGridContext
        {
            get => _dataGridContext;
            set
            {
                _dataGridContext = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<InpOption> _inpOptions;

        /// <summary>
        /// The InpOptions in the inp file
        /// </summary>
        public ObservableCollection<InpOption> InpOptions
        {
            get => _inpOptions;
            set
            {
                _inpOptions = value;
                OnPropertyChanged();
            }
        }

        public ICommand SetDataGridToInpOptions
            => new RelayCommand<object>((o) => DataGridContext = InpOptions);

        #endregion

        #region Private Methods

        /// <summary>
        /// Opens a new inp project
        /// </summary>
        /// <param name="pathToFile"></param>
        private void OpenProject(string pathToFile)
        {
            _inpProject = _inpProjectService.OpenProject(pathToFile);
            InpOptions = new ObservableCollection<InpOption>(_inpProject.Database.GetOptions());
        }

        #endregion
    }
}
