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
    public class PlanetTests
    {
        [TestMethod()]
        public void AddMoons_Test_Read_And_Print()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>");

            planet.NumberOfMoons.ShouldBe(4);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-1, y=0, z=2>, vel=<x=0, y=0, z=0>
pos=<x=2, y=-10, z=-7>, vel=<x=0, y=0, z=0>
pos=<x=4, y=-8, z=8>, vel=<x=0, y=0, z=0>
pos=<x=3, y=5, z=-1>, vel=<x=0, y=0, z=0>");
        }

        [TestMethod()]
        public void AddMoons_Test_Move_1_Step_Print()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>");

            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=2, y=-1, z=1>, vel=<x=3, y=-1, z=-1>
pos=<x=3, y=-7, z=-4>, vel=<x=1, y=3, z=3>
pos=<x=1, y=-7, z=5>, vel=<x=-3, y=1, z=-3>
pos=<x=2, y=2, z=0>, vel=<x=-1, y=-3, z=1>");
        }

        [TestMethod()]
        public void AddMoons_Test_Move_10_Steps_StepByStep_Print()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>");

            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=2, y=-1, z=1>, vel=<x=3, y=-1, z=-1>
pos=<x=3, y=-7, z=-4>, vel=<x=1, y=3, z=3>
pos=<x=1, y=-7, z=5>, vel=<x=-3, y=1, z=-3>
pos=<x=2, y=2, z=0>, vel=<x=-1, y=-3, z=1>");

            // After 2 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=5, y=-3, z=-1>, vel=<x=3, y=-2, z=-2>
pos=<x=1, y=-2, z=2>, vel=<x=-2, y=5, z=6>
pos=<x=1, y=-4, z=-1>, vel=<x=0, y=3, z=-6>
pos=<x=1, y=-4, z=2>, vel=<x=-1, y=-6, z=2>");

            // After 3 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=5, y=-6, z=-1>, vel=<x=0, y=-3, z=0>
pos=<x=0, y=0, z=6>, vel=<x=-1, y=2, z=4>
pos=<x=2, y=1, z=-5>, vel=<x=1, y=5, z=-4>
pos=<x=1, y=-8, z=2>, vel=<x=0, y=-4, z=0>");

            // After 4 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=2, y=-8, z=0>, vel=<x=-3, y=-2, z=1>
pos=<x=2, y=1, z=7>, vel=<x=2, y=1, z=1>
pos=<x=2, y=3, z=-6>, vel=<x=0, y=2, z=-1>
pos=<x=2, y=-9, z=1>, vel=<x=1, y=-1, z=-1>");

            // After 5 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-1, y=-9, z=2>, vel=<x=-3, y=-1, z=2>
pos=<x=4, y=1, z=5>, vel=<x=2, y=0, z=-2>
pos=<x=2, y=2, z=-4>, vel=<x=0, y=-1, z=2>
pos=<x=3, y=-7, z=-1>, vel=<x=1, y=2, z=-2>");

            // After 6 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-1, y=-7, z=3>, vel=<x=0, y=2, z=1>
pos=<x=3, y=0, z=0>, vel=<x=-1, y=-1, z=-5>
pos=<x=3, y=-2, z=1>, vel=<x=1, y=-4, z=5>
pos=<x=3, y=-4, z=-2>, vel=<x=0, y=3, z=-1>");

            // After 7 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=2, y=-2, z=1>, vel=<x=3, y=5, z=-2>
pos=<x=1, y=-4, z=-4>, vel=<x=-2, y=-4, z=-4>
pos=<x=3, y=-7, z=5>, vel=<x=0, y=-5, z=4>
pos=<x=2, y=0, z=0>, vel=<x=-1, y=4, z=2>");

            // After 8 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=5, y=2, z=-2>, vel=<x=3, y=4, z=-3>
pos=<x=2, y=-7, z=-5>, vel=<x=1, y=-3, z=-1>
pos=<x=0, y=-9, z=6>, vel=<x=-3, y=-2, z=1>
pos=<x=1, y=1, z=3>, vel=<x=-1, y=1, z=3>");

            // After 9 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=5, y=3, z=-4>, vel=<x=0, y=1, z=-2>
pos=<x=2, y=-9, z=-3>, vel=<x=0, y=-2, z=2>
pos=<x=0, y=-8, z=4>, vel=<x=0, y=1, z=-2>
pos=<x=1, y=1, z=5>, vel=<x=0, y=0, z=2>");

            // After 10 steps:
            planet.Move(1);
            planet.ShowMoon().ShouldBe(@"
pos=<x=2, y=1, z=-3>, vel=<x=-3, y=-2, z=1>
pos=<x=1, y=-8, z=0>, vel=<x=-1, y=1, z=3>
pos=<x=3, y=-6, z=1>, vel=<x=3, y=2, z=-3>
pos=<x=2, y=0, z=4>, vel=<x=1, y=-1, z=-1>");
        }

        [TestMethod()]
        public void AddMoons_Test_Move_10_Steps_Print()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>");

            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=2, y=1, z=-3>, vel=<x=-3, y=-2, z=1>
