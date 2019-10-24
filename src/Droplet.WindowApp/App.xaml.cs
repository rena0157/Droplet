using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace Droplet.WindowApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Private Fields

        private readonly ILogger<App> _logger;
        private readonly IHost _host;

        public IServiceProvider ServiceProvider { get; set; }
        private Task _hostTask;

        private MainWindowViewModel mainViewModel;

        #endregion

        #region PInvoke Methods

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor for the application
        /// </summary>
        public App()
        {
            AllocConsole();
            _host = CreateHostBuilder().Build();
            _hostTask = _host.StartAsync();

            ServiceProvider = _host.Services;
            _logger = ServiceProvider.GetRequiredService<ILogger<App>>();
            mainViewModel = ServiceProvider.GetRequiredService<MainWindowViewModel>();
        }

        private IHostBuilder CreateHostBuilder()
            => Host.CreateDefaultBuilder()
                   .ConfigureServices((hostContext, services) =>
                   {
                       services.AddLogging();
                       services.AddSingleton<MainWindowViewModel>();
                       services.AddScoped<MainWindow>();
                   });

        #endregion

        #region Application Startup

        /// <summary>
        /// The application startup routine
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The startup arguments</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
        }

        /// <summary>
        /// The application exit routine
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The exit args</param>
        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using(_host)
            {
                await _host.StopAsync();
            }
        }

        #endregion
    }

}
