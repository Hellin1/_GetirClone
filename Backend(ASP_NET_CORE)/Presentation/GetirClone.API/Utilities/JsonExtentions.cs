using Newtonsoft.Json;
using System.Text;

namespace GetirClone.Application.Utilities
{
    public static class JsonExtentions
    {
        /// <summary>
        /// Gönderilen tipteki veriyi Json formatında texte çevirir.
        /// </summary>
        /// <typeparam name="TValue">Gönderilen verinin tipi</typeparam>
        /// <param name="data">Gönderilen veri</param>
        /// <returns></returns>
        public static string ToJson<TValue>(this TValue data)
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
        }
        /// <summary>
        /// Gönderilen json formatındaki string değeri {TResult} tipinde nesneye çevirir.
        /// </summary>
        /// <typeparam name="TResult">Verinin şeklini taşıyan class</typeparam>
        /// <param name="rawJson"></param>
        /// <returns></returns>
        public static TResult FromJson<TResult>(this string rawJson)
        {
            return JsonConvert.DeserializeObject<TResult>(rawJson);
        }
        /// <summary>
        /// Gönderilen datayı serilize edip UTF-8 Encode'u ile byte array'e çevirir.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] ToBytesJson<TValue>(this TValue data)
        {
            return Encoding.UTF8.GetBytes(data.ToJson());
        }
        /// <summary>
        /// Gönderilen datayı UTF*8 stringe çevirip deserialize yapar.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static TResult FromBytesJson<TResult>(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes).FromJson<TResult>();
        }
    }
}
