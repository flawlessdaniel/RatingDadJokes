using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RatingDadJokes.Data
{
    public static class RatingDadJokesDataDependencyInjection
    {
        public static void UseRatingDadJokesSqlite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RatingDadJokesDbContext>(x => 
            {
                x.UseSqlite(configuration.GetConnectionString("RatingDB"));
            });
        }
    }
}