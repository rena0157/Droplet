﻿using Droplet.WindowsApp.Components.MainWindow;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Droplet.WindowsApp
{
    /// <summary>
    /// The application context that holds all application and host related 
    /// services
    /// </summary>
    public class AppContext
    {

        #region Constructors

        /// <summary>
        /// Default constructor for the app context that accepts an <see cref="DropletApp"/>
        /// </summary>
        /// <param name="app">The app that will be set</param>
        public AppContext(DropletApp app)
        {
            App = app;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The WPF Application that is in this current context
        /// </summary>
        public DropletApp App { get; }

        /// <summary>
        /// The host that is in the current context
        /// </summary>
        public IHost AppHost { get; private set; }

        /// <summary>
        /// Default service provider for the application
        /// </summary>
        public IServiceProvider ServiceProvider 
            => AppHost.Services;

        /// <summary>
        /// The default configuration for the application
        /// </summary>
        public IConfiguration Configuration 
            => ServiceProvider.GetRequiredService<IConfiguration>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Allocates a console to the application
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();

        /// <summary>
        /// Detaches the calling process from its console
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

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
                services.AddSingleton<MainWindowComponent>();
                services.AddSingleton<MainWindow>();
            })
            .UseConsoleLifetime((config) =>
            {
                config.SuppressStatusMessages = false;
            });

        /// <summary>
        /// Starts the host asynchronously and sets the Service provider
        /// </summary>
        /// <param name="host">The host that will be started</param>
        /// <returns>Returns: A task that is the start host task</returns>
        public Task StartHost(IHost host)
        {
            AppHost = host;
            return AppHost.StartAsync();
        }

        #endregion
    }
}
