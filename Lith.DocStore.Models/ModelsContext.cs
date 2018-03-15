namespace Lith.DocStore.Models
{
    public class ModelsContext : StoreContext
    {
        public ModelsContext(IHelpModels modelHelper)
            : base(modelHelper) { }

        public ItemSet<Shop> Shops { get; set; }

        public ItemSet<Transaction> Transactions { get; set; }

        public ItemSet<Summary> Summaries { get; set; }

        public ItemSet<Product> Products { get; set; }
    }
}
