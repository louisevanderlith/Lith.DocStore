﻿using Lith.DocStore.Models;
using Lith.DocStore.Tests.SupportingUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Tests
{
    [TestClass]
    public class StoreContextTests
    {
        public StoreContextTests()
        {
            ContextDataSetup.SetupDummyData();
        }

        [TestMethod]
        public void GetAllFromStore_NotEmpty()
        {
            using (var ctx = new StoreContext())
            {
                var actual = ctx.Set<Shop>();

                Assert.IsTrue(actual.Any());
            }
        }

        [TestMethod]
        public void GetAllFromStore_withLinq_NotEmpty()
        {
            using (var ctx = new StoreContext())
            {
                var actual = from a in ctx.Set<Shop>()
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

            using (var ctx = new StoreContext())
            {
                ctx.Add(shopA);
            }

            using (var ctx = new StoreContext())
            {
                var results = from a in ctx.Set<Shop>()
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

            using (var ctx = new StoreContext())
            {
                ctx.Add(shopA);
                ctx.Save();
            }

            using (var ctx = new StoreContext())
            {
                var results = from a in ctx.Set<Shop>()
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

            using (var ctx = new StoreContext())
            {
                ctx.Add(shopA);

                var results = from a in ctx.Set<Shop>()
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

            using (var ctx = new StoreContext())
            {
                ctx.AddRange(new List<Shop> { shopA, shopB });

                var results = from a in ctx.Set<Shop>()
                              where (a.Name == "Supermarket" && a.Category == "A")
                              || (a.Name == "Other" && a.Category == "B")
                              select a;

                Assert.AreEqual(2, results.Count());
            }
        }

        [TestMethod]
        public void UpdateModelInStore_MustHaveNewValue()
        {
            using (var ctx = new StoreContext())
            {
                var itemToUpdate = ctx.Set<Shop>().FirstOrDefault(a => !a.IsDeleted);
                var oldName = itemToUpdate.Name;

                itemToUpdate.Name += "CHANGED";

                var results = from a in ctx.Set<Shop>()
                              where a.Name == oldName + "CHANGED"
                              select a;

                Assert.IsTrue(results.Any());
            }
        }
    }
}