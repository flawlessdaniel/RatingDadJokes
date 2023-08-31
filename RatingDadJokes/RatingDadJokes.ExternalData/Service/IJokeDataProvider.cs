using RatingDadJokes.ExternalData.Dtos;

namespace RatingDadJokes.ExternalData.Service
{
    public interface IJokeDataProvider
    {
        RandomJoke GetRandomJoke();
        Task<RandomJoke> GetRandomJokeAsync();
        int GetJokeCount();
        Task<int> GetJokeCountAsync();
    }
}