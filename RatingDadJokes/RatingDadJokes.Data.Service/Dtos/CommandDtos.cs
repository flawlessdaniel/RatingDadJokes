namespace RatingDadJokes.Data.Service.Dtos
{
    public record AddJokeRequest(string Id, string Setup, string Punchline, string Type);
    public record AddRatedJokeRequest(AddJokeRequest joke, int Id);
}