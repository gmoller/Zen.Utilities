using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zen.Utilities.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool HasValue(this string str)
        {
            var hasValue = !string.IsNullOrEmpty(str);

            return hasValue;
        }

        public static string GetTextToLeftOfCharacter(this string str, char c)
        {
            var index = str.IndexOf(c);
            var returnString = index > 0 ? str.Substring(0, index) : string.Empty;

            return returnString;
        }

        public static string GetTextToRightOfCharacter(this string str, char c)
        {
            var index = str.IndexOf(c);
            var returnString = index > 0 ? str.Substring(index + 1) : string.Empty;

            return returnString;
        }

        public static string GetTextBetweenIndexes(this string str, int index1, int index2, bool inclusive = false)
        {
            if (inclusive)
            {
                var returnString = str.Substring(index1, index2 - index1 + 1);

                return returnString;
            }
            else
            {
                // not inclusive
                var returnString = str.Substring(index1 + 1, index2 - index1 - 1);

                return returnString;
            }
        }

        public static string GetTextBetweenCharacters(this string str, char c, bool inclusive = false)
        {
            if (inclusive)
            {
                var index1 = str.IndexOf(c, 0);
                var index2 = str.IndexOf(c, index1 + 1);
                var returnString = str.GetTextBetweenIndexes(index1, index2, true);

                return returnString;
            }
            else
            {
                var index1 = str.IndexOf(c, 0);
                var index2 = str.IndexOf(c, index1 + 1);
                var returnString = str.GetTextBetweenIndexes(index1, index2);

                return returnString;
            }
        }

        public static string KeepOnlyAfterCharacter(this string str, char c)
        {
            var split = str.Split(c);
            var returnString = split.Length == 1 ? split[0] : split[1];

            return returnString;
        }

        public static string KeepOnlyBeforeCharacter(this string str, char c)
        {
            var split = str.Split(c);
            var returnString = split[0];

            return returnString;
        }

        public static string RemoveFirstAndLastCharacters(this string str)
        {
            var returnString = str.Substring(1, str.Length - 2);

            return returnString;
        }

        public static string RemoveLastCharacter(this string str)
        {
            if (str.Length == 0) return str;

            var returnString = str.Remove(str.Length - 1);

            return returnString;
        }

        public static bool StartsAndEndsWith(this string str, char start, char end)
        {
            if (str.StartsWith(start) && str.EndsWith(end))
            {
                return true;
            }

            return false;
        }

        public static bool StartsAndEndsWith(this string str, char c)
        {
            if (str.StartsWith(c) && str.EndsWith(c))
            {
                return true;
            }

            return false;
        }

        public static bool ContainsTwoCharactersOf(this string str, char c)
        {
            var count = str.Count(x => x == c);
            var result = count == 2;

            return result;
        }

        public static string GetFirstCharacters(this string str, int i)
        {
            var returnString = new string(str.Take(i).ToArray());

            return returnString;
        }

        public static IEnumerable<string> SplitToLines(this string input)
        {
            if (input == null)
            {
                yield break;
            }

            using var reader = new StringReader(input);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}