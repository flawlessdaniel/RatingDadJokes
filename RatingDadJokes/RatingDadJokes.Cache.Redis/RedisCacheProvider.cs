using Microsoft.Extensions.Options;
using RatingDadJokes.Cache.Service;
using StackExchange.Redis;
using System.Text.Json;

namespace RatingDadJokes.Cache.Redis
{
    public class RedisCacheProvider : IExternalCacheProvider
    {
        private readonly RedisSettings _settings;

        public RedisCacheProvider(
            IOptions<RedisSettings> settings)
        {
            _settings = settings.Value;
        }

        public void AddToCache(string key, object value, int minutes)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_settings.RedisUrl);
            IDatabase db = redis.GetDatabase();
            var serialized = JsonSerializer.Serialize(value);
            db.StringSet(key, serialized, TimeSpan.FromMinutes(minutes));
        }

        public void ClearFromCache(string key)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_settings.RedisUrl);
            IDatabase db = redis.GetDatabase();
            db.KeyDelete(key);
        }

        public bool ContainsKey(string key)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_settings.RedisUrl);
            IDatabase db = redis.GetDatabase();
            return db.KeyExists(key);
        }

        public T GetFromCache<T>(string key) where T : class
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_settings.RedisUrl);
            IDatabase db = redis.GetDatabase();
            var data = db.StringGet(key);
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}