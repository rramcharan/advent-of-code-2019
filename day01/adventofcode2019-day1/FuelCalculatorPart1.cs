using System;
using System.Linq;

namespace adventofcode2019_day1
{
    public static class FuelCalculatorPart1
    {
        public static int CounterUpper(int mass)
        {
            return Convert.ToInt32(decimal.Floor(mass / 3M)) - 2;
        }
        public static int CounterUpper(params int[] masses)
        {
            if (masses == null) return 0;
            return masses.Sum(m => CounterUpper(m));
        }
    }
}
