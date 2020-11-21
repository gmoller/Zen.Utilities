using NUnit.Framework;
using Zen.Utilities;
using Zen.Utilities.ExtensionMethods;

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

        [Test]
        public void StartsAndEndsWith_functions_correctly()
        {
            var testString1 = "[Hello]";
            var result1 = testString1.StartsAndEndsWith('[', ']');
            Assert.IsTrue(result1);

            var testString2 = "Hello";
            var result2 = testString2.StartsAndEndsWith('[', ']');
            Assert.IsFalse(result2);

            var testString3 = "[Hello";
            var result3 = testString3.StartsAndEndsWith('[', ']');
            Assert.IsFalse(result3);

            var testString4 = "Hello]";
            var result4 = testString4.StartsAndEndsWith('[', ']');
            Assert.IsFalse(result4);

            var testString5 = "'Hello'";
            var result5 = testString5.StartsAndEndsWith('\'');
            Assert.IsTrue(result5);

            var testString6 = "'Hello";
            var result6 = testString6.StartsAndEndsWith('\'');
            Assert.IsFalse(result6);

            var testString7 = "Hello'";
            var result7 = testString7.StartsAndEndsWith('\'');
            Assert.IsFalse(result7);
        }

        [Test]
        public void KeepOnlyBeforeCharacter_functions_correctly()
        {
            var testString1 = "[Hello]";
            var result1 = testString1.KeepOnlyBeforeCharacter(']');
            Assert.AreEqual("[Hello", result1);

            var testString2 = "Hello]";
            var result2 = testString2.KeepOnlyBeforeCharacter(']');
            Assert.AreEqual("Hello", result2);

            var testString3 = "Hello";
            var result3 = testString3.KeepOnlyBeforeCharacter(']');
            Assert.AreEqual("Hello", result3);

            var testString4 = "Hello]123]";
            var result4 = testString4.KeepOnlyBeforeCharacter(']');
            Assert.AreEqual("Hello", result4);
        }
    }
}