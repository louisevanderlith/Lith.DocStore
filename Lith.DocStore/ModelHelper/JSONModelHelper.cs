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
            return JsonConvert.SerializeObject(data);
        }
    }
}
