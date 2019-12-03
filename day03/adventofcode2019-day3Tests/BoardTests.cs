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
        #region Resize board
        [TestMethod()]
        public void TraversePath_ResizeX_Test01()
        {
            // Arrange
            var board = new Board(4,5);

            // Act
            board.Resize(2,0);

            // Assert
            var expectedMap = @"
......
......
......
.o....
......";
            Assert.AreEqual(expectedMap, board.Map);
        }

        [TestMethod()]
        public void TraversePath_ResizeY_Test01()
        {
            // Arrange
            var board = new Board(4, 5);

            // Act
            board.Resize(0, 2);

            // Assert
            var expectedMap = @"
....
....
....
....
....
.o..
....";
            Assert.AreEqual(expectedMap, board.Map);
        }

        [TestMethod()]
        public void TraversePath_ResizeXandY_Test01()
        {
            // Arrange
            var board = new Board(4, 5);

            // Act
            board.Resize(2, 3);

            // Assert
            var expectedMap = @"
......
......
......
......
......
......
.o....
......";
            Assert.AreEqual(expectedMap, board.Map);
        }

        #endregion

        #region Move One
        [TestMethod()]
        public void TraversePath_MoveOne_Rigth01()
        {
            // Arrange
            var board = new Board();
            var wire = board.CreateWire(1, 1);

            // Act
            board.Move(wire, "R8");

            // Assert
            Assert.AreEqual(9, wire.X, "X position unexpected");
            Assert.AreEqual(1, wire.Y, "Y position unexpected");
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
            var wire = board.CreateWire(1, 1);

            // Act
            board.Move(wire, "L1");

            // Assert
            Assert.AreEqual(0, wire.X, "X position unexpected");
            Assert.AreEqual(1, wire.Y, "Y position unexpected");
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
            var wire = board.CreateWire(1, 1);

            // Act
            board.Move(wire, "U5");

            // Assert
            Assert.AreEqual(1, wire.X, "X position unexpected");
            Assert.AreEqual(6, wire.Y, "Y position unexpected");
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
            var wire = board.CreateWire(1, 1);

            // Act
            board.Move(wire, "D1");

            // Assert
            Assert.AreEqual(1, wire.X, "X position unexpected");
            Assert.AreEqual(0, wire.Y, "Y position unexpected");
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
            var wire = board.CreateWire(1, 1);

            // Act
            board.Move(wire, "R8");
            board.Move(wire, "U5");

            // Assert
            Assert.AreEqual(9, wire.X, "X position unexpected");
            Assert.AreEqual(6, wire.Y, "Y position unexpected");
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

        #region Move One
        [TestMethod()]
        public void TraversePath_MoveOneAndResize_Rigth01()
        {
            // Arrange
            var board = new Board(5,5);
            var wire = board.CreateWire(1, 1);

            // Act
            board.Move(wire, "R8");

            // Assert
            Assert.AreEqual(9, wire.X, "X position unexpected");
            Assert.AreEqual(1, wire.Y, "Y position unexpected");
            var expectedMap = @"
...............
...............
...............
.o--------.....
...............";
            Assert.AreEqual(expectedMap, board.Map);
        }

        [TestMethod()]
        public void TraversePath_MoveAndResize_RigthAndUp01()
        {
            // Arrange
            var board = new Board(5, 5);
            var wire = board.CreateWire(1, 1);

            // Act
            board.Move(wire, "R8");
            board.Move(wire, "U6");

            // Assert
            Assert.AreEqual(9, wire.X, "X position unexpected");
            Assert.AreEqual(7, wire.Y, "Y position unexpected");
            var expectedMap = @"
...............
...............
...............
...............
...............
...............
...............
.........-.....
.........-.....
.........-.....
.........-.....
.........-.....
.........-.....
.o--------.....
...............";
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
            Assert.AreEqual(3, endPoint.Y, "Y position unexpected");
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

        #region Intersections
        [TestMethod()]
        public void Intersections_ExampleOne_Test01()
        {
            // Arrange
            var board = new Board();
            board.Wire("R8,U5,L5,D3");
            board.Wire("U7,R6,D4,L4");

            // Act
            var distance = board.ClosestIntersectionDistance;

            // Assert
            Assert.AreEqual(6, distance);
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

        [TestMethod()]
        public void TraversePath_Examples_Test02()
        {
            // Arrange
            var board = new Board();

            // Act
            var endPointWire1 = board.Wire("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            var endPointWire2 = board.Wire("U62,R66,U55,R34,D71,R55,D58,R83");

            var actual = board.ClosestIntersectionDistance;

            // Assert
            var expected = 159;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void TraversePath_Examples_Test03()
        {
            // Arrange
            var board = new Board();

            // Act
            var endPointWire1 = board.Wire("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            var endPointWire2 = board.Wire("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");

            var actual = board.ClosestIntersectionDistance;

            // Assert
            var expected = 135;
            Assert.AreEqual(expected, actual);
        }

        #endregion

    }
}