using System.Reflection;

namespace RatingDadJokes.Shared.Secrets
{
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source) where T : new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                    .GetProperty(item.Key)!
                    .SetValue(someObject, item.Value, null);
            }
            return someObject;
        }

        public static T MapToType<T>(this IDictionary<string, object> dictionary) where T : new()
        {
            var targetType = typeof(T);
            var result = new T();

            foreach (var kvp in dictionary)
            {
                var propertyName = kvp.Key;
                var propertyValue = kvp.Value;

                var propertyInfo = targetType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    var convertedValue = Convert.ChangeType(propertyValue, propertyInfo.PropertyType);
                    propertyInfo.SetValue(result, convertedValue);
                }
            }

            return result;
        }
    }
}
