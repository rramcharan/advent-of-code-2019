using adventofcode2019_day9.Day7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;

namespace adventofcode2019_day9Tests.Day7
{
    [TestClass()]
    public class AllCombinationsTest
    {
        #region Examples day 7 part 1

        [TestMethod()]
        public void AllCombination_2Numbers_01()
        {
            // Act
            var result = new AmplifierController().AllCombination(1, 2);

            // Arrange
            result.ShouldBe(new List<int[]> {
                new int[] { 1, 2 },
                new int[] { 2, 1 },
            });
        }

        [TestMethod()]
        public void AllCombination_3Numbers_01()
        {
            // Act
            var result = new AmplifierController().AllCombination(1, 20, 30);

            // Arrange
            result.ShouldBe(new List<int[]> {
                new int[] { 1, 20, 30 },
                new int[] { 1, 30, 20},
                new int[] {20,  1, 30 },
                new int[] {20, 30,  1 },
                new int[] {30, 20,  1 },
                new int[] {30,  1, 20 },
            });
        }

        #endregion
    }
}
