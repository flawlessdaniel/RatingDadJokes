using RatingDadJokes.Shared.Discovery;
using RatingDadJokes.Shared.Secrets;

namespace RatingDadJokesAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSecretManager(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //TODO: create an awaiter project instead of .result everywhere in the config
            string discoveredUrl = GetVaultUrl(serviceCollection.BuildServiceProvider()).Result;
            serviceCollection.AddVaultService(configuration, discoveredUrl);
        }

        private static async Task<string> GetVaultUrl(IServiceProvider serviceProvider)
        {
            var serviceDiscovery = serviceProvider.GetService<IServiceDiscovery>();
            return await serviceDiscovery?.GetFullAddress(ServiceRegistry.Secrets)!;
        }
    }
}
