using Droplet.Core.Inp.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Droplet.WindowsApp.Components.InpExplorer
{
    /// <summary>
    /// Interaction logic for InpExplorerView.xaml
    /// </summary>
    public partial class InpExplorerView : UserControl
    {
        private readonly ILogger<InpExplorerView> _logger;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public InpExplorerView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Default Constructor that accepts an <see cref="ILogger{InpExplorerView}"/>
        /// </summary>
        /// <param name="logger">The logger that will be used in this class</param>
        public InpExplorerView(ILogger<InpExplorerView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogInformation("Inp Explorer View Initialized");
        }

        /// <summary>
        /// Method that is called when the Selected Item for the TreeView Changes
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The routed property changed event args</param>
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Get the context and the selected object
            var context = DataContext as InpExplorerComponent;

            // Make sure they are not null
            if (context is null ) return;

        }
    }
}
