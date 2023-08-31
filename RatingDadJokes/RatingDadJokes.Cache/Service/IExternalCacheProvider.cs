namespace RatingDadJokes.Cache.Service
{
    public interface IExternalCacheProvider
    {
        void AddToCache(string key, object value, int minutes);
        bool ContainsKey(string key);
        T GetFromCache<T>(string key) where T : class;
        void ClearFromCache(string key);
    }
}