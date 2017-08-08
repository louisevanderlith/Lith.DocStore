using Lith.DocStore.ModelHelper;
using Lith.DocStore.Models;
using Lith.DocStore.Tests.SupportingUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Lith.DocStore.Tests
{
    [TestClass]
    public class ModelContextTests
    {
        public ModelContextTests()
        {
            ContextDataSetup.SetupDummyData();
        }

        [TestMethod]
        public void GetAllFromStore_NotEmpty()
        {
            var modelHelper = new JSONModelHelper();
            using (var ctx = new ModelsContext(modelHelper))
            {
                var actual = ctx.Shops;

                Assert.IsTrue(actual.Any());
            }
        }

        [TestMethod]
        public void GetAllFromStore_withLinq_NotEmpty()
        {
            var modelHelper = new JSONModelHelper();
            using (var ctx = new ModelsContext(modelHelper))
            {
                var actual = from a in ctx.Shops
                             where a.Category == "Grocer"
                             select a;

                Assert.IsTrue(actual.Any());
            }
        }

        [TestMethod]
        public void AddToStore_ShouldNOTSave()
        {
            var shopA = new Shop
            {
                Category = "A",
                Name = "Supermarket"
            };

            var modelHelper = new JSONModelHelper();
            using (var ctx = new ModelsContext(modelHelper))
            {
                ctx.Shops.Add(shopA);
            }

            using (var ctx = new ModelsContext(modelHelper))
            {
                var results = from a in ctx.Shops
                              where a.Name == "Supermarket"
                              && a.Category == "A"
                              select a;

                Assert.IsFalse(results.Any());
            }
        }

        [TestMethod]
        public void AddToStore_WithSave_ShouldSave()
        {
            var shopA = new Shop
            {
                Category = "XX",
                Name = "SupermarketX"
            };

            var modelHelper = new JSONModelHelper();
            using (var ctx = new ModelsContext(modelHelper))
            {
                ctx.Shops.Add(shopA);
                ctx.Save();
            }

            using (var ctx = new ModelsContext(modelHelper))
            {
                var results = from a in ctx.Shops
                              where a.Name == "SupermarketX"
                              && a.Category == "XX"
                              select a;

                Assert.IsTrue(results.Any());
            }
        }

        [TestMethod]
        public void AddToStore_MustHaveItem()
        {
            var shopA = new Shop
            {
                Category = "A",
                Name = "Supermarket"
            };

            var modelHelper = new JSONModelHelper();
            using (var ctx = new ModelsContext(modelHelper))
            {
                ctx.Shops.Add(shopA);

                var results = from a in ctx.Shops
                              where a.Name == "Supermarket"
                              && a.Category == "A"
                              select a;

                Assert.IsTrue(results.Any());
            }
        }

        [TestMethod]
        public void AddRangeToStore_MustHaveItems()
        {
            var shopA = new Shop
            {
                Category = "A",
                Name = "Supermarket"
            };

            var shopB = new Shop
            {
                Category = "B",
                Name = "Other"
            };

            var modelHelper = new JSONModelHelper();
            using (var ctx = new ModelsContext(modelHelper))
            {
                ctx.Shops.AddRange(new List<Shop> { shopA, shopB });

                var results = from a in ctx.Shops
                              where (a.Name == "Supermarket" && a.Category == "A")
                              || (a.Name == "Other" && a.Category == "B")
                              select a;

                Assert.AreEqual(2, results.Count());
            }
        }

        [TestMethod]
        public void UpdateModelInStore_MustHaveNewValue()
        {
            var modelHelper = new JSONModelHelper();
            using (var ctx = new ModelsContext(modelHelper))
            {
                var itemToUpdate = ctx.Shops.FirstOrDefault(a => !a.IsDeleted);
                var oldName = itemToUpdate.Name;

                itemToUpdate.Name += "CHANGED";

                var results = from a in ctx.Shops
                              where a.Name == oldName + "CHANGED"
                              select a;

                Assert.IsTrue(results.Any());
            }
        }
    }
}
