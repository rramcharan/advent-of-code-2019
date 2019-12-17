using adventofcode2019_day11.Day11Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace adventofcode2019_day11Tests.Day11Part1
{
    [TestClass()]
    public class GravityAssistDay7Part1Tests
    {
        #region Examples day 7 part 1

        [TestMethod()]
        public void Example_Part1_01()
        {// Arrange
            var input = new int[]
            {
                3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0
            };

            // Act
            var result = AmplifierController.RunSequenceOnAmplifiers(input, 4, 3, 2, 1, 0);

            // Arrange
            result.MaxThrusterSignal.ShouldBe(43210);
        }

        [TestMethod()]
        public void Example_Part1_02()
        {// Arrange
            var input = new int[]
            {
                3,23,3,24,1002,24,10,24,1002,23,-1,23,
                101,5,23,23,1,24,23,23,4,23,99,0,0
            };

            // Act
            var result = AmplifierController.RunSequenceOnAmplifiers(input, 0, 1, 2, 3, 4);

            // Arrange
            result.MaxThrusterSignal.ShouldBe(54321);
        }

        [TestMethod()]
        public void Example_Part1_03()
        {// Arrange
            var input = new int[]
            {
                3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,
                1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0
            };

            // Act
            var result = AmplifierController.RunSequenceOnAmplifiers(input, 1, 0, 4, 3, 2);

            // Arrange
            result.MaxThrusterSignal.ShouldBe(65210);
        }

        [TestMethod()]
        public void Example_Part1_03_DifferentOrderOfSequences()
        {// Arrange
            var input = new int[]
            {
                3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,
                1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0
            };

            // Act
            var result = AmplifierController.RunSequenceOnAmplifiers(input, 0, 1, 2, 3, 4);

            // Arrange
            result.MaxThrusterSignal.ShouldBe(65210);
        }

        #endregion

        #region Puzzle Day 7 Part 1

        [TestMethod()]
        public void Puzzle_Day7_Part1()
        {// Arrange
            var input = new int[]
            {
                3,8,1001,8,10,8,105,1,0,0,21,42,63,76,101,114,195,276,357,438,99999,3,9,101,2,9,9,102,5,9,9,1001,9,3,9,1002,9,5,9,4,9,99,3,9,101,4,9,9,102,5,9,9,1001,9,5,9,102,2,9,9,4,9,99,3,9,1001,9,3,9,1002,9,5,9,4,9,99,3,9,1002,9,2,9,101,5,9,9,102,3,9,9,101,2,9,9,1002,9,3,9,4,9,99,3,9,101,3,9,9,102,2,9,9,4,9,99,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,99,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,99
            };

            // Act
            var result = AmplifierController.RunSequenceOnAmplifiers(input, 0, 1, 2, 3, 4);

            // Arrange
            result.MaxThrusterSignal.ShouldBe(255590);
        }

        #endregion
    }
}
