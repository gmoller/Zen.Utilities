namespace Zen.Utilities.ExtensionMethods
{
    public static class IntegerExtensions
    {
        public static bool IsBitSet(this int i, int bitNumber)
        {
            return (i & (1 << bitNumber)) != 0;
        }

        public static int SetBit(this int i, int bitNumber)
        {
            i |= 1 << bitNumber;

            return i;
        }

        public static int UnsetBit(this int i, int bitNumber)
        {
            i &= byte.MaxValue ^ (1 << bitNumber);

            return i;
        }

        public static int ToggleBit(this int i, int bitNumber)
        {
            var returnByte = i ^ (1 << bitNumber);

            return returnByte;
        }

        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        public static bool IsOdd(this int i)
        {
            return i % 2 != 0;
        }
    }
}