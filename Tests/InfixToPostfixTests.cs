using System;
using System.Collections.Generic;
using CourseraCourseComputerScienceAlgorithmsTheoryAndMachines.InfixToPostfix;
using NUnit.Framework;

namespace Tests
{
    public class InfixToPostfixTests
    {
        private static IEnumerable<(string source, string expected)> Source4TestInfixToPostfix()
        {
            yield return ("A+B", "AB+");
            yield return ("A+B*C", "ABC*+");
            yield return ("A+B*C+D", "ABC*+D+");
            yield return ("A*B+C*D", "AB*CD*+");
            yield return ("A+B+C+D", "AB+C+D+");

            yield return ("(A+B)*C", "AB+C*");
            yield return ("(A+B)*(C+D)", "AB+CD+*");
            yield return ("(A+B)*C-(D-E)*(F+G)", "AB+C*DE-FG+*-");
        }
        [TestCaseSource(nameof(Source4TestInfixToPostfix))]
        public void TestInfixToPostfix((string source, string expected) data)
        {
            var result = InfixToPostfix.Tranform(data.source);
            Assert.AreEqual(data.expected, result, $"Entrance data is {data.source}");
        }
    }
}