using Microsoft.Extensions.DependencyInjection;
using RatingDadJokes.Cache.Service;

namespace RatingDadJokes.Cache
{
    public static class RatingDadJokesCacheDependencyInjection
    {
        public static void AddCacheProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICacheProvider, DefaultCacheProvider>();
        }
    }
}