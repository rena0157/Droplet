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
using System.Windows.Shapes;

namespace Droplet.WindowsApp.Components.Shell
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        private ILogger<ShellView> _logger;

        public ShellView()
        {
            InitializeComponent();
        }

        public ShellView(ILogger<ShellView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogInformation("Shell View Initialized");
        }
    }
}
