using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatingDadJokes.Cache.Service;

namespace RatingDadJokes.Cache.Redis
{
    public static class RatingDadJokesCacheRedisDependencyInjection
    {
        public static void AddRedis(this IServiceCollection serviceCollection, IConfiguration configuration, string? discoveredUrl = null)
        {
            serviceCollection.Configure<RedisSettings>(configuration.GetSection("Redis"));
            serviceCollection.PostConfigure<RedisSettings>(settings =>
            {
                if (!string.IsNullOrWhiteSpace(discoveredUrl))
                    settings.UpdateUrl(discoveredUrl);
            });
            serviceCollection.AddCacheProvider();
            serviceCollection.AddSingleton<IExternalCacheProvider, RedisCacheProvider>();
        }
    }
}
