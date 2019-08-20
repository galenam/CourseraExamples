using System;

namespace Project.IsPalindrome
{
    public static class IsPalindrome
    {
        public static bool Define(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            var source = str.ToLower().Replace(" ", string.Empty);
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