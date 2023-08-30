using RatingDadJokes.Data.Model;
using RatingDadJokes.Data.Service.Dtos;

namespace RatingDadJokes.Data.Service.Commands
{
    public interface IAddRatedJokeCommand
    {
        public void AddRatedJokeCommand(AddRatedJokeRequest request);
        public Task AddRatedJokeCommandAsync(AddRatedJokeRequest request);
    }

    public class AddRatedJokeCommand : IAddRatedJokeCommand
    {
        public Task AddRatedJokeCommandAsync(AddRatedJokeRequest request)
        {
            throw new NotImplementedException();
        }

        void IAddRatedJokeCommand.AddRatedJokeCommand(AddRatedJokeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}