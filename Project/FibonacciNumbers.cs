using System;
using System.Collections.Generic;

namespace Project
{
    public class FibonacciNumbers
    {
        Dictionary<int, int> Values = new Dictionary<int, int>();
        public int Compute(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (!Values.TryGetValue(n - 1, out int value1))
            {
                value1 = Compute(n - 1);
            }
            if (!Values.TryGetValue(n - 2, out int value2))
            {
                value2 = Compute(n - 2);
            }
            Values[n] = value1 + value2;
            return Values[n];
        }

        public double ComputeClosedFormExpression(int n)
        {
            var phi = (1 + Math.Sqrt(5)) / 2;
            var numerator = Math.Pow(phi, n) - Math.Pow(-1 * phi, -1 * n);
            var denominator = 2 * phi - 1;
            return numerator / denominator;
        }
    }
}