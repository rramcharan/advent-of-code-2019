using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day11.Day11Part1.PaintingRobot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using adventofcode2019_day11.Day11Part1.Enums;

namespace adventofcode2019_day11.Day11Part1.PaintingRobot.Tests
{
    [TestClass()]
    public class DifferentMovesTests
    {
        #region Left moves...

        [TestMethod()]
        public void LeftMoves_DislayCanvas()
        {
            var printer = new EmergencyHullPaintingRobot();

            // Act
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);

            // Assert
            printer.ShowDrawing().ShouldBe(@"
.....
.....
.<#..
.##..
.....");
        }

        #endregion

        #region Right moves...
        [TestMethod()]
        public void MovesRight_Test02()
        {
            var printer = new EmergencyHullPaintingRobot();

            // Act
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);

            // Assert
            printer.ShowDrawing().ShouldBe(@"
.....
.....
..^#.
..##.
.....");
        }


        #endregion

        #region Left en Right moves...

        #endregion

        #region Move outside default borders...

        [TestMethod()]
        public void OutsideBoundriesMoves_Test02()
        {
            var printer = new EmergencyHullPaintingRobot();

            // Act
            printer.OutputAndMove(PaintingColors.Black, Direction.Left); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(PaintingColors.Black, Direction.Right); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(PaintingColors.Black, Direction.Left); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(PaintingColors.Black, Direction.Left); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(PaintingColors.Black, Direction.Right); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(PaintingColors.Black, Direction.Left); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(PaintingColors.Black, Direction.Right); //color=1: 'black' | direction 0: 'left'

            // Assert
            printer.ShowDrawing().ShouldBe(@"
.......
..##...
.####..
<#.....
.......");
        }


        [TestMethod()]
        public void OutsideBoundriesMoves_Test01()
        {
            var printer = new EmergencyHullPaintingRobot();

            // Act
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Left);
            printer.OutputAndMove(PaintingColors.Black, Direction.Right);

            // Assert
            printer.ShowDrawing().ShouldBe(@"
........
...##...
..#####>
.....##.
........");
        }

        #endregion


    }
}