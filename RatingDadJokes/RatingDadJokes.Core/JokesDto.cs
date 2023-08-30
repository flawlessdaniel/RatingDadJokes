namespace RatingDadJokes.Core
{
    public record Joke(string Id, string Setup, string Punchline, string Type);
    public record Rating(Joke TargetJoke, int RatingValue);
}