namespace RatingDadJokes.Data.Service.Dtos
{
    public record AddJokeRequest(string Id, string Setup, string Punchline, string Type);
    public record AddRatedJokeRequest(string Id, string Setup, string Punchline, string Type, int Rating);
}