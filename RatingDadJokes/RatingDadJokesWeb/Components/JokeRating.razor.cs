using RatingDadJokes.Core;

namespace RatingDadJokesWeb.Components
{
    public partial class JokeRating
    {
        public int rating { get; set; }
        public Joke TargetJoke { get; set; }

        protected override Task OnInitializedAsync()
        {
            TargetJoke = new Joke("123", "afasf", "gsdgsdgsd", "fsdf");
            return Task.CompletedTask;
        }

        public async Task SendRating(int rating)
        {
            //TODO Send rating to the api
        }
    }
}
