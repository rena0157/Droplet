using Esri.ArcGISRuntime.Mapping;
using System.Windows;

namespace Droplet.WindowsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var myMap = new Map();
            myMap.Basemap = Basemap.CreateDarkGrayCanvasVector();
            myMapView.Map = myMap;
        }
    }
}
