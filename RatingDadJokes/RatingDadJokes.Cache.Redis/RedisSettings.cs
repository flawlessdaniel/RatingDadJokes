namespace RatingDadJokes.Cache.Redis
{
    public record RedisSettings
    {
        public string? RedisUrl { get; private set; }

        public void UpdateUrl(string url)
        {
            RedisUrl = url;
        }
    }
}