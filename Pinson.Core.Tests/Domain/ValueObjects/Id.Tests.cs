using Pinson.Core.Domain.Constants;
using Pinson.Core.Domain.Exceptions;
using Pinson.Core.Domain.ValueObjects;

namespace Pinson.Core.Tests.Domain.ValueObjects
{
    [TestClass]
    public class IdTests
    {

        [TestMethod]
        public void Construct_ValueLengthIsNotValid_ShouldThrow()
        {
            var key = new string('0', 31);
            Assert.ThrowsExactly<InvalidIdLengthException>(() => new Id(key));
        }

        [TestMethod]
        public void Construct_ValueIsEmpty_ShouldThrow()
        {
            Assert.ThrowsExactly<IsEmptyException>(() => new Id(string.Empty));
        }

        [TestMethod]
        public void ToString_ReturnValue()
        {
            var key = new string('0', Limits.ID_LENGTH);
            var id = new Id(key);
            Assert.AreEqual(key, id.ToString());
        }
    }
}
