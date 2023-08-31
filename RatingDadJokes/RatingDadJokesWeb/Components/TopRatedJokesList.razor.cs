using RatingDadJokes.Core;
using System.Net.Http.Json;

namespace RatingDadJokesWeb.Components
{
    public partial class TopRatedJokesList
    {
        public List<Rating> TopRatedJokes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TopRatedJokes = await httpClient.GetFromJsonAsync<List<Rating>>("/jokes/toprated");
        }
    }
}
