﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
//        [TestMethod()]
//        public void TraversePath_ResizeX_Test01()
//        {
//            // Arrange
//            var board = new Board(4,5);

//            // Act
//            board.Resize(2,0);

//            // Assert
//            var expectedMap = @"
//......
//......
//......
//.o....
//......";
//            Assert.AreEqual(expectedMap, board.Map);
//        }

//        [TestMethod()]
//        public void TraversePath_ResizeY_Test01()
//        {
//            // Arrange
//            var board = new Board(4, 5);

//            // Act
//            board.Resize(0, 2);

//            // Assert
//            var expectedMap = @"
//....
//....
//....
//....
//....
//.o..
//....";
//            Assert.AreEqual(expectedMap, board.Map);
//        }

//        [TestMethod()]
//        public void TraversePath_ResizeXandY_Test01()
//        {
//            // Arrange
//            var board = new Board(4, 5);

//            // Act
//            board.Resize(2, 3);

//            // Assert
//            var expectedMap = @"
//......
//......
//......
//......
//......
//......
//.o....
//......";
//            Assert.AreEqual(expectedMap, board.Map);
//        }

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
//        [TestMethod()]
//        public void TraversePath_MoveOneAndResize_Rigth01()
//        {
//            // Arrange
//            var board = new Board(5,5);
//            var wire = board.CreateWire(1, 1);

//            // Act
//            board.Move(wire, "R8");

//            // Assert
//            Assert.AreEqual(9, wire.X, "X position unexpected");
//            Assert.AreEqual(1, wire.Y, "Y position unexpected");
//            var expectedMap = @"
//...............
//...............
//...............
//.o--------.....
//...............";
//            Assert.AreEqual(expectedMap, board.Map);
//        }

//        [TestMethod()]
//        public void TraversePath_MoveAndResize_RigthAndUp01()
//        {
//            // Arrange
//            var board = new Board(5, 5);
//            var wire = board.CreateWire(1, 1);

//            // Act
//            board.Move(wire, "R8");
//            board.Move(wire, "U6");

//            // Assert
//            Assert.AreEqual(9, wire.X, "X position unexpected");
//            Assert.AreEqual(7, wire.Y, "Y position unexpected");
//            var expectedMap = @"
//...............
//...............
//...............
//...............
//...............
//...............
//...............
//.........-.....
//.........-.....
//.........-.....
//.........-.....
//.........-.....
//.........-.....
//.o--------.....
//...............";
//            Assert.AreEqual(expectedMap, board.Map);
//        }

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
            board.Wire("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            board.Wire("U62,R66,U55,R34,D71,R55,D58,R83");

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

        #region Puzzle input
        [TestMethod()]
        public void TraversePath_Puzzle()
        {
            // Arrange
            var board = new Board();

            // Act
            var endPointWire1 = board.Wire("R998,U547,L703,D251,L776,U837,R100,U240,R197,D216,L220,U606,L437,U56,R940,U800,L968,D464,L870,D797,L545,D824,R790,U5,R347,D794,R204,U538,L247,U385,L103,D260,L590,U813,L549,U309,L550,U321,R862,D686,R368,D991,R451,D836,R264,D138,L292,D319,L784,D369,R849,U865,R776,D726,R223,D118,L790,D208,L836,D592,R310,D36,R991,U674,L205,U407,R422,U350,L126,D320,L239,U353,L509,U48,R521,D544,L157,D551,R614,D493,R407,D965,R498,U248,R826,U573,L782,D589,R616,D992,L806,D745,R28,U142,L333,D849,L858,D617,R167,U341,R46,U940,L615,D997,L447,D604,R148,U561,R925,D673,R441,U200,R458,U193,L805,D723,L208,U600,L926,U614,R660,D183,L408,D834,R248,U354,L110,U391,L37,U599,L287,U28,R859,D936,L404,D952,R11,U20,R708,U218,L800,U750,R936,D213,R6,D844,R728,D391,R114,U406,R390,U791,L199,D397,R476,D583,R99,U419,R575,D836,L896,U780,L77,U964,R441,U723,R248,D170,R527,D94,L39,U645,L338,D728,R503,U641,L358,D287,R171,U368,R176,D986,R821,U912,L231,D206,L451,U900,L35,D490,R190,D180,L937,D500,R157,U989,L336,U202,R178,U52,R931,U306,L85,D866,R756,U715,L521,D977,R936,U4,R207,D384,L785,U138,L682,U488,L537,U250,L877,D446,R849,U35,R258,U784,R263,D494,L324,U601,R302,U473,L737,D143,R184,D967,R95,U51,L713,U733,R297,U740,R677,D715,R750,U143,L980,U260,R915,D535,R202,U460,R365,U956,L73,U441,R182,D982,L869,D755,L837,D933,L856,D341,R189,D519,L387,D144,R575,U682,R317,U838,R154,D201,R237,D410,L43,U853,L495,U983,L953,U220,R697,D592,R355,U377,R792,U824,L441,U783,R258,D955,R451,D178,L151,D435,L232,U923,L663,U283,L92,D229,R514");
            var endPointWire2 = board.Wire("L995,U122,R472,U470,R725,U906,L83,U672,R448,U781,L997,U107,R66,D966,L780,D181,L662,U158,R804,D837,L237,U164,L98,U582,R925,D806,L153,D843,R601,U941,L968,D528,R482,D586,R15,U370,L592,U836,R828,U676,R606,D20,R841,U117,L262,U377,R375,U503,R166,D398,R161,D9,R140,D188,R895,D226,R77,U28,L727,D72,L51,U425,R370,D377,L801,D525,R102,D568,L416,D300,R415,U199,R941,U211,R285,U719,L259,U872,L959,U350,L196,D830,R515,U899,R298,U875,R946,U797,R108,U461,R999,D49,L369,D472,R83,D265,L825,D163,R162,U906,L816,D241,L587,D801,R601,D630,R937,U954,L379,D347,R831,D337,L192,D649,L853,U270,R162,D892,L26,D663,L276,U891,R843,U67,R225,D88,R686,U662,R794,D814,L200,D887,R567,U363,L863,U16,R975,D470,R714,U771,L267,D402,R75,U98,L686,U565,R584,D402,L824,D927,R71,U39,L174,D494,L358,D626,R616,D369,R471,U881,L428,U53,R862,U749,L847,D944,L887,D695,R442,U870,L993,U315,L878,U100,L480,D354,L12,D533,L236,D364,R450,U679,L926,D391,R313,D953,L560,D740,L974,D119,L370,U404,R339,U233,R901,U514,R584,D495,R308,U170,R759,U592,R388,U396,R477,U670,R906,D687,L874,U352,R124,U700,R289,D524,L93,D817,R408,D776,L235,D928,L534,D296,R116,U995,L63,D903,R758,U881,L530,U498,R573,D626,L26,U269,R237,U287,L840,D603,R948,D567,R89,U552,L299,D774,R863,D182,R773,D108,L137,U88,L731,U793,L267,U902,L41,U258,L156,U361,R389,D839,L976,U960,L342,D489,R816,U391,L393,U601,R255,D629,R832,U877,L34,D373,L809,D679,L104,U901,R157,U468,R143,U896,L637,D577,L545,D486,L970,D130,L305,D909,R984,D500,L935,U949,R525,D547,L786,U106,L269,D511,L919");

            var actual = board.ClosestIntersectionDistance;

            // Assert
            var expected = 731;
            Assert.AreEqual(expected, actual);
        }


        #endregion
    }
}