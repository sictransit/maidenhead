using Maidenhead;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class MaidenheadConverterUnitTests
    {
        [TestMethod]
        public void TestValidInputPart1()
        {
            Assert.IsTrue(MaidenheadConverter.IsValid("JO"));
        }

        [TestMethod]
        public void TestValidInputPart2()
        {
            Assert.IsTrue(MaidenheadConverter.IsValid("JO89"));
        }

        [TestMethod]
        public void TestValidInputPart3()
        {
            Assert.IsTrue(MaidenheadConverter.IsValid("JO89UT"));
        }

        [TestMethod]
        public void TestInvalidInputPart1()
        {
            Assert.IsFalse(MaidenheadConverter.IsValid("ZZ"));
        }

        [TestMethod]
        public void TestInvalidInputPart2()
        {
            Assert.IsFalse(MaidenheadConverter.IsValid("JOZZ"));
        }

        [TestMethod]
        public void TestInvalidInputPart3()
        {
            Assert.IsFalse(MaidenheadConverter.IsValid("JO89ZZ"));
        }

        [TestMethod]
        public void TestUnpairedPart()
        {
            Assert.IsFalse(MaidenheadConverter.IsValid("JO89U"));
        }

        [TestMethod]
        public void TestEmptyLocator()
        {
            Assert.IsFalse(MaidenheadConverter.IsValid(string.Empty));
        }

        [TestMethod]
        public void TestNullLocator()
        {
            Assert.IsFalse(MaidenheadConverter.IsValid(null));
        }
    }
}
