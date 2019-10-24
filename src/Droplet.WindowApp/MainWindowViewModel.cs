using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.WindowApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(MainWindow window, ILogger<MainWindowViewModel> logger)
        {
            window.Show();

            logger.LogInformation("Main Window Open");
        }
    }
}
