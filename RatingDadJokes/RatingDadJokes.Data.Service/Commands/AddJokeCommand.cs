using RatingDadJokes.Data.Model;
using RatingDadJokes.Data.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingDadJokes.Data.Service.Commands
{
    public interface IAddJokeCommand
    {
        void AddJose(AddJokeRequest joke);
    }

    public class AddJokeCommand : IAddJokeCommand
    {
        private readonly IRatingRepository _repository;
        public AddJokeCommand(IRatingRepository repository)
        {
            _repository = repository;
        }

        public void AddJose(AddJokeRequest joke)
        {
            _repository.AddJoke(new Joke()
            {
                Id = joke.Id,
                Setup = joke.Setup,
                Punchline = joke.Punchline,
                Type = joke.Type
            });
        }
    }
}
