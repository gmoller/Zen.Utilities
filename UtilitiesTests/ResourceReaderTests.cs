using System.Reflection;
using NUnit.Framework;
using Zen.Utilities;

namespace Zen.UtilitiesTests
{
    public class ResourceReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Embedded_resource_from_assembly_can_be_read()
        {
            var text = ResourceReader.ReadResource("Zen.UtilitiesTests.TestFile.txt", Assembly.GetExecutingAssembly());

            Assert.AreEqual("Alex and Marty are the greatest Schnauzers that ever lived.", text);
        }
    }
}