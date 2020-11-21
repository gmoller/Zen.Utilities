using NUnit.Framework;
using Zen.Utilities;

namespace Zen.UtilitiesTests
{
    public class PointITests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Points_can_be_lerped()
        {
            var start = new PointI(10, 10);
            var end = new PointI(20, 20);

            var p1 = PointI.Lerp(start, end, 0.0f);
            var p2 = PointI.Lerp(start, end, 0.5f);
            var p3 = PointI.Lerp(start, end, 1.0f);

            Assert.AreEqual(new PointI(10, 10), p1);
            Assert.AreEqual(new PointI(15, 15), p2);
            Assert.AreEqual(new PointI(20, 20), p3);
        }
    }
}