using System;
using System.Collections.Generic;
using NUnit.Framework;
using Project;

namespace Tests
{
    public class FibonacciTests
    {
        FibonacciNumbers fNumbers;
        [SetUp]
        public void SetUp()
        {
            fNumbers = new FibonacciNumbers();
        }

        [TestCaseSource(nameof(Source4Test))]
        public void TestNumbers((int n, int expectedResult) data)
        {
            int result = fNumbers.Compute(data.n);
            Assert.AreEqual(data.expectedResult, result, $"Value n={data.n}");
        }

        [TestCaseSource(nameof(Source4TestClosedFormExpression))]
        public void TestNumbersClosedFormExpression((int n, double expectedResult) data)
        {
            var result = fNumbers.ComputeClosedFormExpression(data.n);
            Assert.AreEqual(data.expectedResult, result, 0.00001, $"Value n={data.n}");
        }

        private static IEnumerable<(int n, double expectedResult)> Source4TestClosedFormExpression()
        {
            yield return (0, 0);
            yield return (1, 1);
            yield return (6, 8);
            yield return (10, 55);
        }

        private static IEnumerable<(int n, int expectedResult)> Source4Test()
        {
            yield return (0, 0);
            yield return (1, 1);
            yield return (6, 8);
            yield return (10, 55);
        }
    }
}