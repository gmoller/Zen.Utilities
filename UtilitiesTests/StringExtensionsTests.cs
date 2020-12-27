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
            var result = test.GetFirstCharacters(5);

            Assert.AreEqual("", result);

            test = "Hello there!";
            result = test.GetFirstCharacters(5);

            Assert.AreEqual("Hello", result);

            test = "Hello there!";
            result = test.GetFirstCharacters(20);

            Assert.AreEqual("Hello there!", result);
        }

        [Test]
        public void Test_RemoveLastCharacter()
        {
            var test = "";
            var result = test.RemoveLastCharacter();

            Assert.AreEqual("", result);

            test = "Hello there!";
            result = test.RemoveLastCharacter();

            Assert.AreEqual("Hello there", result);

            result = result.RemoveLastCharacter();

            Assert.AreEqual("Hello ther", result);
        }

        [Test]
        public void Test_GetTextBetweenIndexes_Inclusive()
        {
            var test = "Hey there!";
            var result = test.GetTextBetweenIndexes(0, 9, true);

            Assert.AreEqual("Hey there!", result);

            result = test.GetTextBetweenIndexes(0, 2, true);

            Assert.AreEqual("Hey", result);

            result = test.GetTextBetweenIndexes(4, 8, true);

            Assert.AreEqual("there", result);
        }

        [Test]
        public void Test_GetTextBetweenIndexes_Exclusive()
        {
            var test = "Hey there!";
            var result = test.GetTextBetweenIndexes(0, 9);

            Assert.AreEqual("ey there", result);

            result = test.GetTextBetweenIndexes(0, 2);

            Assert.AreEqual("e", result);

            result = test.GetTextBetweenIndexes(4, 8);

            Assert.AreEqual("her", result);
        }

        [Test]
        public void Test_GetTextBetweenCharacters_Inclusive()
        {
            var test = "%Hey there! %";
            var result = test.GetTextBetweenCharacters('%', true);

            Assert.AreEqual("%Hey there! %", result);

            result = test.GetTextBetweenCharacters(' ', true);

            Assert.AreEqual(" there! ", result);

            result = test.GetTextBetweenCharacters('e', true);

            Assert.AreEqual("ey the", result);
        }

        [Test]
        public void Test_GetTextBetweenCharacters_Exclusive()
        {
            var test = "%Hey there! %";
            var result = test.GetTextBetweenCharacters('%');

            Assert.AreEqual("Hey there! ", result);

            result = test.GetTextBetweenCharacters(' ');

            Assert.AreEqual("there!", result);

            result = test.GetTextBetweenCharacters('e');

            Assert.AreEqual("y th", result);
        }

        [Test]
        public void Test_ContainsTwoOf()
        {
            var test = "%Hey there! %";
            var result = test.ContainsTwoCharactersOf('%');

            Assert.IsTrue(result);

            result = test.ContainsTwoCharactersOf('e');

            Assert.IsFalse(result);

            result = test.ContainsTwoCharactersOf('r');

            Assert.IsFalse(result);

            result = test.ContainsTwoCharactersOf('Z');

            Assert.IsFalse(result);
        }
    }
}