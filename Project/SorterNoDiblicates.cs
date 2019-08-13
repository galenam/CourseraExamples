using System.Collections.Generic;
using System.Linq;

namespace CourseraCourseComputerScienceAlgorithmsTheoryAndMachines.SortedNonDublicatesFilter
{
    public static class SorterNoDiblicates
    {
        public static string Sort(string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;
            var ArrayToSort = source.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToList();
            if (ArrayToSort == null || !ArrayToSort.Any() || ArrayToSort.Count == 1)
            {
                return source;
            }
            SortInner(ArrayToSort, 0, ArrayToSort.Count - 1, true);
            return string.Join(" ", ArrayToSort);
        }

        private static void SortInner(IList<string> ArrayToSort, int indexBegin, int indexEnd, bool isFirst)
        {
            var dictionary = new Dictionary<string, bool>();
            var pivot = ArrayToSort[indexEnd];
            var i = indexBegin;
            var countOfWays = indexBegin;
            var indexPivot = indexEnd;
            if (isFirst)
            {
                dictionary.Add(pivot, true);
            }
            while (countOfWays++ < indexEnd)
            {
                if (string.Compare(ArrayToSort[i], pivot, true) >= 0)
                {
                    int indexInsert = indexEnd + 1;

                    var needCorrectIndexes = true;
                    if (!(dictionary.ContainsKey(ArrayToSort[i]) && isFirst))
                    {
                        needCorrectIndexes = false;
                        ArrayToSort.Insert(indexInsert, ArrayToSort[i]);
                        UpdateDictionary(dictionary, isFirst, ArrayToSort[i]);
                    }
                    ArrayToSort.RemoveAt(i);
                    indexPivot--;
                    if (needCorrectIndexes)
                    {
                        indexEnd--;
                        countOfWays--;
                    }
                    continue;
                }
                if (dictionary.ContainsKey(ArrayToSort[i]) && isFirst)
                {
                    ArrayToSort.RemoveAt(i);
                }
                else
                {
                    UpdateDictionary(dictionary, isFirst, ArrayToSort[i]);
                    i++;
                }
            }
            if (indexBegin < indexPivot - 1)
            {
                SortInner(ArrayToSort, indexBegin, indexPivot - 1, false);
            }
            if (indexPivot < indexEnd)
            {
                SortInner(ArrayToSort, indexPivot + 1, indexEnd, false);
            }
        }
        private static void UpdateDictionary(Dictionary<string, bool> dictionary, bool isFirst, string value)
        {
            if (!dictionary.ContainsKey(value) && isFirst)
            {
                dictionary.Add(value, true);
            }
        }
    }
}