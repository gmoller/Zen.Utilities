namespace Zen.Utilities.ExtensionMethods
{
    public static class ByteExtensions
    {
        public static bool IsBitSet(this byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        public static byte SetBit(this byte b, int bitNumber)
        {
            var returnByte = (byte)(b | (1 << bitNumber));

            return returnByte;
        }

        public static byte ResetBit(this byte b, int bitNumber)
        {
            var returnByte = (byte)(b & ~(1 << bitNumber));

            return returnByte;
        }

        public static bool IsEven(this byte i)
        {
            return i % 2 == 0;
        }

        public static bool IsOdd(this byte i)
        {
            return i % 2 != 0;
        }
    }
}