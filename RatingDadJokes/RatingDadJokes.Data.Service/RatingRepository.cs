using RatingDadJokes.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDadJokes.Data.Service
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RatingDadJokesDbContext _dbContext;
        public RatingRepository(RatingDadJokesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddJoke(Joke joke)
        {
            _dbContext.Jokes.Add(joke);
            _dbContext.SaveChanges();
        }

        public void AddRating(Joke joke, int rating)
        {
            throw new NotImplementedException();
        }

        public Task AddRatingAsync(Joke joke, int rating)
        {
            throw new NotImplementedException();
        }

        public List<Joke> GetTopRatedJokes()
        {
            throw new NotImplementedException();
        }

        public Task<List<Joke>> GetTopRatedJokesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
