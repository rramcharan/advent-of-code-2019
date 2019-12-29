using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace adventofcode2019_day12.Day12Part2.Tests
{
    [TestClass()]
    public class PuzzleDay12Part2
    {
        [TestMethod()]
        public void PuzzelDay12Part2()
        {
            var planet = PlanetMovesToAPrevPositionCalculator.AddMoons(@"
<x=-3, y=10, z=-1>
<x=-12, y=-10, z=-5>
<x=-9, y=0, z=10>
<x=7, y=-5, z=-3>");

            planet.NumberOfMovesToAPreviousPosition().ShouldBe(1);
        }

       
    }
}