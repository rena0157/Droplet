using Droplet.WindowsApp.Components.MainWindow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Droplet.WindowsApp
{
    /// <summary>
    /// The Application class for the windows project
    /// </summary>
    public partial class DropletApp : Application
    {

        #region Private Members

        /// <summary>
        /// The <see cref="DropletApp"/> class logger
        /// </summary>
        private ILogger<DropletApp> _logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor that will build the host and required services
        /// </summary>
        public DropletApp()
        {
            // Create a console and attach this process to it
            AppContext.AllocConsole();
            Context = new AppContext(this);
        }

        #endregion

        #region Static Members

        /// <summary>
        /// The application Context object
        /// </summary>
        public static AppContext Context { get; private set; }

        #endregion


        #region Startup and Shutdown Methods

        /// <summary>
        /// Application startup for WPF
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The startup Arguments</param>
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            // Build and start the host
            await Context.StartHost(AppContext
                .CreateHostBuilder(e.Args)
                .Build());

            // Get required services
            _logger = Context.ServiceProvider.GetRequiredService<ILogger<DropletApp>>();

            // Log that the application has started
            _logger.LogInformation("Application Started");
            foreach (var arg in e.Args)
                _logger.LogInformation(arg);

            var mainWindowComponent = Context.ServiceProvider.GetService<MainWindowComponent>();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (Context.AppHost)
            {
                await Context.AppHost.StopAsync(TimeSpan.FromSeconds(1));
            }
        }

        #endregion
    }
}
