using Pinson.Core.Domain.Exceptions;
using Pinson.Core.Domain.ValueObjects;

namespace Pinson.Core.Tests.Domain.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private const int TEST_NAME_LENGTH = 32;

        [TestMethod]
        public void Construct_EmptyValue_Throw()
        {
            Assert.ThrowsExactly<IsEmptyException>(() => BuildTestName(string.Empty));
        }

        [TestMethod]
        public void Construct_ValueTooLong_Throw()
        {
            string name = new string('a', TEST_NAME_LENGTH + 1);
            Assert.ThrowsExactly<TooLongException>(() => BuildTestName(name));
        }

        [TestMethod]
        public void Construct_NoTrimValue_ShouldTrim()
        {
            string val = " Ethan     ";
            var name = BuildTestName(val);
            Assert.AreEqual(val.Trim(), name.Value);
        }

        [TestMethod]
        public void ToString_ReturnValue()
        {
            string val = new string('e', TEST_NAME_LENGTH);
            var name = BuildTestName(val);
            Assert.AreEqual(val, name.ToString());
        }

        [TestMethod]
        public void Equal_ValuesAreSame_ReturnTrue()
        {
            var val = "Ethan";
            var name = BuildTestName(val);
            var otherName = BuildTestName(val);
            Assert.IsTrue(name.Equals(otherName));
        }

        private Name BuildTestName(string value)
        {
            return new Name(value, TEST_NAME_LENGTH);
        }
    }
}
