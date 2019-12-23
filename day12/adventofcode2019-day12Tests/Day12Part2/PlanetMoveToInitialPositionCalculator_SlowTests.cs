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
    public class PlanetMoveToInitialPositionCalculator_SlowTests
    {
 
        [TestMethod()]
        public void NumberOfMovesToInitalPosition_Slow_Test02()
        {
            var planet = PlanetMoveToInitialPositionCalculator.AddMoons(@"
<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>");

            planet.NumberOfMovesToInitalPosition().ShouldBe(4686774924);
        }
    }
}