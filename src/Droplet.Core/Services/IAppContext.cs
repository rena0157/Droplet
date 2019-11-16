using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Droplet.Core.Services
{
    /// <summary>
    /// Interface that will be implemented for all application contexts for 
    /// Droplet
    /// </summary>
    public interface IAppContext
    {
        /// <summary>
        /// The application host
        /// </summary>
        IHost AppHost { get; }

        /// <summary>
        /// The application service provider
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// The application configuration
        /// </summary>
        IConfiguration Configuration { get; }

        /// <summary>
        /// Method that starts the host asynchronously
        /// </summary>
        /// <param name="host">The host that will be started</param>
        /// <returns>Returns: The task that the 
        /// <see cref="IHost.StartAsync(System.Threading.CancellationToken)"/> returns</returns>
        Task StartHost(IHost host);
    }
}
