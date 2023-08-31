namespace RatingDadJokes.ExternalData.DadJokesIo
{
    public record DadJokesIoSettings
    {
        public string? RapidAPIUrl { get; private set; }

        public void UpdateUrl(string url)
        {
            RapidAPIUrl = url;
        }
    }
}