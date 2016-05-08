using NUnit.Framework;

namespace DataStructures
{
    [TestFixture]
    public class BitVectorTests
    {
        [Test]
        public void Tests()
        {
            var bv = new BitVector();

            bv.Add(8);
            bv.Add(9);

            Assert.IsTrue(bv.IsSet(8));
            Assert.IsFalse(bv.IsSet(0));
            Assert.IsFalse(bv.IsSet(1));
            Assert.IsFalse(bv.IsSet(9));
            Assert.IsFalse(bv.IsSet(7));
            Assert.IsFalse(bv.IsSet(23));
            Assert.IsFalse(bv.IsSet(int.MaxValue));
        }
    }
}
