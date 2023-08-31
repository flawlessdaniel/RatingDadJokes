using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RatingDadJokes.ExternalData.Dtos;
using RatingDadJokes.ExternalData.Service;
using RatingDadJokes.Shared.Discovery;
using RatingDadJokes.Shared.Secrets;

namespace RatingDadJokes.ExternalData.DadJokesIo
{
    public class DadJokesIoDataProvider : IExternalDataProvider
    {
        private readonly HttpClient _httpClient;
        private readonly DadJokesIoSettings _providerSettings;
        private readonly ISecretManager _secretsManager;

        public DadJokesIoDataProvider(
            HttpClient httpClient,
            IOptions<DadJokesIoSettings> providerSettings,
            ISecretManager secretManager)
        {
            _httpClient = httpClient;
            _providerSettings = providerSettings.Value;
            _secretsManager = secretManager;
        }

        RandomJoke defaultRamdonJoke = new("NN", "NN", "NN", "NN");

        public int GetJokeCount()
        {
            return 0;
        }

        public async Task<int> GetJokeCountAsync()
        {
            var connectionSettings = await GetConnectionSettings();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{connectionSettings.EndPoint}/joke/count"),
                Headers =
                {
                    { "X-RapidAPI-Key", connectionSettings.ApiKey },
                    { "X-RapidAPI-Host", connectionSettings.ApiHost },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jsonData = JObject.Parse(body);
                if (!jsonData.TryGetValue("success", out var result)) return 0;
                if (!result.Value<bool>()) return 0;
                if (!jsonData.TryGetValue("body", out var bodyResult)) return 0;
                var bodyData = bodyResult.Value<int>();
                return bodyData;
            }
        }

        public async Task<RandomJoke> GetRandomJokeAsync()
        {
            var connectionSettings = await GetConnectionSettings();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{connectionSettings.EndPoint}/random/joke"),
                Headers =
                {
                    { "X-RapidAPI-Key", connectionSettings.ApiKey },
                    { "X-RapidAPI-Host", connectionSettings.ApiHost },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jsonData = JObject.Parse(body);
                if (!jsonData.TryGetValue("success", out var result)) return defaultRamdonJoke;
                if (!result.Value<bool>()) return defaultRamdonJoke;
                if (!jsonData.TryGetValue("body", out var bodyResult)) return defaultRamdonJoke;
                var bodyData = bodyResult.Value<JArray>();
                if (bodyData == null) return defaultRamdonJoke;

                return new(bodyData[0].Value<string>("_id") ?? defaultRamdonJoke.Id,
                    bodyData[0].Value<string>("setup") ?? defaultRamdonJoke.Setup,
                    bodyData[0].Value<string>("punchline") ?? defaultRamdonJoke.Punchline,
                    bodyData[0].Value<string>("type") ?? defaultRamdonJoke.Type);
            }
        }

        public RandomJoke GetRandomJoke()
        {
            return null;
        }

        private async Task<(string EndPoint, string ApiKey, string ApiHost)> GetConnectionSettings()
        {
            var EndPoint = $"{_providerSettings.RapidAPIUrl}";
            if (string.IsNullOrEmpty(EndPoint)) return (string.Empty, string.Empty, string.Empty);
            var ApiKey = await GetDataProviderApiKey();
            if (string.IsNullOrEmpty(ApiKey)) return (EndPoint, string.Empty, string.Empty);
            var ApiHost = await GetDataProviderHost();
            if (string.IsNullOrEmpty(ApiHost)) return (EndPoint, ApiKey, string.Empty);
            return (EndPoint, ApiKey, ApiHost);
        }

        private async Task<string> GetDataProviderApiKey()
        {
            var secret = await _secretsManager.Get<SecretsRegistry.JokesApiKey>(SecretsRegistry.ExternalJokesDataApiKey);
            return secret.dadjokeapikey?.ToString() ?? string.Empty;
        }

        private async Task<string> GetDataProviderHost()
        {
            var secret = await _secretsManager.Get<SecretsRegistry.JokesApiHost>(SecretsRegistry.ExternalJokesDataHost);
            return secret.dadjokeapihost?.ToString() ?? string.Empty;
        }
    }
}
