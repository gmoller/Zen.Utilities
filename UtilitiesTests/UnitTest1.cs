using NUnit.Framework;
using Zen.Utilities;

namespace Zen.UtilitiesTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_CallContext()
        {
            CallContext<string>.SetData("GlobalContext", "Hi!");
            var context = CallContext<string>.GetData("GlobalContext");

            Assert.AreEqual("Hi!", context);
        }
    }
}