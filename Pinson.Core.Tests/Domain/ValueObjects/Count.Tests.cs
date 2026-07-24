using Pinson.Core.Domain.Exceptions;
using Pinson.Core.Domain.ValueObjects;

namespace Pinson.Core.Tests.Domain.ValueObjects
{
    [TestClass]
    public class CountTests
    {
        [TestMethod]
        public void Construct_ValueIsNegative_Throw()
        {
            Assert.ThrowsExactly<NegativeCountException>(() => new Count(-1));
        }

        [TestMethod]
        public void ToInt_ReturnValue()
        {
            int q = 1;
            var quantity = new Count(q);
            Assert.AreEqual(q, quantity.ToInt());
        }

        [TestMethod]
        public void Increment_ValueUp()
        {
            var count = new Count(1);
            count.Increment();
            Assert.AreEqual(2, count.Value);
        }

        [TestMethod]
        public void Decrement_NegativeValue_ShouldThrow()
        {
            var count = new Count(0);
            Assert.ThrowsExactly<NegativeCountException>(() => count.Decrement());
        }

        [TestMethod]
        public void Decrement_ValueDown()
        {
            var count = new Count(1);
            count.Decrement();
            Assert.AreEqual(0, count.Value);
        }
    }
}
