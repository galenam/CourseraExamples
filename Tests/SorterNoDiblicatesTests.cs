using System.Collections.Generic;
using CourseraCourseComputerScienceAlgorithmsTheoryAndMachines.SortedNonDublicatesFilter;
using NUnit.Framework;
namespace Tests
{
    public class SorterNoDiblicatesTests
    {
        [TestCaseSource(nameof(Source4TestSorter))]
        public void TestSorter((string source, string sorderString) data)
        {
            var result = SorterNoDiblicates.Sort(data.source);
            Assert.AreEqual(data.sorderString, result, $"Source={data.source} Expected result = {data.sorderString}, but real result is {result}");
        }

        private static IEnumerable<(string source, string sorderString)> Source4TestSorter()
        {
            yield return ("dasd asdas wer dfsdf", "asdas dasd dfsdf wer");
            yield return ("", string.Empty);
            yield return (null, string.Empty);
            yield return ("first second third", "first second third");
            yield return ("third second first", "first second third");
            yield return ("first first first first", "first");

            yield return ("first second  second third", "first second third");
            yield return ("first first second third", "first second third");
            yield return ("first second third third", "first second third");

            yield return ("third third second first", "first second third");
            yield return ("third second second first", "first second third");
            yield return ("third second first first", "first second third");

            yield return ("VS Code supports word based completions for any programming language but can also be configured to have richer IntelliSense by installing a language extension",
            "a also any based be but by can Code completions configured extension for have installing IntelliSense language programming richer supports to VS word");
        }
    }
}