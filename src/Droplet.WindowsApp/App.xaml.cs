using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Windows;

namespace Droplet.WindowsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var apiKey = Current.Resources["AppCenterApi"] as string;
            AppCenter.Start(apiKey,
                   typeof(Analytics), typeof(Crashes), typeof(Analytics));
        }
    }
}
