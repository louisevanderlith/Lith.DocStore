using Lith.DocStore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lith.DocStore.ModelHelper
{
    public class XMLModelHelper : IHelpModels
    {
        public string Stringify(object data)
        {
            var result = new StringBuilder();
            var serializer = new XmlSerializer(data.GetType());

            using (var stream = new StringWriter(result))
            {
                serializer.Serialize(stream, data);
            }

            return result.ToString();
        }

        public T DeStringify<T>(string data)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new StringReader(data))
            {
                var obj = serializer.Deserialize(reader);

                return (T)obj;
            }
        }
    }
}
