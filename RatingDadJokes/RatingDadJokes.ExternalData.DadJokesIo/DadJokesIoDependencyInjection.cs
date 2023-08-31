using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatingDadJokes.ExternalData.Service;

namespace RatingDadJokes.ExternalData.DadJokesIo
{
    public static class DadJokesIoDependencyInjection
    {
        public static void AddDadJokesIoDataProvider(this IServiceCollection serviceCollection, IConfiguration configuration, string? discoveredUrl = null)
        {
            serviceCollection.Configure<DadJokesIoSettings>(configuration.GetSection("RapidApi"));
            serviceCollection.PostConfigure<DadJokesIoSettings>(settings =>
            {
                if (!string.IsNullOrWhiteSpace(discoveredUrl))
                    settings.UpdateUrl(discoveredUrl);
            });
            serviceCollection.AddJokeDataProvider();
            serviceCollection.AddScoped<IExternalDataProvider, DadJokesIoDataProvider>();
        }
    }
}