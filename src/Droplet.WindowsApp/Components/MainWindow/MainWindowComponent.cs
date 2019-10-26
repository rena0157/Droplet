using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Droplet.WindowsApp.Components.MainWindow
{
    public class MainWindowComponent : ComponentBase
    {
        private readonly MainWindow _window;

        public MainWindowComponent(MainWindow window)
        {
            _window = window;
            _window.DataContext = this;
            _window.Show();
        }

        public Frame PageFrame { get; }
    }
}
