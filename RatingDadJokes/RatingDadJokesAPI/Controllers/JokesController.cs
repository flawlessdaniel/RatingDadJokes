using Microsoft.AspNetCore.Mvc;
using RatingDadJokes.Cache.Service;
using RatingDadJokes.Core;
using RatingDadJokes.Data.Service.Commands;
using RatingDadJokes.Data.Service.Queries;
using RatingDadJokes.ExternalData.Service;
using RatingDadJokesAPI.Exceptions;

namespace RatingDadJokesAPI.Controllers
{
    [ApiController]
    [TypeFilter(typeof(CustomExceptionFilter))]
    [Route("jokes")]
    public class JokesController : ControllerBase
    {
        private readonly IJokeDataProvider _jokeDataProvider;
        private readonly IAddRatedJokeCommand _addRatedJokeCommand;
        private readonly IGetTopRatedJokesQuery _getTopRatedJokesQuery;
        private readonly ICacheProvider _cacheProvider;

        public JokesController(
            IJokeDataProvider jokeDataProvider,
            IAddRatedJokeCommand addRatedJokeCommand,
            IGetTopRatedJokesQuery getTopRatedJokesQuery,
            ICacheProvider cacheProvider)
        {
            _jokeDataProvider = jokeDataProvider;
            _addRatedJokeCommand = addRatedJokeCommand;
            _getTopRatedJokesQuery = getTopRatedJokesQuery;
            _cacheProvider = cacheProvider;
        }

        [HttpGet("random")]
        public async Task<Joke> GetRandomJoke()
        {
            var ramdonJoke = await _jokeDataProvider.GetRandomJokeAsync();
            return new(ramdonJoke.Id,
                ramdonJoke.Setup,
                ramdonJoke.Punchline,
                ramdonJoke.Type);
        }

        [HttpGet("count")]
        public async Task<int> GetJokeCount()
        {
            return await _jokeDataProvider.GetJokeCountAsync();
        }

        [HttpPost("rate")]
        public async Task AddJokeRating(Rating rating)
        {
            await _addRatedJokeCommand.AddRatedJokeAsync(new(rating.TargetJoke.Id, rating.TargetJoke.Setup, rating.TargetJoke.Punchline, rating.TargetJoke.Type, rating.RatingValue));
            _cacheProvider.ClearFromCache("topratedjokes");
        }

        [HttpGet("toprated")]
        public async Task<List<Rating>> GetTopRatedJokes()
        {
            if (_cacheProvider.ContainsKey("topratedjokes"))
                return _cacheProvider.GetFromCache<List<Rating>>("topratedjokes");

            var jokes = await _getTopRatedJokesQuery.GetTopRatedJokesAsync();
            var data = jokes.Select(j => new Rating(new Joke(j.Id, j.Setup, j.Punchline, j.Type), j.rating)).ToList();
            _cacheProvider.AddToCache("topratedjokes", data, 5);
            return data;
        }
    }
}