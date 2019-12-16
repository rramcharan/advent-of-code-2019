using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day10.Day10Part2;
using Shouldly;
using System.Collections.Generic;

namespace adventofcode2019_day10Tests.Day10Part2.Part1
{
    [TestClass()]
    public class Day10Part2_Puzzle
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
            var list = monitor.VaporizeBuildList(asteroid.X, asteroid.Y);

            // Assert
            asteroid.X.ShouldBe(19);
            asteroid.Y.ShouldBe(11);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(230);

            Verify(list, 200, 12, 5);
            var answer = 12 * 100 + 5;
            answer.ShouldBe(1205, "Answer");
        }

        private void Verify(List<AsteroidMeasurement> list, int number, int expectedX, int expectedY)
        {
            var asteroid = list[number - 1].Asteroid;
            Verify(asteroid, expectedX, expectedY, $"Asteroid to vaporize: {number}");

        }

        private void Verify(Asteroid asteroid, int expectedX, int expectedY, string description)
        {
            asteroid.X.ShouldBe(expectedX, $"X of {description}");
            asteroid.Y.ShouldBe(expectedY, $"Y of {description}");
        }
    }
}