using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Droplet.WindowApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ILogger<MainWindow> _logger;

        public MainWindow(ILogger<MainWindow> logger)
        {
            InitializeComponent();
            _logger = logger;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _logger.LogInformation("Button Clicked!");
            _logger.LogWarning("Too Manny");
        }
    }
}
