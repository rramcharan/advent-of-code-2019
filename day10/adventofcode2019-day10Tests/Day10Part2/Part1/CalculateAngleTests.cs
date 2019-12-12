using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day10.Day10Part2;
using Shouldly;

namespace adventofcode2019_day10Tests.Day10Part2.Part1
{
    [TestClass()]
    public class CalculateAngleTests
    {
        [TestMethod()]
        public void CalculateAngleTests_01()
        {
            Angle.CalculateInDegrees(2, 2, 0, 0).ShouldBe(45D);
            Angle.CalculateInDegrees(4, 4, 0, 0).ShouldBe(45D);
            Angle.CalculateInDegrees(0, 0, 2, 2).ShouldBe(-135D);
        }
    }
}