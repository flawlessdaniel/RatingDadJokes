using NSubstitute;
using RatingDadJokes.Data.Service;
using RatingDadJokes.Data.Service.Commands;
using Xunit;
using RatingDadJokes.Data.Service.Dtos;
using RatingDadJokes.Data.Model;
using RatingDadJokes.Data.Service.Queries;
using RatingDadJokes.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Data.Sqlite;

namespace RatingDadJokes.Test.Data.Service
{
    public class TestAddRatedJoke
    {
        [Fact]
        public async Task JokeRatedAs5_ShouldBeAddedToDB()
        {
            var _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            var _contextOptions = new DbContextOptionsBuilder<RatingDadJokesDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Create the schema and seed some data
            using var context = new RatingDadJokesDbContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                IRatingRepository ratingRepository = new RatingRepository(context);
                // Act
                IAddRatedJokeCommand command = new AddRatedJokeCommand(ratingRepository);
                await command.AddRatedJokeAsync(new AddRatedJokeRequest(
                    "1",
                    "Joke 1",
                    "Joke 1",
                    "Joke", 5));

                IGetTopRatedJokesQuery query = new GetTopRatedJokesQuery(ratingRepository);
                var totalRatedJokes = query.GetTopRatedJokes();

                Assert.Single(totalRatedJokes);
            }
        }

        [Fact]
        public async void JokeRatedLessThan5_ShouldNotBeAddedToDB()
        {
            var _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            var _contextOptions = new DbContextOptionsBuilder<RatingDadJokesDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Create the schema and seed some data
            using var context = new RatingDadJokesDbContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                IRatingRepository ratingRepository = new RatingRepository(context);
                // Act
                IAddRatedJokeCommand command = new AddRatedJokeCommand(ratingRepository);
                await command.AddRatedJokeAsync(new AddRatedJokeRequest(
                    "1",
                    "Joke 1",
                    "Joke 1",
                    "Joke", 3));

                IGetTopRatedJokesQuery query = new GetTopRatedJokesQuery(ratingRepository);
                var totalRatedJokes = query.GetTopRatedJokes();

                Assert.Empty(totalRatedJokes);
            }
        }
    }
}