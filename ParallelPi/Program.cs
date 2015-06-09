using System;
using System.Diagnostics;

namespace ParallelPi
{
    class Program
    {
        static void Main(string[] args)
        {
            var piCalculator = new PiGenerator(new BbfFormula());
            int precision = 10000;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var pi = piCalculator.CalculateDecPi(precision);
            sw.Stop();
            Console.WriteLine($"PI = {pi}");

            Console.WriteLine($"Precision: {precision}");
            Console.WriteLine($"Calculation took: {sw.ElapsedMilliseconds} milliseconds.");
            
            Console.ReadKey();
        }
    }
}   