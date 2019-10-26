using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Droplet.WindowsApp
{
    /// <summary>
    /// The Application class for the windows project
    /// </summary>
    public partial class App : Application
    {

        #region Private Members

        /// <summary>
        /// The default host provider
        /// </summary>
        private IHost _host;

        /// <summary>
        /// The <see cref="App"/> class logger
        /// </summary>
        private ILogger<App> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor that will build the host and required services
        /// </summary>
        public App()
        {
            // Create a console and attach this process to it
            AllocConsole();
        }

        #endregion

        #region Host Builder Methods

        /// <summary>
        /// Allocates a console to the application
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        /// <summary>
        /// Detaches the calling process from its console
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        /// <summary>
        /// The default host builder application
        /// </summary>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration((configHost) =>
            {

            })
            .ConfigureAppConfiguration((configApp) =>
            {

            })
            .ConfigureServices((context, services) =>
            {

            })
            .UseConsoleLifetime((config) => 
            {
                config.SuppressStatusMessages = false;
            });

        #endregion

        #region Public Properties

        /// <summary>
        /// Default service provider for the application
        /// </summary>
        public IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// The default configuration for the application
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        #endregion

        #region Startup and Shutdown Methods

        /// <summary>
        /// Application startup for WPF
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The startup Arguments</param>
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            // Build the host
            _host = CreateHostBuilder(e.Args).Build();
            ServiceProvider = _host.Services;

            await _host.StartAsync();

            // Get required services
            _logger = ServiceProvider.GetRequiredService<ILogger<App>>();
            Configuration = ServiceProvider.GetRequiredService<IConfiguration>();

            // Log that the application has started
            _logger.LogInformation("Application Started");
            foreach (var arg in e.Args)
                _logger.LogInformation(arg);

        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(1));
            }
        }

        #endregion
    }
}
