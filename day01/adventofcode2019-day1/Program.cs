using System;
using System.Linq;

namespace adventofcode2019_day1
{
    class Program
    {
        static void Main(string[] args)
        {

            var numericArgs = args.Select(a => Convert.ToInt32(a)).ToArray();
            var fuel = FuelCalculatorPart1.CounterUpper(numericArgs);

            Console.WriteLine($"Fuel: {fuel}");
        }
    }
}
