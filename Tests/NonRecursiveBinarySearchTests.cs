using NUnit.Framework;
using CourseraCourseComputerScienceAlgorithmsTheoryAndMachines.NonRecursiveBinarySearch;
using System.Collections.Generic;

namespace Tests
{
    public class NonRecursiveBinarySearchTests
    {
        private static IEnumerable<(int[] array, int value, bool found)> SourceTestSearch()
        {

            yield return (new int[] { }, 1, false);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 11, false);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, -1, false);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 2, false);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 8, false);

            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 1, true);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 3, true);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 4, true);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 5, true);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 6, true);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 7, true);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 9, true);
            yield return (new int[] { 1, 3, 4, 5, 6, 7, 9, 10 }, 10, true);
        }

        [TestCaseSource(nameof(SourceTestSearch))]
        public void TestSearch((int[] array, int value, bool found) data)
        {
            bool result = NonRecursiveBinarySearch.Search(data.array, data.value);
            Assert.AreEqual(result, data.found);
        }
    }
}