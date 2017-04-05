using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lith.DocStore.Tests
{
    [TestClass]
    public class KeyForgeTests
    {
        [TestMethod]
        public void CreateKey_ReturnsCorrect()
        {
            var keyHolder = new KeyForge("Shop", Guid.Parse("28C0812C-4723-404C-9B26-168FDFBD83C0"));
            var expected = "shop_28C0812C-4723-404C-9B26-168FDFBD83C0".ToLower();

            Assert.AreEqual(expected, keyHolder.Key);
        }

        [TestMethod]
        public void GetKeyPath_ReturnsCorrect()
        {
            var keyHolder = new KeyForge("Shop", Guid.Parse("28C0812C-4723-404C-9B26-168FDFBD83C0"));
            var expected = Environment.CurrentDirectory + @"\records\shop\28c0812c-4723-404c-9b26-168fdfbd83c0";
            var actual = keyHolder.GetKeyPath();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KeyExists_RecordDoesNOTExist()
        {
            var keyHolder = new KeyForge("fake", Guid.NewGuid());

            var actual = keyHolder.KeyExists();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void KeyExists_RecordDoesExist()
        {
            var keyHolder = new KeyForge("fake", Guid.NewGuid());

            keyHolder.SubmitKey("[DATA]");

            var actual = keyHolder.KeyExists();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void LoadKeyData_CanLoadData()
        {
            var id = Guid.NewGuid();
            var keyHolder = new KeyForge("fake", id);

            keyHolder.SubmitKey("[DATA]");

            var actual = keyHolder.LoadKeyData();

            Assert.AreEqual("[DATA]", actual);
        }
    }
}
