using Maidenhead;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class MaidenheadConverterUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidInputPart1()
        {
            var _ = MaidenheadConverter.Convert("ZZ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidInputPart2()
        {
            var _ = MaidenheadConverter.Convert("JOZZ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidInputPart3()
        {
            var _ = MaidenheadConverter.Convert("JO89ZZ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUnpairedPart()
        {
            var _ = MaidenheadConverter.Convert("JO89U");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyLocator()
        {
            var _ = MaidenheadConverter.Convert(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullLocator()
        {
            var _ = MaidenheadConverter.Convert(null);
        }
    }
}
