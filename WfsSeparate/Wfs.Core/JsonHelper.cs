using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Wfs.Core
{
    public class JsonHelper
    {
        private static JsonHelper _jsonHelper = new JsonHelper();
        public static JsonHelper Instance { get { return _jsonHelper; } }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        public string SerializeByConverter(object obj, params JsonConverter[] converters)
        {
            return JsonConvert.SerializeObject(obj, converters);
        }

        public T Deserialize<T>(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception e)
            {
                var nullT = default(T);
                return nullT;
            }

        }

        public T DeserializeByConverter<T>(string input, params JsonConverter[] converter)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input, converter);
            }
            catch (Exception e)
            {
                var nullT = default(T);
                return nullT;
            }

        }

        public T DeserializeBySetting<T>(string input, JsonSerializerSettings settings)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input, settings);
            }
            catch (Exception e)
            {
                var nullT = default(T);
                return nullT;
            }

        }

        private object NullToEmpty(object obj)
        {
            return null;
        }
    }
}
