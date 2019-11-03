using Droplet.Core.Inp;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Options;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
        private InpProject _inpProject;
        private ObservableCollection<Subcatchment> _subcatchments;
        private Guid _selectedObjectId;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public InpExplorerComponent()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="InpExplorerComponent"/> and also 
        /// accepts the view component that will be shown
        /// </summary>
        /// <param name="view">The view that will be shown</param>
        public InpExplorerComponent(InpExplorerView view) : base(view)
        {
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
                    _inpProject = new InpProject(FilePath);
                }
                catch
                {
                    return;
                }
                InpOptions = new ObservableCollection<InpOption>(_inpProject.Database.GetOptions());
                Subcatchments = new ObservableCollection<Subcatchment>(_inpProject.Database.GetAllEntities<Subcatchment>());
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

        public ObservableCollection<InpOption> InpOptions
        {
            get => _options;
            set
            {
                _options = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Subcatchment> Subcatchments
        {
            get => _subcatchments;
            set
            {
                _subcatchments = value;
                OnPropertyChanged();
            }
        }

        public Guid SelectedObjectId
        {
            get => _selectedObjectId;
            set
            {
                _selectedObjectId = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedObject));
            }
        }

        public object SelectedObject
        {
            get => _inpProject?.Database == null ? new object() 
                : _inpProject?.Database.GetObject(SelectedObjectId);
        }

        #endregion
    }
}
