using RatingDadJokes.ExternalData.Dtos;

namespace RatingDadJokes.ExternalData.Service
{
    public interface IExternalDataProvider
    {
        RandomJoke GetRandomJoke();
        Task<RandomJoke> GetRandomJokeAsync();
        int GetJokeCount();
        Task<int> GetJokeCountAsync();
    }
}