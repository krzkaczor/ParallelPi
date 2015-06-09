using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using BigNumbers;

namespace ParallelPi
{
    public class PiGenerator
    {
        private readonly IPiDigitsCalculator piDigitsCalculator;
        private const string PiString = "3.";

        public PiGenerator(IPiDigitsCalculator piDigitsCalculator)
        {
            this.piDigitsCalculator = piDigitsCalculator;
        }

        public string CalculateHexPi(int precision, int skipRate = 7)
        {
            //create range for linq call
            //1, (skipRate + 1), (skipRate * 2 + 1), ...
            var range = Enumerable.Range(0, (int) Math.Ceiling((double) precision/skipRate)).Select(x => x*skipRate + 1);

            var partsOfPi = range.AsParallel().AsOrdered().Select(n => piDigitsCalculator.CalculatePiDigits(n).Substring(0, skipRate));

            var piFraction = partsOfPi.AsSequential().Aggregate((a, next) => a + next).Substring(0, precision);

            return PiString + piFraction;
        }

        public string CalculateDecPi(int precision, int skipRate = 7)
        {
            var hexPi = this.CalculateHexPi(precision, skipRate);

            //converting "big" hex string with frational part to dec string is tricky
            //i use BigInteger class to convert numerator and denominator (i can't write it with fraction part) to dec
            //and than i divide it using BigNumber class that returns me fractional part

            var denominatorString = Enumerable.Range(0, precision).Select(x => "0").Aggregate("", (a, next) => a + next);
            var numeratorInteger = BigInteger.Parse(hexPi.Substring(2), NumberStyles.HexNumber);
            var denominatorInteger = BigInteger.Parse("1" + denominatorString, NumberStyles.HexNumber);

            var numeratorBigNumber = new BigNumber(numeratorInteger.ToString());
            var denominatorBigNumber = new BigNumber(denominatorInteger.ToString());

            var result = numeratorBigNumber / denominatorBigNumber;

            return PiString + result.ToFullString().Substring(2, precision);
        }
    }
}