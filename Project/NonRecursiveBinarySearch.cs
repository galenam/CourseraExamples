using System;
using System.Linq;

namespace CourseraCourseComputerScienceAlgorithmsTheoryAndMachines.NonRecursiveBinarySearch
{
    public static class NonRecursiveBinarySearch
    {
        public static bool Search(int[] array, int value)
        {
            if (array == null || !array.Any()) { return false; }
            var begin = 0;
            var end = array.Length - 1;
            var middle = (end - begin) / 2;
            while (true)
            {
                if (array[begin] > value) return false;
                if (array[end] < value) return false;
                if (array[middle] == value) return true;
                if (array[middle] < value)
                {
                    begin = middle + 1;
                    middle = (end - begin) / 2 + begin;
                }
                else
                {
                    end = middle - 1;
                    middle = (end - begin) / 2 + begin;
                }
                if (begin > end) { return false; }
            }
        }
    }
}