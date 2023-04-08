using AuthZero.Client.SharedLibrary.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthZero.Client.SharedLibrary.Common.Extensions
{
    public static class AuthZeroClientExtensions
    {

        public static IServiceCollection AddAuthZeroClient(this IServiceCollection services, IConfiguration configuration, string configSectionName)
        {
            AuthZeroConfiguration config = new();
            services.Configure<AuthZeroConfiguration>(t =>
            {
                configuration.GetSection(configSectionName).Bind(t);
                config = t;
            });

            services.AddHttpClient<AuthZeroClient>();
            return services;
        }

        public static IServiceCollection AddAuthZeroClient(this IServiceCollection services, AuthZeroConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
            AuthZeroConfiguration config = new();

            services.AddSingleton<AuthZeroConfiguration>(configuration);
            services.AddHttpClient<AuthZeroClient>();
            return services;
        }
    }
}
