using Microsoft.Extensions.Azure;
using MyTriApp.Secrets;

namespace MyTriApp.Extensions
{
    public static class SecretsProviderExtensions
    {
        public static IServiceCollection AddSecretServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAzureClients(builder =>
            {
                builder.AddSecretClient(configuration.GetSection("KeyVault"));
            });

            services.AddSingleton<SecretsProvider>();

            return services;
        }
    }
}
