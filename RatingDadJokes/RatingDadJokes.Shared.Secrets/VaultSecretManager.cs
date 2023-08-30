using Microsoft.Extensions.Options;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;
using VaultSharp.V1.SecretsEngines;

namespace RatingDadJokes.Shared.Secrets
{
    public interface ISecretManager
    {
        Task<T> Get<T>(string path) where T : new();
        //Task<string> GetSimple(string path);
    }

    internal class VaultSecretManager : ISecretManager
    {
        private readonly VaultSettings _vaultSettings;

        public VaultSecretManager(IOptions<VaultSettings> vaultSettings)
        {
            _vaultSettings = vaultSettings.Value with { TokenApi = GetTokenFromEnvironmentVariable() };
        }

        public async Task<T> Get<T>(string path)
            where T : new()
        {
            VaultClient client = new VaultClient(new VaultClientSettings(_vaultSettings.VaultUrl,
                new TokenAuthMethodInfo(_vaultSettings.TokenApi)));

            Secret<SecretData> kv2Secret = await client.V1.Secrets.KeyValue.V2
                .ReadSecretAsync(path: path, mountPoint: "secret");
            var returnedData = kv2Secret.Data.Data;

            return returnedData.ToObject<T>();
        }

        //public async Task<string> GetSimple(string path)
        //{
        //    VaultClient client = new VaultClient(new VaultClientSettings(_vaultSettings.VaultUrl,
        //        new TokenAuthMethodInfo(_vaultSettings.TokenApi)));

        //    Secret<SecretData> kv2Secret = await client.V1.Secrets.KeyValue.V2
        //        .ReadSecretAsync(path: path, mountPoint: "secret");
        //    return kv2Secret.Data.Data.First().Value.ToString();
        //}

        private string GetTokenFromEnvironmentVariable()
            => Environment.GetEnvironmentVariable("VAULT-TOKEN")
               ?? throw new NotImplementedException("please specify the VAULT-TOKEN env_var");
    }
}
