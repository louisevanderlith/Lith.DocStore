using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Common
{
    public static class PathHelper
    {
        public static string StripFileName(string path)
        {
            var lastPartIndex = path.LastIndexOf('\\');

            return path.Substring(0, lastPartIndex);
        }
    }
}
