using Microsoft.EntityFrameworkCore;
using RatingDadJokes.Data.Model;

namespace RatingDadJokes.Data
{
    public class RatingDadJokesDbContext : DbContext
    {
        public RatingDadJokesDbContext() { }

        public RatingDadJokesDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasOne<Joke>(x => x.Joke);
        }
    }
}