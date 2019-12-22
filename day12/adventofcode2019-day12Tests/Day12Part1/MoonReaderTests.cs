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
    public class MoonReaderTests
    {
        [TestMethod()]
        public void ParseTest_XYZ_AllPositiveNumbers_Test1()
        {
            var moon = MoonReader.Parse("<x=2, y=10, z=7>");

            moon.Position.X.ShouldBe(2);
            moon.Position.Y.ShouldBe(10);
            moon.Position.Z.ShouldBe(7);
        }

        [TestMethod()]
        public void ParseTest_XYZ_WithNegativeNumbers_Test1()
        {
            var moon = MoonReader.Parse("<x=-3, y=-11, z=789>");

            moon.Position.X.ShouldBe(-3);
            moon.Position.Y.ShouldBe(-11);
            moon.Position.Z.ShouldBe(789);
        }
    }
}