pos=<x=1, y=-8, z=0>, vel=<x=-1, y=1, z=3>
pos=<x=3, y=-6, z=1>, vel=<x=3, y=2, z=-3>
pos=<x=2, y=0, z=4>, vel=<x=1, y=-1, z=-1>");
        }

        #region 2nd example
        [TestMethod()]
        public void MoveMoons_2ndTest_Move_10_Steps_Print()
        {
            var planet = new Planet();
            planet.AddMoons(@"
<x=-8, y=-10, z=0>
<x=5, y=5, z=10>
<x=2, y=-7, z=3>
<x=9, y=-8, z=-3>");

            // After 0 steps:
            planet.ShowMoon().ShouldBe(@"
pos=<x=-8, y=-10, z=0>, vel=<x=0, y=0, z=0>
pos=<x=5, y=5, z=10>, vel=<x=0, y=0, z=0>
pos=<x=2, y=-7, z=3>, vel=<x=0, y=0, z=0>
pos=<x=9, y=-8, z=-3>, vel=<x=0, y=0, z=0>");

            // After 10 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-9, y=-10, z=1>, vel=<x=-2, y=-2, z=-1>
pos=<x=4, y=10, z=9>, vel=<x=-3, y=7, z=-2>
pos=<x=8, y=-10, z=-3>, vel=<x=5, y=-1, z=-2>
pos=<x=5, y=-10, z=3>, vel=<x=0, y=-4, z=5>");

            // After 20 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-10, y=3, z=-4>, vel=<x=-5, y=2, z=0>
pos=<x=5, y=-25, z=6>, vel=<x=1, y=1, z=-4>
pos=<x=13, y=1, z=1>, vel=<x=5, y=-2, z=2>
pos=<x=0, y=1, z=7>, vel=<x=-1, y=-1, z=2>");

            // After 30 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=15, y=-6, z=-9>, vel=<x=-5, y=4, z=0>
pos=<x=-4, y=-11, z=3>, vel=<x=-3, y=-10, z=0>
pos=<x=0, y=-1, z=11>, vel=<x=7, y=4, z=3>
pos=<x=-3, y=-2, z=5>, vel=<x=1, y=2, z=-3>");

            // After 40 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=14, y=-12, z=-4>, vel=<x=11, y=3, z=0>
pos=<x=-1, y=18, z=8>, vel=<x=-5, y=2, z=3>
pos=<x=-5, y=-14, z=8>, vel=<x=1, y=-2, z=0>
pos=<x=0, y=-12, z=-2>, vel=<x=-7, y=-3, z=-3>");

            // After 50 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-23, y=4, z=1>, vel=<x=-7, y=-1, z=2>
pos=<x=20, y=-31, z=13>, vel=<x=5, y=3, z=4>
pos=<x=-4, y=6, z=1>, vel=<x=-1, y=1, z=-3>
pos=<x=15, y=1, z=-5>, vel=<x=3, y=-3, z=-3>");

            // After 60 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=36, y=-10, z=6>, vel=<x=5, y=0, z=3>
pos=<x=-18, y=10, z=9>, vel=<x=-3, y=-7, z=5>
pos=<x=8, y=-12, z=-3>, vel=<x=-2, y=1, z=-7>
pos=<x=-18, y=-8, z=-2>, vel=<x=0, y=6, z=-1>");

            // After 70 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-33, y=-6, z=5>, vel=<x=-5, y=-4, z=7>
pos=<x=13, y=-9, z=2>, vel=<x=-2, y=11, z=3>
pos=<x=11, y=-8, z=2>, vel=<x=8, y=-6, z=-7>
pos=<x=17, y=3, z=1>, vel=<x=-1, y=-1, z=-3>");

            // After 80 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=30, y=-8, z=3>, vel=<x=3, y=3, z=0>
pos=<x=-2, y=-4, z=0>, vel=<x=4, y=-13, z=2>
pos=<x=-18, y=-7, z=15>, vel=<x=-8, y=2, z=-2>
pos=<x=-2, y=-1, z=-8>, vel=<x=1, y=8, z=0>");

            // After 90 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=-25, y=-1, z=4>, vel=<x=1, y=-3, z=4>
pos=<x=2, y=-9, z=0>, vel=<x=-3, y=13, z=-1>
pos=<x=32, y=-8, z=14>, vel=<x=5, y=-4, z=6>
pos=<x=-1, y=-2, z=-8>, vel=<x=-3, y=-6, z=-9>");

            // After 100 steps:
            planet.Move(10);
            planet.ShowMoon().ShouldBe(@"
pos=<x=8, y=-12, z=-9>, vel=<x=-7, y=3, z=0>
pos=<x=13, y=16, z=-3>, vel=<x=3, y=-11, z=-5>
pos=<x=-29, y=-11, z=-1>, vel=<x=-3, y=7, z=4>
pos=<x=16, y=-13, z=23>, vel=<x=7, y=1, z=1>");

            planet.Energy.ShouldBe(1940);
        }

        #endregion
    }
}