using Lith.DocStore.ModelHelper;
using Lith.DocStore.Models;
using System.Collections.Generic;

namespace Lith.DocStore.Tests.SupportingUtils
{
    public static class ContextDataSetup
    {
        public static void SetupDummyData()
        {
            var manager = new Manager(new JSONModelHelper());
            var shops = GetSomeShops();

            foreach (var shop in shops)
            {
                manager.Save(shop);
            }
        }

        private static IList<Shop> GetSomeShops()
        {
            var collection = new List<Shop>();

            collection.Add(new Shop { Name = "Spar", Category = "Grocer", Products = GetProducts(), Account = GetAccount() });
            collection.Add(new Shop { Name = "Tops", Category = "Bottle Store", Products = GetProducts(), Account = GetAccount() });
            collection.Add(new Shop { Name = "Checkers", Category = "Grocer", Products = GetProducts(), Account = GetAccount() });
            collection.Add(new Shop { Name = "Pick & Pay", Category = "Grocer", Products = GetProducts(), Account = GetAccount() });
            collection.Add(new Shop { Name = "Wheel & Tyre", Category = "Auto Repairs", Products = GetProducts(), Account = GetAccount() });
            collection.Add(new Shop { Name = "Dros", Category = "Luxury", Products = GetProducts(), Account = GetAccount() });
            collection.Add(new Shop { Name = "Nu-Metro", Category = "Luxury", Products = GetProducts(), Account = GetAccount() });

            return collection;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product>();

            products.Add(new Product { Name = "Chips", Price = 10.50M });
            products.Add(new Product { Name = "Coke", Price = 17.20M });

            return products;
        }

        private static Account GetAccount()
        {
            return new Account { Number = "A456BD", Bank = "Fake Bank" };
        }

    }
}
