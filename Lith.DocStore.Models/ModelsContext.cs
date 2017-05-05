﻿using Lith.DocStore.ModelHelper;

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
