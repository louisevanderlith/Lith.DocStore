using Lith.DocStore.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
