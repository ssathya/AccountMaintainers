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
    }
}