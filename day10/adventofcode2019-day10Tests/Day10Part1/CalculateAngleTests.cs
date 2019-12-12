using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day10.Day10Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace adventofcode2019_day10.Day10Part1.Tests
{
    [TestClass()]
    public class CalculateAngleTests
    {
        [TestMethod()]
        public void CalculateAngleTests_01()
        {
            Angle.CalculateInDegrees(2, 2,0,0).ShouldBe(45D);
            Angle.CalculateInDegrees(4, 4,0,0).ShouldBe(45D);
            Angle.CalculateInDegrees(0, 0, 2, 2).ShouldBe(-135D);
        }
    }
}