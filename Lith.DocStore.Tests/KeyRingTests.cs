using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lith.DocStore.Tests
{
    [TestClass]
    public class KeyRingTests
    {
        [TestMethod]
        public void Keys_IsntEmpty()
        {
            using (var ring = new KeyRing())
            {
                Assert.IsTrue(ring.Keys.Any());
            }
        }
    }
}
