using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatingDadJokes.Data.Service.Commands;
using RatingDadJokes.Data.Service.Queries;

namespace RatingDadJokes.Data.Service
{
    public static class RatingJokesDataServiceDependencyInjection
    {
        public static void AddRatingJokesDataService(this IServiceCollection services, IConfiguration configuration)
        {
            services.UseRatingDadJokesSqlite(configuration);
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IAddRatedJokeCommand, AddRatedJokeCommand>();
            services.AddScoped<IGetTopRatedJokesQuery, GetTopRatedJokesQuery>();
            services.AddScoped<IAddJokeCommand, AddJokeCommand>();
        }
    }
}
