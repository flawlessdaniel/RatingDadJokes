using RatingDadJokes.Data.Model;
using RatingDadJokes.Data.Service.Dtos;

namespace RatingDadJokes.Data.Service.Commands
{
    public interface IAddRatedJokeCommand
    {
        public void AddRatedJoke(AddRatedJokeRequest request);
        public Task AddRatedJokeAsync(AddRatedJokeRequest request);
    }

    public class AddRatedJokeCommand : IAddRatedJokeCommand
    {
        private readonly IRatingRepository _repository;
        public AddRatedJokeCommand(IRatingRepository repository)
        {
            _repository = repository;
        }

        public async Task AddRatedJokeAsync(AddRatedJokeRequest request)
        {
            if (request.Rating < 5) return;

            await _repository.AddRatingAsync(new Rating()
            {
                Id = Guid.NewGuid().ToString(),
                Joke = new Joke()
                {
                    Id = request.Id,
                    Setup = request.Setup,
                    Punchline = request.Punchline,
                    Type = request.Type
                },
                Stars = request.Rating
            });
        }

        public void AddRatedJoke(AddRatedJokeRequest request)
        {
            if (request.Rating < 5) return;

            _repository.AddRating(new Rating()
            {
                Id = Guid.NewGuid().ToString(),
                Joke = new Joke()
                {
                    Id = request.Id,
                    Setup = request.Setup,
                    Punchline = request.Punchline,
                    Type = request.Type
                },
                Stars = request.Rating
            });
        }
    }
}