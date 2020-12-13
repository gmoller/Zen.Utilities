using NUnit.Framework;
using Zen.Utilities.ExtensionMethods;

namespace Zen.UtilitiesTests
{
    public class StringExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_GetFirstCharacters()
        {
            var test = "";
            var test2 = test.GetFirstCharacters(5);

            Assert.AreEqual("", test2);

            test = "Hello there!";
            test2 = test.GetFirstCharacters(5);

            Assert.AreEqual("Hello", test2);

            test = "Hello there!";
            test2 = test.GetFirstCharacters(20);

            Assert.AreEqual("Hello there!", test2);
        }
    }
}