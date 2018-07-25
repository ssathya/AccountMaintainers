using Contracts.Logging;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures  cors.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void ConfigureCors(this IServiceCollection service)
        {
            service.AddCors(o => o.AddPolicy("CorsPolicy",
                b => b.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowCredentials()));
        }

        /// <summary>
        /// Configures  IIS integration.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void ConfigureIISIntegration(this IServiceCollection service)
        {
            service.Configure<IISOptions>(options => { });
        }

        /// <summary>
        /// Configures the logger service.
        /// </summary>
        /// <param name="service">The service.</param>
        private static void ConfigureLoggerService(this IServiceCollection service)
        {
            service.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Calls  Dependency injection registration services.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void CallDiRegistration(this IServiceCollection service)
        {
            ConfigureLoggerService(service);
        }
    }
}