using Microsoft.Extensions.DependencyInjection;
using RatingDadJokes.ExternalData.Service;

namespace RatingDadJokes.ExternalData
{
    public static class RatingDadJokesExternalDataDependencyInjection
    {
        public static void AddJokeDataProvider(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJokeDataProvider, DefaultJokeDataProvider>();
        }
    }
}