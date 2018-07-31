using Contracts.Logging;
using Contracts.Repository;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        #region Public Methods

        /// <summary>
        /// Calls  Dependency injection registration services.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void CallDiRegistration(this IServiceCollection service)
        {
            ConfigureLoggerService(service);
            ConfigureRepositoryWrapper(service);
        }

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

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:AccountOwnerConnection"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Configures the logger service.
        /// </summary>
        /// <param name="service">The service.</param>
        private static void ConfigureLoggerService(this IServiceCollection service)
        {
            service.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Configures the repository wrapper.
        /// </summary>
        /// <param name="service">The service.</param>
        private static void ConfigureRepositoryWrapper(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        #endregion Private Methods
    }
}