using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Models
{
    public class Product : BaseRecord
    {
        public Product()
        {
            Shops = new List<Shop>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<Shop> Shops { get; set; }
    }
}
