using System.Collections.Generic;

namespace Lith.DocStore.Models
{
    public class Shop : BaseRecord
    {
        public Shop()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public List<Product> Products { get; set; }

        public Account Account { get; set; }
    }
}
