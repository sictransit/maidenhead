using Maidenhead;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ExtensionsUnitTests
    {
        [TestMethod]
        public void TestJO89UT56XU42()
        {
            var coordinate = MaidenheadConverter.Convert("JO89UT56XU42");

            Assert.IsNotNull(coordinate);

            Assert.AreEqual("N 59° 49.210 E 017° 42.988", coordinate.PrettyPrint());
        }
    }
}
