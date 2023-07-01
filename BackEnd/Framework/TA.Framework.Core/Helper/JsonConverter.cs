using Newtonsoft.Json;

namespace TA.Framework.Core.Helper
{
    public class JsonConverter
    {
        public static T ToType<T>(dynamic obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }
    }
}
