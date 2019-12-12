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
    public class Puzzle
    {
        [TestMethod()]
        public void RunPuzzle()
        {
            // Arrage
            var monitor = CeresMonitoringSystem.LoadAsteroidsMap(@"
.###..#......###..#...#
#.#..#.##..###..#...#.#
#.#.#.##.#..##.#.###.##
.#..#...####.#.##..##..
#.###.#.####.##.#######
..#######..##..##.#.###
.##.#...##.##.####..###
....####.####.#########
#.########.#...##.####.
.#.#..#.#.#.#.##.###.##
#..#.#..##...#..#.####.
.###.#.#...###....###..
###..#.###..###.#.###.#
...###.##.#.##.#...#..#
#......#.#.##..#...#.#.
###.##.#..##...#..#.#.#
###..###..##.##..##.###
###.###.####....######.
.###.#####.#.#.#.#####.
##.#.###.###.##.##..##.
##.#..#..#..#.####.#.#.
.#.#.#.##.##########..#
#####.##......#.#.####.");

            // Act
            var asteroid = monitor.MostVisibleNbrOfAsteriods();

            // Assert
            asteroid.X.ShouldBe(19);
            asteroid.Y.ShouldBe(11);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(230);

        }
    }
}