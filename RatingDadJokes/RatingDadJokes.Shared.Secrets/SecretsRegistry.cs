namespace RatingDadJokes.Shared.Secrets
{
    public class SecretsRegistry
    {
        public const string ExternalJokesDataApiKey = "externaldata";
        public record JokesApiKey()
        {
            public object dadjokeapikey { get; set; } = null!;
        }

        public const string ExternalJokesDataHost = "externalhost";
        public record JokesApiHost()
        {
            public object dadjokeapihost { get; set; } = null!;
        }
    }
}
