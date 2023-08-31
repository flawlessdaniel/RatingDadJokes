using RatingDadJokes.Core;
using System.Net.Http.Json;

namespace RatingDadJokesWeb.Components
{
    public partial class JokeRating
    {
        public int rating { get; set; }
        public Joke TargetJoke { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetRandomJoke();
        }

        private async Task GetRandomJoke()
        {
            var randomJoke = await httpClient.GetFromJsonAsync<Joke>("/jokes/random");
            if (randomJoke != null)
            {
                TargetJoke = new Joke(
                randomJoke.Id,
                randomJoke.Setup,
                randomJoke.Punchline,
                randomJoke.Type);
            }
        }

        public async Task SendRating(int rating)
        {
            await httpClient.PostAsJsonAsync("/jokes/rate", new Rating(TargetJoke, rating));
            await GetRandomJoke();
        }
    }
}
