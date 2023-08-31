using RatingDadJokes.Data.Model;

namespace RatingDadJokes.Data.Service
{
    public interface IRatingRepository
    {
        void AddJoke(Joke joke);
        void AddRating(Rating rating);
        Task AddRatingAsync(Rating rating);
        List<Rating> GetTopRatedJokes();
        Task<List<Rating>> GetTopRatedJokesAsync();
    }
}