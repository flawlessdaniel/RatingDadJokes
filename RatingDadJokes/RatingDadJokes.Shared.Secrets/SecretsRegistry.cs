namespace RatingDadJokes.Shared.Secrets
{
    public class SecretsRegistry
    {
        public const string ExternalJokesDataApiKey = "externaldata";
        public record JokesApiKey()
        {
            public object dadjokeapikey { get; set; } = null!;
        }
    }
}
