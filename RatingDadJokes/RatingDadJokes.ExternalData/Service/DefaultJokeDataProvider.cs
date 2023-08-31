using RatingDadJokes.ExternalData.Dtos;

namespace RatingDadJokes.ExternalData.Service
{
    public class DefaultJokeDataProvider : IJokeDataProvider
    {
        private readonly IExternalDataProvider _externalDataProvider;

        public DefaultJokeDataProvider(
            IExternalDataProvider externalDataProvider)
        {
            _externalDataProvider = externalDataProvider;
        }

        public int GetJokeCount()
        {
            return _externalDataProvider.GetJokeCount();
        }

        public async Task<int> GetJokeCountAsync()
        {
            return await _externalDataProvider.GetJokeCountAsync();
        }

        public async Task<RandomJoke> GetRandomJokeAsync()
        {
            return await _externalDataProvider.GetRandomJokeAsync();
        }

        public RandomJoke GetRandomJoke()
        {
            return _externalDataProvider.GetRandomJoke();
        }
    }
}