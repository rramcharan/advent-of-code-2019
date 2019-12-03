using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day3.Tests
{
    [TestClass()]
    public class BoardTests
    {
        #region Move
        [TestMethod()]
        public void TraversePath_Move01()
        {
            // Arrange
            var board = new Board();
            var startPoint = new Point(1,8);
            
            // Act
            var nextPoint = board.Move(startPoint, "R8");

            // Assert
            Assert.AreEqual(9, nextPoint.X, "X position unexpected");
            Assert.AreEqual(8, nextPoint.Y, "Y position unexpected");
        }
        #endregion


        #region traverse
        [TestMethod()]
        public void TraversePath_Test01()
        {
            var board = new Board();
            board.Wire("R8, U5, L5, D3");
        }
        #endregion

            #region distance
        [TestMethod()]
        public void ManhattanDistanceTest()
        {
            // Arrange
            var a = new Point(1,8);
            var b = new Point(4,5);

            // Act
            var actual = Board.ManhattanDistance(a, b);

            // Assert
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}