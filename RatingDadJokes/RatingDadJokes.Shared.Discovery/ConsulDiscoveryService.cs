using Consul;
using System.Text;

namespace RatingDadJokes.Shared.Discovery
{
    public record DiscoveryData(string Server, int Port);

    public interface IServiceDiscovery
    {
        Task<string> GetFullAddress(string serviceKey, CancellationToken cancellationToken = default);
        Task<DiscoveryData> GetDiscoveryData(string serviceKey, CancellationToken cancellationToken = default);
    }

    public class ConsulDiscoveryService : IServiceDiscovery
    {
        private readonly IConsulClient _client;

        public ConsulDiscoveryService(IConsulClient client)
        {
            _client = client;
        }


        public async Task<string> GetFullAddress(string serviceKey, CancellationToken cancellationToken = default)
        {
            DiscoveryData data = await GetDiscoveryData(serviceKey, cancellationToken);
            return GetAddressFromData(data);
        }

        public async Task<DiscoveryData> GetDiscoveryData(string serviceKey, CancellationToken cancellationToken = default)
        {
            var services = await _client.Catalog.Service(serviceKey, cancellationToken);
            if (services.Response != null && services.Response.Any())
            {
                var service = services.Response.First();

                DiscoveryData data = new DiscoveryData(service.ServiceAddress, service.ServicePort);

                return data;
            }

            throw new ArgumentException($"seems like the service your are trying to access ({serviceKey}) does not exist ");
        }


        private string GetAddressFromData(DiscoveryData data)
        {
            StringBuilder serviceAddress = new StringBuilder();
            serviceAddress.Append(data.Server);
            if (data.Port != 0)
            {
                serviceAddress.Append($":{data.Port}");
            }

            string serviceAddressString = serviceAddress.ToString();


            return serviceAddressString;
        }
    }
}