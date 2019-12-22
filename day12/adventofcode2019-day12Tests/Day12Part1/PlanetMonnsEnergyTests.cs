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
    public class PlanetMonnsEnergyTests
    {
        [TestMethod()]
        public void MoonsEnergy_Test_Move_10_Steps_Print()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>");

            planet.Move(10);
            planet.Energy.ShouldBe(179);
        }
    }
}