using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day12.Day12Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace adventofcode2019_day12.Day12Part2.Tests
{
    [TestClass()]
    public class PlanetMoveToInitialPositionCalculatorTests
    {
        [TestMethod()]
        public void NumberOfMovesToInitalPosition_Test01()
        {
            var planet = PlanetMoveToInitialPositionCalculator.AddMoons(@"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>");

            planet.NumberOfMovesToInitalPosition().ShouldBe(2772);
        }

        [TestMethod()]
        public void NumberOfMovesToInitalPosition_Test01_Repeat_100Times()
        {
            for (var x = 0; x < 100; x++)
                NumberOfMovesToInitalPosition_Test01(); 
            // 511 ms
        }

        [TestMethod()]
        public void NumberOfMovesToAPreviousPosition_Test01()
        {
            var planet = PlanetMovesToAPrevPositionCalculator.AddMoons(@"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>");

            planet.NumberOfMovesToAPreviousPosition().ShouldBe(2772);
        }
    }
}