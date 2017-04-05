using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Common
{
    public interface IHelpModels
    {
        string Stringify(object data);

        T DeStringify<T>(string data);
    }
}
