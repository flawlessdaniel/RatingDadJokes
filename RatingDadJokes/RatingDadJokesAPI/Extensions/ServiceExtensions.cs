using RatingDadJokes.Shared.Discovery;
using RatingDadJokes.Shared.Secrets;
using RatingDadJokes.ExternalData.DadJokesIo;
using RatingDadJokes.Cache.Redis;

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

        public static void AddDadJokesIoDataProvider(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string discoveredUrl = GetDadJokesIoUrl(serviceCollection.BuildServiceProvider()).Result;
            serviceCollection.AddDadJokesIoDataProvider(configuration, discoveredUrl);
        }

        public static void AddRedisCacheProvider(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string discoveredUrl = GetRedisUrl(serviceCollection.BuildServiceProvider()).Result;
            serviceCollection.AddRedis(configuration, discoveredUrl);
        }

        private static async Task<string> GetVaultUrl(IServiceProvider serviceProvider)
        {
            var serviceDiscovery = serviceProvider.GetService<IServiceDiscovery>();
            return await serviceDiscovery?.GetFullAddress(ServiceRegistry.Secrets)!;
        }

        private static async Task<string> GetDadJokesIoUrl(IServiceProvider serviceProvider)
        {
            var serviceDiscovery = serviceProvider.GetService<IServiceDiscovery>();
            return await serviceDiscovery?.GetFullAddress(ServiceRegistry.RapidAPI)!;
        }

        private static async Task<string> GetRedisUrl(IServiceProvider serviceProvider)
        {
            var serviceDiscovery = serviceProvider.GetService<IServiceDiscovery>();
            return await serviceDiscovery?.GetFullAddress(ServiceRegistry.Redis)!;
        }
    }
}
