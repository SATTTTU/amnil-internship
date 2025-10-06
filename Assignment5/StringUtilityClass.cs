using System;
using System.Linq; 

namespace Assignment5
{
    public class StringUtilities
    {
        public static int CountWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            return input.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Count();
        }

        public static string ReverseString(string input)
        {
            if (input == null)
                return string.Empty;

            return new string(input.Reverse().ToArray());
        }

        public static bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            return input.SequenceEqual(input.Reverse());
        }

        public static string RemoveSpace(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
    }
}
