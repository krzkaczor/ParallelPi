using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelPi
{
    static class DoubleExtensions
    {
        private static readonly char[] CharList = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F'
        };

        public static string ToHexString(this double number, int fractionalDigits)
        {
            int radix = CharList.Length;
            StringBuilder sb = new StringBuilder();

            // The 'whole' part of the number.
            long whole = (long)Math.Floor(number);
            while (whole > 1)
            {
                sb.Insert(0, CharList[whole % radix]);
                whole = whole / radix;
            }

            // The fractional part of the number.
            var remainder = number % 1;
            if (!(remainder > Double.Epsilon) && !(remainder < -Double.Epsilon)) return sb.ToString();
            sb.Append('.');

            double nv;
            for (int i = 0; i < fractionalDigits; i++)
            {
                nv = remainder * radix;
                if (remainder < Double.Epsilon && remainder > -Double.Epsilon)
                    break;
                sb.Append(CharList[(int)Math.Floor(nv)]);
                remainder = nv % 1;
            }

            return sb.ToString();
        }
    }
}
