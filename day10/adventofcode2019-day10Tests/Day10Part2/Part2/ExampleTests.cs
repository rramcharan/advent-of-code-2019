using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day10.Day10Part2;
using Shouldly;
using System;
using System.Collections.Generic;

namespace adventofcode2019_day10Tests.Day10Part2.Part1
{
    [TestClass()]
    public class ExampleTests
    {
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
            var list = monitor.VaporizeBuildList(11, 13);

            // Assert
            Verify(list, 1, 11, 12);
            Verify(list, 2, 12, 1);
            Verify(list, 3, 12, 2);
            Verify(list, 10, 12, 8);
            Verify(list, 20, 16, 0);
            Verify(list, 50, 16, 9);
            Verify(list, 100, 10, 16);
            Verify(list, 200, 8, 2);
            Verify(list, 201, 10, 9);
            Verify(list, 299, 11, 1);
            list.Count.ShouldBe(299);
            asteroid.NbrOfVisibleAsteroids.ShouldBe(210);
            Verify(asteroid, 11, 13, "Most nbr of visible asteroids");
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