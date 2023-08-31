namespace RatingDadJokes.Data.Service.Dtos
{
    public record TopRatedJoke(string Id, string Setup, string Punchline, string Type, int rating);
}
