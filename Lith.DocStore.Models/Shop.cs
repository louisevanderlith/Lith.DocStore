using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Models
{
    public class Shop : BaseRecord
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }
}
