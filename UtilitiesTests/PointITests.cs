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
        public void Point_creation_from_string()
        {
            var p1 = new PointI("5;5");
            var p2 = new PointI("10; 10");
            var p3 = new PointI(" 10;  10 ");
            var p4 = new PointI("[10;10]");
            var p5 = new PointI("[ 10; 10]");

            Assert.AreEqual(new PointI(5, 5), p1);
            Assert.AreEqual(new PointI(10, 10), p2);
            Assert.AreEqual(new PointI(10, 10), p3);
            Assert.AreEqual(new PointI(10, 10), p4);
            Assert.AreEqual(new PointI(10, 10), p5);
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