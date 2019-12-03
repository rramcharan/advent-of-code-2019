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
        #region Move One
        [TestMethod()]
        public void TraversePath_MoveOne_Rigth01()
        {
            // Arrange
            var board = new Board();
            var startPoint = new Point(1, 8);

            // Act
            var nextPoint = board.Move(startPoint, "R8");

            // Assert
            Assert.AreEqual(9, nextPoint.X, "X position unexpected");
            Assert.AreEqual(8, nextPoint.Y, "Y position unexpected");
            var expectedMap = @"
...........
...........
...........
...........
...........
...........
...........
...........
.o--------.
...........";
            Assert.AreEqual(expectedMap, board.Map);
        }

        [TestMethod()]
        public void TraversePath_MoveOne_Left01()
        {
            // Arrange
            var board = new Board();
            var startPoint = new Point(1, 8);

            // Act
            var nextPoint = board.Move(startPoint, "L1");

            // Assert
            Assert.AreEqual(0, nextPoint.X, "X position unexpected");
            Assert.AreEqual(8, nextPoint.Y, "Y position unexpected");
            var expectedMap = @"
...........
...........
...........
...........
...........
...........
...........
...........
-o.........
...........";
            Assert.AreEqual(expectedMap, board.Map);
        }
        [TestMethod()]
        public void TraversePath_MoveOne_Up01()
        {
            // Arrange
            var board = new Board();
            var startPoint = new Point(1, 8);

            // Act
            var nextPoint = board.Move(startPoint, "U5");

            // Assert
            Assert.AreEqual(1, nextPoint.X, "X position unexpected");
            Assert.AreEqual(3, nextPoint.Y, "Y position unexpected");
            var expectedMap = @"
...........
...........
...........
.-.........
.-.........
.-.........
.-.........
.-.........
.o.........
...........";
            Assert.AreEqual(expectedMap, board.Map);
        }
        [TestMethod()]
        public void TraversePath_MoveOne_Down01()
        {
            // Arrange
            var board = new Board();
            var startPoint = new Point(1, 8);

            // Act
            var nextPoint = board.Move(startPoint, "D1");

            // Assert
            Assert.AreEqual(1, nextPoint.X, "X position unexpected");
            Assert.AreEqual(9, nextPoint.Y, "Y position unexpected");
            var expectedMap = @"
...........
...........
...........
...........
...........
...........
...........
...........
.o.........
.-.........";
            Assert.AreEqual(expectedMap, board.Map);
        }
        #endregion

        #region Move Two

        [TestMethod()]
        public void TraversePath_MoveTwo_Test01()
        {
            // Arrange
            var board = new Board();
            var startPoint = new Point(1, 8);

            // Act
            var nextPoint = board.Move(startPoint, "R8");
            nextPoint = board.Move(nextPoint, "U5");

            // Assert
            Assert.AreEqual(9, nextPoint.X, "X position unexpected");
            Assert.AreEqual(3, nextPoint.Y, "Y position unexpected");
            var expectedMap = @"
...........
...........
...........
.........-.
.........-.
.........-.
.........-.
.........-.
.o--------.
...........";
            Assert.AreEqual(expectedMap, board.Map);
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
            var a = new Point(1, 8);
            var b = new Point(4, 5);

            // Act
            var actual = Board.ManhattanDistance(a, b);

            // Assert
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Wire

        [TestMethod()]
        public void TraversePath_OneWire_Test01()
        {
            // Arrange
            var board = new Board();

            // Act
            var endPoint = board.Wire("R8,U5,L5,D3");

            // Assert
            Assert.AreEqual(4, endPoint.X, "X position unexpected");
            Assert.AreEqual(6, endPoint.Y, "Y position unexpected");
            var expectedMap = @"
...........
...........
...........
....------.
....-....-.
....-....-.
....-....-.
.........-.
.o--------.
...........";
            Assert.AreEqual(expectedMap, board.Map);
        }

        [TestMethod()]
        public void TraversePath_TwoWires_Test01()
        {
            // Arrange
            var board = new Board();

            // Act
            var endPointWire1 = board.Wire("R8,U5,L5,D3");
            var endPointWire2 = board.Wire("U7,R6,D4,L4");

            // Assert
            var expectedMap = @"
...........
.-------...
.-.....-...
.-..---x--.
.-..-..-.-.
.-.-x---.-.
.-..-....-.
.-.......-.
.o--------.
...........";
            Assert.AreEqual(expectedMap, board.Map);
        }


        #endregion

        #region Examples

        [TestMethod()]
        public void TraversePath_ExampleOne_Test01()
        {
            // Arrange
            var board = new Board();

            // Act
            var endPointWire1 = board.Wire("R8,U5,L5,D3");
            var endPointWire2 = board.Wire("U7,R6,D4,L4");

            // Assert
            var expectedMap = @"
...........
.-------...
.-.....-...
.-..---x--.
.-..-..-.-.
.-.-x---.-.
.-..-....-.
.-.......-.
.o--------.
...........";
            Assert.AreEqual(expectedMap, board.Map);
        }


        #endregion

    }
}