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
    public class ExampleDay2
    {
        #region Examples from day 5

        #region Examples

        [TestMethod()]
        public void ExampleDay5Part1_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1002,4,3,4,33,
            };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            Assert.AreEqual(1002, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(4, result.Code(1), "position 1 is unexpected");
            Assert.AreEqual(3, result.Code(2), "position 2 is unexpected");
            Assert.AreEqual(4, result.Code(3), "position 3 is unexpected");
            Assert.AreEqual(99, result.Code(4), "position 4 is unexpected");
        }

        [TestMethod()]
        public void ExampleDay5Part1_Test02()
        {
            // Arrange
            var input = new int[]
            {
                1101,100,-1,4,0,
            };

            // Act
            var result = GravityAssistPart1.Process(input);

            // Arrange
            Assert.AreEqual(1101, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(100, result.Code(1), "position 1 is unexpected");
            Assert.AreEqual(-1, result.Code(2), "position 2 is unexpected");
            Assert.AreEqual(4, result.Code(3), "position 3 is unexpected");
            Assert.AreEqual(99, result.Code(4), "position 4 is unexpected");
        }

        #endregion
        #endregion
    }

}