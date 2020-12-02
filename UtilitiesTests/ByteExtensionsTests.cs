using NUnit.Framework;
using Zen.Utilities.ExtensionMethods;

namespace Zen.UtilitiesTests
{
    public class ByteExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_IsBitSet()
        {
            byte test = 0;
            var setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 1;
            setBits = GetSetBits(test);

            Assert.AreEqual(true, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 2;
            setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(true, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 3;
            setBits = GetSetBits(test);

            Assert.AreEqual(true, setBits[0]);
            Assert.AreEqual(true, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 4;
            setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(true, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 8;
            setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(true, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 16;
            setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(true, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 32;
            setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(true, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 64;
            setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(true, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 128;
            setBits = GetSetBits(test);

            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(true, setBits[7]);


            test = 255;
            setBits = GetSetBits(test);

            Assert.AreEqual(true, setBits[0]);
            Assert.AreEqual(true, setBits[1]);
            Assert.AreEqual(true, setBits[2]);
            Assert.AreEqual(true, setBits[3]);
            Assert.AreEqual(true, setBits[4]);
            Assert.AreEqual(true, setBits[5]);
            Assert.AreEqual(true, setBits[6]);
            Assert.AreEqual(true, setBits[7]);
        }

        [Test]
        public void Test_SetBit()
        {
            byte test = 0;
            test = test.SetBit(0);
            var setBits = GetSetBits(test);

            Assert.AreEqual(1, test);
            Assert.AreEqual(true, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 0;
            test = test.SetBit(1);
            setBits = GetSetBits(test);

            Assert.AreEqual(2, test);
            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(true, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 0;
            test = test.SetBit(7);
            setBits = GetSetBits(test);

            Assert.AreEqual(128, test);
            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(true, setBits[7]);
        }

        [Test]
        public void Test_ResetBit()
        {
            byte test = 1;
            test = test.ResetBit(0);
            var setBits = GetSetBits(test);

            Assert.AreEqual(0, test);
            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);


            test = 3;
            test = test.ResetBit(0);
            test = test.ResetBit(1);
            setBits = GetSetBits(test);

            Assert.AreEqual(0, test);
            Assert.AreEqual(false, setBits[0]);
            Assert.AreEqual(false, setBits[1]);
            Assert.AreEqual(false, setBits[2]);
            Assert.AreEqual(false, setBits[3]);
            Assert.AreEqual(false, setBits[4]);
            Assert.AreEqual(false, setBits[5]);
            Assert.AreEqual(false, setBits[6]);
            Assert.AreEqual(false, setBits[7]);
        }

        [Test]
        public void Test_IsEven()
        {
            byte test = 0;
            var isEven = test.IsEven();

            Assert.AreEqual(true, isEven);


            test = 1;
            isEven = test.IsEven();

            Assert.AreEqual(false, isEven);


            test = 2;
            isEven = test.IsEven();

            Assert.AreEqual(true, isEven);
        }

        [Test]
        public void Test_IsOdd()
        {
            byte test = 0;
            var isEven = test.IsOdd();

            Assert.AreEqual(false, isEven);


            test = 1;
            isEven = test.IsOdd();

            Assert.AreEqual(true, isEven);


            test = 2;
            isEven = test.IsOdd();

            Assert.AreEqual(false, isEven);
        }

        private bool[] GetSetBits(byte test)
        {
            var setBits = new bool[8];

            for (var i = 0; i < setBits.Length; i++)
            {
                var isBitSet = test.IsBitSet(i);
                setBits[i] = isBitSet;
            }

            return setBits;
        }
    }
}