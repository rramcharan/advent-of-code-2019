using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day10.Day10Part2;
using Shouldly;
using System;

namespace adventofcode2019_day10Tests.Day10Part2.Part1
{
    [TestClass()]
    public class AngleTests
    {
        [TestMethod()]
        public void AngleTests_Test01()
        {
            Angle.CalculateInDegrees(0, 0, 3, 0).ShouldBe(0M);
            Angle.CalculateInDegrees(0, 0, -3, 0).ShouldBe(180M);
            Angle.CalculateInDegrees(0, 0, 0, 5).ShouldBe(90M);
            Angle.CalculateInDegrees(0, 0, 5, -5).ShouldBe(315M);
            Angle.CalculateInDegrees(0, 0, 0, -5).ShouldBe(270M);
            Angle.CalculateInDegrees(0, 0, 3, 3).ShouldBe(45M);
            Angle.CalculateInDegrees(0, 0, 2, 3).ShouldBe(56.3099324740202M);

            Angle.CalculateInDegrees(-40, 0, 3, 0).ShouldBe(0M);
            Angle.CalculateInDegrees(-2, 0, -3, 0).ShouldBe(180M);
            Angle.CalculateInDegrees(0, -10, 0, 5).ShouldBe(90M);
            Angle.CalculateInDegrees(0, -2, 0, -5).ShouldBe(270M);
            Angle.CalculateInDegrees(-50, -50, -3, -3).ShouldBe(45M);
            Angle.Test();
        }

        [TestMethod()]
        public void AngleTests_Test02()
        {
            Angle.CalculateInDegreesClockWise(0, 0, 3, 0).ShouldBe(0M);
            Angle.CalculateInDegreesClockWise(0, 0, -3, 0).ShouldBe(180M);
            Angle.CalculateInDegreesClockWise(0, 0, 0, 5).ShouldBe(270M);
            Angle.CalculateInDegreesClockWise(0, 0, 0, -5).ShouldBe(90M);
            Angle.CalculateInDegreesClockWise(0, 0, 3, 3).ShouldBe(315M);
            Angle.CalculateInDegreesClockWise(0, 0, 2, 3).ShouldBe(303.69006752598M);

            Angle.CalculateInDegreesClockWise(-40, 0, 3, 0).ShouldBe(0M);
            Angle.CalculateInDegreesClockWise(-2, 0, -3, 0).ShouldBe(180M);
            Angle.CalculateInDegreesClockWise(0, -10, 0, 5).ShouldBe(270M);
            Angle.CalculateInDegreesClockWise(0, -2, 0, -5).ShouldBe(90M);
            Angle.CalculateInDegreesClockWise(-50, -50, -3, -3).ShouldBe(315M);
            Angle.Test();
        }

        [TestMethod()]
        public void AngleTests_Test03()
        {
            Angle.CalculateInDegreesClockWiseTopIs0(0, 0, 3, 0).ShouldBe(90M);
            Angle.CalculateInDegreesClockWiseTopIs0(0, 0, -3, 0).ShouldBe(270M);
            Angle.CalculateInDegreesClockWiseTopIs0(0, 0, 0, 5).ShouldBe(0M);
            Angle.CalculateInDegreesClockWiseTopIs0(0, 0, 0, -5).ShouldBe(180M);
            Angle.CalculateInDegreesClockWiseTopIs0(0, 0, 3, 3).ShouldBe(45M);
            Angle.CalculateInDegreesClockWiseTopIs0(0, 0, 2, 3).ShouldBe(33.6900675259798M);

            Angle.CalculateInDegreesClockWiseTopIs0(-40, 0, 3, 0).ShouldBe(90M);
            Angle.CalculateInDegreesClockWiseTopIs0(-2, 0, -3, 0).ShouldBe(270M);
            Angle.CalculateInDegreesClockWiseTopIs0(0, -10, 0, 5).ShouldBe(0M);
            Angle.CalculateInDegreesClockWiseTopIs0(0, -2, 0, -5).ShouldBe(180M);
            Angle.CalculateInDegreesClockWiseTopIs0(-50, -50, -3, -3).ShouldBe(45M);
            Angle.Test();
        }

        [TestMethod()]
        public void AngleTests_Test04()
        {
            //  0123456789
            // 8.A........
            // 7B.........
            // 6..........
            // 5..........
            // 4..........
            // 3..........
            // 2..........
            // 1..........
            // 0..........
            Angle.CalculateInDegreesClockWise(8, 1, 7, 0).ShouldBe(135M);
            Angle.CalculateInDegreesClockWiseTopIs0(8, 1, 7, 0).ShouldBe(225M);

        }

        [TestMethod()]
        public void AngleTests_Test05()
        {

            //  0123456789
            // 8..........
            // 7..........
            // 6..........
            // 5....A.....
            // 4..........
            // 3..........
            // 2..........
            // 1B.........
            // 0..........
            Angle.CalculateInDegreesClockWise(4, 5, 0, 1).ShouldBe(135M);
            Angle.CalculateInDegreesClockWiseTopIs0(4, 5, 0, 1).ShouldBe(225M);
        }

        [TestMethod()]
        public void AngleTests_Test06()
        {

            //  0123456789
            // 8..........
            // 7..........
            // 6..........
            // 5...A......
            // 4..........
            // 3.......B..
            // 2..........
            // 1..........
            // 0..........
            Angle.CalculateInDegreesClockWise(3, 5, 7, 3).ShouldBe(26.565051177078M);
            Angle.CalculateInDegreesClockWiseTopIs0(3, 5, 7, 3).ShouldBe(116.565051177078M);

        }

        [TestMethod()]
        public void AngleTests_Test07()
        {
            // 8.......B..
            // 7........A.
            // 6..........
            // 5..........
            // 4..........
            // 3..........
            // 2..........
            // 1..........
            // 0..........
            //  0123456789
            var x1 = 8; var y1 = 7; var x2 = 7; var y2 = 8;
            Angle.CalculateAngleInRadian(x1, y1, x2, y2).ShouldBe(Math.PI * 0.75);
            Angle.CalculateInDegrees(x1, y1, x2, y2).ShouldBe(135M);
            Angle.CalculateInDegreesClockWise(x1, y1, x2, y2).ShouldBe(225M);
            Angle.CalculateInDegreesClockWiseTopIs0(x1, y1, x2, y2).ShouldBe(315M);
        }

    }
}