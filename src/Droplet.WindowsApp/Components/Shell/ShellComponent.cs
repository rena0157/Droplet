using Droplet.WindowsApp.Components.InpExplorer;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace Droplet.WindowsApp.Components.Shell
{
    /// <summary>
    /// The main shell component
    /// </summary>
    public class ShellComponent : ComponentBase<ShellView>
    {

        #region Private Members

        private object _mainContent;

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

        private void ShowInpExplorerCommandMethod()
        {
            var inpExplorer = DropletApp.Context.ServiceProvider.GetService<InpExplorerComponent>();
            MainContent = inpExplorer.View;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The main Content control
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
        {
            get => "Shell Component";
        }


        /// <summary>
        /// The show <see cref="InpExplorerComponent"/> command
        /// </summary>
        public ICommand ShowInpExplorerCommand
        {
            get => _showInpExplorerCommand;
        }

        #endregion

    }
}
