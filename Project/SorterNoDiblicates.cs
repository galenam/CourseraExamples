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
            var dictionary = new Dictionary<string, bool>();
            SortInner(ArrayToSort, 0, ArrayToSort.Count - 1, dictionary, true);
            return string.Join(" ", ArrayToSort);
        }

        private static void SortInner(IList<string> ArrayToSort, int indexBegin, int indexEnd, Dictionary<string, bool> dictionary,
        bool isFirst)
        {
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
                    if (!dictionary.ContainsKey(ArrayToSort[i]) || !isFirst)
                    {
                        needCorrectIndexes = false;
                        ArrayToSort.Insert(indexInsert, ArrayToSort[i]);
                        if (!dictionary.ContainsKey(ArrayToSort[i]))
                        {
                            dictionary.Add(ArrayToSort[i], true);
                        }
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
                    if (!dictionary.ContainsKey(ArrayToSort[i]))
                    {
                        dictionary.Add(ArrayToSort[i], true);
                    }
                    i++;
                }
            }
            if (indexBegin < indexPivot - 1)
            {
                SortInner(ArrayToSort, indexBegin, indexPivot - 1, dictionary, false);
            }
            if (indexPivot < indexEnd)
            {
                SortInner(ArrayToSort, indexPivot + 1, indexEnd, dictionary, false);
            }
        }
    }
}