using Lith.DocStore.Common;
using Lith.DocStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            collection.Add(new Shop { Name = "Spar", Category = "Grocer" });
            collection.Add(new Shop { Name = "Tops", Category = "Bottle Store" });
            collection.Add(new Shop { Name = "Checkers", Category = "Grocer" });
            collection.Add(new Shop { Name = "Pick & Pay", Category = "Grocer" });
            collection.Add(new Shop { Name = "Wheel & Tyre", Category = "Auto Repairs" });
            collection.Add(new Shop { Name = "Dros", Category = "Luxury" });
            collection.Add(new Shop { Name = "Nu-Metro", Category = "Luxury" });

            return collection;
        }
    }
}
