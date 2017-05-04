using Lith.DocStore.ModelHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Models
{
    public class ModelsContext : StoreContext
    {
        public ModelsContext()
            : base(new JSONModelHelper())
        {

        }

        public ItemSet<Shop> Shops { get; set; }

        public ItemSet<Transaction> Transactions { get; set; }

        public ItemSet<Summary> Summaries { get; set; }
    }
}
