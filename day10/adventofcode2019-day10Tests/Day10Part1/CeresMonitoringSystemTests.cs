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
    public class CeresMonitoringSystemTests
    {
        [TestMethod()]
        public void LoadAsteroidsMap_ExampleMap_Test01()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#..#
.....
#####
....#
...##");
            monitor.VisibleAsteriodsCount(3, 4).ShouldBe(8);
            monitor.VisibleAsteriodsCount(1, 0).ShouldBe(7);
            monitor.VisibleAsteriodsCount(4, 3).ShouldBe(7);
        }

        [TestMethod()]
        public void LoadAsteroidsMap_ExampleMap_Test02()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#..#
.....
#####
....#
...##");

            monitor.VisibleAsteriodsMap().ShouldBe(@"
.7..7
.....
67775
....7
...87");
        }


        [TestMethod()]
        public void LoadAsteroidsMap_ExampleMap_MostVisibleNbrOfAsteriods_Test01()
        {
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#..#
.....
#####
....#
...##");
            var asteroid = monitor.MostVisibleNbrOfAsteriods();
            asteroid.X.ShouldBe(3);
            asteroid.Y.ShouldBe(4);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(8);

        }

        #region larger examples

        [TestMethod()]
        public void LoadAsteroidsMap_LargerExampleMap_Test01()
        {
            // Arrage
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####");
            
            // Act
            var asteroid = monitor.MostVisibleNbrOfAsteriods();

            // Assert
            asteroid.X.ShouldBe(5);
            asteroid.Y.ShouldBe(8);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(33);
        }

        [TestMethod()]
        public void LoadAsteroidsMap_LargerExampleMap_Test02()
        {
            // Arrage
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###.");

            // Act
            var asteroid = monitor.MostVisibleNbrOfAsteriods();

            // Assert
            asteroid.X.ShouldBe(1);
            asteroid.Y.ShouldBe(2);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(35);
        }

        [TestMethod()]
        public void LoadAsteroidsMap_LargerExampleMap_Test03()
        {
            // Arrage
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#..#..###
####.###.#
....###.#.
..###.##.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#..");

            // Act
            var asteroid = monitor.MostVisibleNbrOfAsteriods();

            // Assert
            asteroid.X.ShouldBe(6);
            asteroid.Y.ShouldBe(3);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(41);
        }

        [TestMethod()]
        public void LoadAsteroidsMap_LargerExampleMap_Test04()
        {
            // Arrage
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##");

            // Act
            var asteroid = monitor.MostVisibleNbrOfAsteriods();

            // Assert
            asteroid.X.ShouldBe(11);
            asteroid.Y.ShouldBe(13);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(210);
        }

        #endregion
    }
}