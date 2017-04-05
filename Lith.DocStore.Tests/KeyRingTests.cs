using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
