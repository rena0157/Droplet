using Droplet.WindowsApp.Components.InpExplorer;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace Droplet.WindowsApp.Components.Shell
{
    /// <summary>
    /// Component that is a shell window
    /// </summary>
    public class ShellComponent : ComponentBase<ShellView>
    {

        #region Private Members

        /// <summary>
        /// The main content backing field
        /// </summary>
        private object _mainContent;

        /// <summary>
        /// The backing field for the <see cref="ShowInpExplorerCommand"/> 
        /// property
        /// </summary>
        private ICommand _showInpExplorerCommand;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ShellComponent()
        {
        } 

        /// <summary>
        /// Default constructor that accepts a view that will be shown
        /// </summary>
        /// <param name="view"></param>
        public ShellComponent(ShellView view) : base(view)
        {
            Init();
        }

        /// <summary>
        /// Override of the <see cref="ComponentBase{T}.Init"/> method that will initialize 
        /// any UI Components
        /// </summary>
        protected override void Init()
        {
            // Add any property initializations here:
            _showInpExplorerCommand = new RelayCommand<object>((o) => ShowInpExplorerCommandMethod());

            // Initialize the base (DataContext etc.)
            base.Init();

            // Show the view
            View.Show();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// The command method that will set the <see cref="MainContent"/> to 
        /// a new instance of the <see cref="InpExplorerComponent"/>
        /// </summary>
        private void ShowInpExplorerCommandMethod()
        {
            var inpExplorer = DropletApp.Context.ServiceProvider.GetService<InpExplorerComponent>();
            MainContent = inpExplorer.View;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The main content presenter
        /// </summary>
        public object MainContent
        {
            get => _mainContent;
            set
            {
                _mainContent = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The title of the component
        /// </summary>
        public string Title
            => "Shell Component";


        /// <summary>
        /// The show <see cref="InpExplorerComponent"/> command
        /// </summary>
        public ICommand ShowInpExplorerCommand
            => _showInpExplorerCommand;

        /// <summary>
        /// Closes the main view for this component
        /// </summary>
        public ICommand ExitCommand
            => new RelayCommand<object>((o) => View.Close());

        #endregion

    }
}
