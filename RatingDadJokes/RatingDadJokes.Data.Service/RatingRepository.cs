using Microsoft.EntityFrameworkCore;
using RatingDadJokes.Data.Model;

namespace RatingDadJokes.Data.Service
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RatingDadJokesDbContext _dbContext;

        public RatingRepository() 
        {
            _dbContext = new RatingDadJokesDbContext();
            _dbContext.Ratings.Add(new());
        }

        public RatingRepository(RatingDadJokesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddJoke(Joke joke)
        {
            _dbContext.Jokes.Add(joke);
            _dbContext.SaveChanges();
        }

        public void AddRating(Rating rating)
        {
            _dbContext.Ratings.Add(rating);
            _dbContext.SaveChanges();
        }

        public async Task AddRatingAsync(Rating rating)
        {
            _dbContext.Ratings.Add(rating);
            await _dbContext.SaveChangesAsync();
        }

        public List<Rating> GetTopRatedJokes()
        {
            return _dbContext.Ratings.Include("Joke").ToList();
        }

        public Task<List<Rating>> GetTopRatedJokesAsync()
        {
            return _dbContext.Ratings.Include("Joke").ToListAsync();
        }
    }
}
