using adventofcode2019_day12.Day12Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day12
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleDay12Part2();
        }

        private static void PuzzleDay12Part2()
        {
            Console.WriteLine("Running PuzzleDay12Part2:");
            var planet = PlanetMovesToAPrevPositionCalculator.AddMoons(@"
<x=-3, y=10, z=-1>
<x=-12, y=-10, z=-5>
<x=-9, y=0, z=10>
<x=7, y=-5, z=-3>");

            var nbr = planet.NumberOfMovesToAPreviousPosition();
            Console.WriteLine($"=> {nbr}");

        }

        static void SlowTest()
        {
            Console.WriteLine("Running SlowTest:");
            var planet = PlanetMoveToInitialPositionCalculator.AddMoons(@"
<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>");

            var nbr = planet.NumberOfMovesToInitalPosition();
            Console.WriteLine($"=> {nbr}");
        }
    }
}
