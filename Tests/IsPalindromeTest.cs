using System.Collections.Generic;
using NUnit.Framework;
using Project.IsPalindrome;

namespace Tests
{
    public class IsPalindromeTest
    {
        private static IEnumerable<(string source, bool isPalindrome)> Source4TestIsPalindrome()
        {
            yield return ("aabbaa", true);
            yield return ("ab", false);
            yield return ("", false);
            yield return (string.Empty, false);
            yield return (null, false);

            yield return ("asdfgfdsa", true);
            yield return ("ывавлавщвлащв", false);
            yield return ("asdfgdsa", false);
            yield return (" ", false);
            yield return ("  ", false);
            yield return ("   ", false);
            yield return ("Аргентина манит негра.", true);
        }

        [TestCaseSource(nameof(Source4TestIsPalindrome))]
        public void TestIsPalindrome((string source, bool isPalindrome) data)
        {
            bool result = IsPalindrome.Define(data.source);
            Assert.AreEqual(data.isPalindrome, result, $"Entrance data is {data.source}");
        }

    }
}