using adventofcode2019_day9.Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;

namespace adventofcode2019_day9Tests.Part1
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
            result.ShouldBe(new List<long[]> {
                new long[] { 1, 2 },
                new long[] { 2, 1 },
            });
        }

        [TestMethod()]
        public void AllCombination_3Numbers_01()
        {
            // Act
            var result = new AmplifierController().AllCombination(1, 20, 30);

            // Arrange
            result.ShouldBe(new List<long[]> {
                new long[] { 1, 20, 30 },
                new long[] { 1, 30, 20},
                new long[] {20,  1, 30 },
                new long[] {20, 30,  1 },
                new long[] {30, 20,  1 },
                new long[] {30,  1, 20 },
            });
        }

        #endregion
    }
}
