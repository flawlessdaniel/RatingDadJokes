namespace RatingDadJokes.Cache.Service
{
    public class DefaultCacheProvider : ICacheProvider
    {
        private readonly IExternalCacheProvider _externalCacheProvider;

        public DefaultCacheProvider(
            IExternalCacheProvider externalCacheProvider)
        {
            _externalCacheProvider = externalCacheProvider;
        }

        public void AddToCache(string key, object value, int minutes)
        {
            _externalCacheProvider.AddToCache(key, value, minutes);
        }

        public T GetFromCache<T>(string key) where T : class
        {
            return _externalCacheProvider.GetFromCache<T>(key);
        }

        public bool ContainsKey(string key)
        {
            return _externalCacheProvider.ContainsKey(key);
        }

        public void ClearFromCache(string key)
        {
            _externalCacheProvider.ClearFromCache(key);
        }
    }
}