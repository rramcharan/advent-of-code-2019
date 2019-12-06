using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day5.Tests
{
    [TestClass()]
    public class GravityAssistTestsPart1
    {
        #region Tests from day 2
        #region Tests
        [TestMethod()]
        public void ProcessTest()
        {
            // Arrange
            var input = new int[]
            {
                1, 2, 6, 2,
                99,
                1, 2, 3, 4
            };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            Assert.AreEqual(1, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(2, result.Code(1), "position 1 is unexpected");
            Assert.AreEqual(8, result.Code(2), "position 2 is unexpected");
            Assert.AreEqual(2, result.Code(3), "position 3 is unexpected");
        }

        [TestMethod()]
        public void ProcessTest_Example01()
        {
            // Arrange
            var input = new int[]
            {
                1,9,10,3,
                2,3,11,0,
                99,
                30,40,50
            };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            Assert.AreEqual(3500, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(9, result.Code(1), "position 1 is unexpected");
            Assert.AreEqual(10, result.Code(2), "position 2 is unexpected");
            Assert.AreEqual(70, result.Code(3), "position 3 is unexpected");

            Assert.AreEqual(2, result.Code(4), "position 4 is unexpected");
            Assert.AreEqual(3, result.Code(5), "position 5 is unexpected");
            Assert.AreEqual(11, result.Code(6), "position 6 is unexpected");
            Assert.AreEqual(0, result.Code(7), "position 7 is unexpected");

            Assert.AreEqual(99, result.Code(8), "position 8 is unexpected");
            Assert.AreEqual(30, result.Code(9), "position 9 is unexpected");
            Assert.AreEqual(40, result.Code(10), "position 10 is unexpected");
            Assert.AreEqual(50, result.Code(11), "position 11 is unexpected");
        }

        [TestMethod()]
        public void ProcessTest_Example02()
        {
            // Arrange
            var input = new int[] { 1, 0, 0, 0, 99 };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            var expected = new int[] { 2, 0, 0, 0, 99 };
            AreEqual(expected, result.Codes);
        }

        [TestMethod()]
        public void ProcessTest_Example03()
        {
            // Arrange
            var input = new int[] { 2, 3, 0, 3, 99 };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            var expected = new int[] { 2, 3, 0, 6, 99 };
            AreEqual(expected, result.Codes);
        }


        [TestMethod()]
        public void ProcessTest_Example04()
        {
            // Arrange
            var input = new int[] { 2, 4, 4, 5, 99, 0 };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            var expected = new int[] { 2, 4, 4, 5, 99, 9801 };
            AreEqual(expected, result.Codes);
        }


        [TestMethod()]
        public void ProcessTest_Example05()
        {
            // Arrange
            var input = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            var expected = new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 };
            AreEqual(expected, result.Codes);
        }


        private void AreEqual(int[] expected, Dictionary<int, int> actual)
        {
            Assert.AreEqual(expected.Length, actual.Keys.Count, "Length check failed");
            for (var index = 0; index < expected.Length; index++)
            {
                Assert.AreEqual(expected[index], actual[index], $"position {index} is unexpected");
            }
        }
        #endregion

        #region Puzzle Input (part 1)
        [TestMethod()]
        public void ProcessTest_PuzzleInput()
        {
            // Arrange
            var input = new int[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 13, 1, 19, 1, 19, 9, 23, 1, 5, 23, 27, 1, 27, 9, 31, 1, 6, 31, 35, 2, 35, 9, 39, 1, 39, 6, 43, 2, 9, 43, 47, 1, 47, 6, 51, 2, 51, 9, 55, 1, 5, 55, 59, 2, 59, 6, 63, 1, 9, 63, 67, 1, 67, 10, 71, 1, 71, 13, 75, 2, 13, 75, 79, 1, 6, 79, 83, 2, 9, 83, 87, 1, 87, 6, 91, 2, 10, 91, 95, 2, 13, 95, 99, 1, 9, 99, 103, 1, 5, 103, 107, 2, 9, 107, 111, 1, 111, 5, 115, 1, 115, 5, 119, 1, 10, 119, 123, 1, 13, 123, 127, 1, 2, 127, 131, 1, 131, 13, 0, 99, 2, 14, 0, 0 };

            // Act
            var result = GravityAssistPart1.RestoreGravityAsistAndProcessCodes(12, 2, input);

            // Arrange
            Assert.AreEqual(3409710, result.Code(0), "position 0 is unexpected");
        }
        #endregion

        #region Puzzle Input (part 1)
        [TestMethod()]
        public void ProcessTest_CalculateNounAndVerbToGetAnswer19690720()
        {
            // Arrange

            int answer = 0;
            // Act
            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    try
                    {
                        var input = new int[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 13, 1, 19, 1, 19, 9, 23, 1, 5, 23, 27, 1, 27, 9, 31, 1, 6, 31, 35, 2, 35, 9, 39, 1, 39, 6, 43, 2, 9, 43, 47, 1, 47, 6, 51, 2, 51, 9, 55, 1, 5, 55, 59, 2, 59, 6, 63, 1, 9, 63, 67, 1, 67, 10, 71, 1, 71, 13, 75, 2, 13, 75, 79, 1, 6, 79, 83, 2, 9, 83, 87, 1, 87, 6, 91, 2, 10, 91, 95, 2, 13, 95, 99, 1, 9, 99, 103, 1, 5, 103, 107, 2, 9, 107, 111, 1, 111, 5, 115, 1, 115, 5, 119, 1, 10, 119, 123, 1, 13, 123, 127, 1, 2, 127, 131, 1, 131, 13, 0, 99, 2, 14, 0, 0 };
                        var result = GravityAssistPart1.RestoreGravityAsistAndProcessCodes(noun, verb, input);
                        var address0 = result.Code(0);
                        Console.WriteLine($"noun: {noun} | verb {verb} > address 0: {address0}");
                        if (address0 == 19690720)
                        {
                            answer = 100 * result.Noun + result.Verb;
                            break;
                        }
                    }
                    catch (Exception ex) { }
                }
                if (answer > 0) break;
            }
            // Arrange
            Assert.AreEqual(7912, answer, "position 0 is unexpected");
        }
        #endregion
#endregion
    }
}