using Droplet.WindowsApp.Components.InpExplorer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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

        private Visibility _visibility = Visibility.Hidden;

        private void TestCommandMethod(object o)
        {
            TextVisibility = Visibility.Visible;
        }

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
            View.Show();
            TestCommand = new RelayCommand<object>(TestCommandMethod, o => true);
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

        public Visibility TextVisibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        ICommand TestCommand { get; set; }

        #endregion

    }
}
