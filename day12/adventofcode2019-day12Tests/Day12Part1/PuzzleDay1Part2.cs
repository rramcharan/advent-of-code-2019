using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day12.Day12Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace adventofcode2019_day12.Day12Part1.Tests
{
    [TestClass()]
    public class MoonsPuzzleTests
    {
        [TestMethod()]
        public void PuzzelDay12Part1()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-3, y=10, z=-1>
<x=-12, y=-10, z=-5>
<x=-9, y=0, z=10>
<x=7, y=-5, z=-3>");

            planet.Move(1000);
            planet.Energy.ShouldBe(10944);
        }

        [TestMethod()]
        public void PuzzelDay12Part1_JustPrint()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-3, y=10, z=-1>
<x=-12, y=-10, z=-5>
<x=-9, y=0, z=10>
<x=7, y=-5, z=-3>");

            planet.Move(100);
            Console.WriteLine($"Energy after 100 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 200 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 300 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 400 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 500 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 600 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 700 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 800 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 900 steps: {planet.Energy}");

            planet.Move(100);
            Console.WriteLine($"Energy after 1000 steps: {planet.Energy}");
        }
    }
}