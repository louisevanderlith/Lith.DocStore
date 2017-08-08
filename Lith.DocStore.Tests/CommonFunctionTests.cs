using Lith.DocStore.Common;
using Lith.DocStore.ModelHelper;
using Lith.DocStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lith.DocStore.Tests
{
    [TestClass]
    public class CommonFunctionTests
    {
        [TestMethod]
        public void StripFileName_RemovesFile()
        {
            var path = @"C:\Users\user\records\fake\5c44bc2a-67ad-411e-b434-cc18850bd2cf";
            var expected = @"C:\Users\user\records\fake";
            var actual = PathHelper.StripFileName(path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Stringify_DoesntReturnEmpty()
        {
            var shop = new Shop
            {
                Name = "XXX",
                ID = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                IsDeleted = false
            };

            var modelHelper = new XMLModelHelper();
            var actual = modelHelper.Stringify(shop);
            var lookLikeXml = actual.StartsWith("<?xml version=\"1.0\" encoding=\"utf-16\"?>");

            Assert.IsTrue(lookLikeXml);
        }

        [TestMethod]
        public void DeStringify_DoesntReturnEmpty()
        {
            var shop = new Shop
            {
                Name = "XXX",
                ID = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                IsDeleted = false
            };

            var modelHelper = new XMLModelHelper();
            var input = modelHelper.Stringify(shop);
            var actual = modelHelper.DeStringify<Shop>(input);

            Assert.AreEqual(shop.ID, actual.ID);
        }
    }
}
