using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LotteryWeb.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T obje)
        {
            var json = JsonConvert.SerializeObject(obje);
            session.SetString(key, json);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string json = session.GetString(key);
            if (string.IsNullOrWhiteSpace(json))
                return default;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
