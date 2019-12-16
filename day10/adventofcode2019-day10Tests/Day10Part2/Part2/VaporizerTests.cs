using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day10.Day10Part2;
using Shouldly;

namespace adventofcode2019_day10Tests.Day10Part2.Part1
{
    [TestClass()]
    public class VaporizerTests
    {
        [TestMethod()]
        public void VaporizerTests_ExampleMap_Test01()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##");
            // Act
            var list = monitor.MarkVaporize(8,3,1);
            var asteroid = list[0].Asteroid;

            // Assert
            asteroid.X.ShouldBe(8);
            asteroid.Y.ShouldBe(1);
        }

        [TestMethod()]
        public void VaporizerTests_ExampleMap_VaporizeFirst9_Test()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##");
            // Act
            monitor.MarkVaporize(8,3,9);

            monitor.VisibleAsteriodsMap().ShouldBe(@"
.#....###24...#..
##...##.13#67..9#
##...#...5.8####.
..#.....#...###..
..#.#.....#....##");
        }

        [TestMethod()]
        public void VaporizerTests_ExampleMap_VaporizeFirst9_Test02()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##");
            // Act
            monitor.VaporizeBuildList(8,3);
            monitor.Vaporize(9);

            monitor.DisplayAsteriodsMap().ShouldBe(@"
.#....###.....#..
##...##...#.....#
##...#......####.
..#.....#...###..
..#.#.....#....##");
        }


        [TestMethod()]
        public void VaporizerTests_ExampleMap_VaporizeSecond9_Test()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##");
            // Act
            monitor.VaporizeBuildList(8, 3);
            monitor.Vaporize(9);
            monitor.MarkToVaporize(9);
            
            monitor.VisibleAsteriodsMap().ShouldBe(@"
.#....###.....#..
##...##...#.....#
##...#......1234.
..#.....#...5##..
..#.9.....8....76");
        }

        [TestMethod()]
        public void VaporizerTests_ExampleMap_VaporizeThird9_Test()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##");
            // Act
            monitor.VaporizeBuildList(8, 3);
            monitor.Vaporize(18);
            monitor.MarkToVaporize(9);

            monitor.VisibleAsteriodsMap().ShouldBe(@"
.8....###.....#..
56...9#...#.....#
34...7...........
..2.....#....##..
..1..............");
        }

        [TestMethod()]
        public void VaporizerTests_ExampleMap_VaporizeFourth9_Test()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##");
            // Act
            monitor.VaporizeBuildList(8, 3);
            monitor.Vaporize(3 * 9);
            monitor.MarkToVaporize(9);

            monitor.VisibleAsteriodsMap().ShouldBe(@"
......234.....6..
......1...5.....7
.................
........#....89..
.................");
        }

        [TestMethod()]
        public void VaporizerTests_ExampleMap_VaporizeFifthourth9_Test()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##");
            // Act
            monitor.VaporizeBuildList(8, 3);
            monitor.Vaporize(4 * 9);
            monitor.MarkToVaporize(9);

            monitor.VisibleAsteriodsMap().ShouldBe(@"
.................
.................
.................
........#........
.................");
        }
    }
}