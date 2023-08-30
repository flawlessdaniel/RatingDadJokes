using RatingDadJokes.Data.Model;

namespace RatingDadJokes.Data.Service
{
    public interface IRatingRepository
    {
        void AddJoke(Joke joke);
        void AddRating(Joke joke, int  rating);
        Task AddRatingAsync(Joke joke, int rating);
        List<Joke> GetTopRatedJokes();
        Task<List<Joke>> GetTopRatedJokesAsync();
    }
}