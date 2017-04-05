using Lith.DocStore.Common;
using Lith.DocStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lith.DocStore.Tests
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        public void CanWriteModelToFile()
        {
            var shop = new Shop
            {
                Name = "Spar",
                Category = "Grocer"
            };

            var manager = new Manager(new JSONModelHelper());
            var id = manager.Save<Shop>(shop);

            Shop item = manager.Load<Shop>(id);
            Assert.AreEqual(shop.ID, item.ID);
        }
    }
}
