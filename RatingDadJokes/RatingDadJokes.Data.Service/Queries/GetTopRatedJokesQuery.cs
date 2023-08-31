using RatingDadJokes.Data.Service.Dtos;

namespace RatingDadJokes.Data.Service.Queries
{
    public interface IGetTopRatedJokesQuery
    {
        Task<List<TopRatedJoke>> GetTopRatedJokesAsync();

        List<TopRatedJoke> GetTopRatedJokes();
    }

    public class GetTopRatedJokesQuery : IGetTopRatedJokesQuery
    {
        private readonly IRatingRepository _repository;

        public GetTopRatedJokesQuery(
            IRatingRepository ratingRepository)
        {
            _repository = ratingRepository;
        }

        public List<TopRatedJoke> GetTopRatedJokes()
        {
            var jokes = _repository.GetTopRatedJokes();
            return jokes.Select(j => new TopRatedJoke(j.Joke.Id, j.Joke.Setup, j.Joke.Punchline, j.Joke.Type, j.Stars)).ToList();
        }

        public async Task<List<TopRatedJoke>> GetTopRatedJokesAsync()
        {
            var jokes = await _repository.GetTopRatedJokesAsync();
            return jokes.Select(j => new TopRatedJoke(j.Joke.Id, j.Joke.Setup, j.Joke.Punchline, j.Joke.Type, j.Stars)).ToList();
        }
    }
}
