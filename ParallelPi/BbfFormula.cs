using System;

namespace ParallelPi
{
    public class BbfFormula : IPiDigitsCalculator
    {
        private double BbpFormula(int j, int n)
        {
            double s = 0;
            int k = 0;
            int r = 0;

            while (k <= n)
            {
                r = 8 * k + j;
                s = (s + (FastModularExponentiation(16, n - k, r) / r)) % 1.0;
                k++;
            }

            double t = 0;
            k = n + 1;
            while (true)
            {
                var newt = t + Math.Pow(16, n - k) / (8 * k + j);

                if (t == newt)
                    break;
                else
                    t = newt;
                k++;
            }

            return s + t;
        }

        private double FastModularExponentiation(int a, int b, int n)
        {
            a = a % n;
            var result = 1;
            var x = a;

            while (b > 0)
            {
                int leastSignificantBit = b % 2;
                b = b / 2;

                if (leastSignificantBit == 1)
                {
                    result = result * x;
                    result = result % n;
                }

                x = x * x;
                x = x % n;
            }
            return result;
        }

        public String CalculatePiDigits(int n)
        {
            n--;
            double x = (4 * BbpFormula(1, n) - 2 * BbpFormula(4, n) - BbpFormula(5, n) - BbpFormula(6, n)) % 1.0;
            double res = (x >= 0 ? x : x + 1);
            return res.ToHexString(8).Substring(1);
        }

    }
}
