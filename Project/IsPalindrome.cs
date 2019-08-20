using System;
using System.Text.RegularExpressions;

namespace Project.IsPalindrome
{
    public static class IsPalindrome
    {
        public static bool Define(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            var regex = new Regex("[^a-zA-Zа-яА-Я]");
            var source = regex.Replace(str.ToLower(), string.Empty);
            if (string.IsNullOrEmpty(source)) return false;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != source[source.Length - i - 1])
                {
                    return false;
                }
                if (i + 1 >= source.Length - i - 1) break;
            }
            return true;
        }
    }
}