using Newtonsoft.Json;

namespace Lith.DocStore.ModelHelper
{
    public class JSONModelHelper : IHelpModels
    {
        public T DeStringify<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Stringify(object data)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(data);
        }
    }
}
