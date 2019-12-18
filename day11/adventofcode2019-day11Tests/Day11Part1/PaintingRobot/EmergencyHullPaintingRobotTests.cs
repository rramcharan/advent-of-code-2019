using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day11.Day11Part1.PaintingRobot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace adventofcode2019_day11.Day11Part1.PaintingRobot.Tests
{
    [TestClass()]
    public class EmergencyHullPaintingRobotTests
    {
        [TestMethod()]
        public void Example_Initial_Canvas()
        {
            var printer = new EmergencyHullPaintingRobot();

            // Assert
            printer.ShowDrawing().ShouldBe(@"
.....
.....
..^..
.....
.....");
        }

        [TestMethod()]
        public void Example_Move01_DislayCanvas()
        {
            var printer = new EmergencyHullPaintingRobot();

            // Act
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'

            // Assert
            printer.ShowDrawing().ShouldBe(@"
.....
.....
.<#..
.....
.....");
        }

        [TestMethod()]
        public void Example_Move02_DislayCanvas()
        {
            var printer = new EmergencyHullPaintingRobot();

            // Act
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(0, 0); //color=0: 'white' | direction 0: 'left'

            // Assert
            printer.ShowDrawing().ShouldBe(@"
.....
.....
..#..
.v...
.....");
        }

        [TestMethod()]
        public void Example_Move03_04_DislayCanvas()
        {
            var printer = new EmergencyHullPaintingRobot();
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(0, 0); //color=0: 'white' | direction 0: 'left'
/*
.....
.....
..#..
.v...
.....
*/
            // Act
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'

            // Assert
            printer.ShowDrawing().ShouldBe(@"
.....
.....
..^..
.##..
.....");
        }

        [TestMethod()]
        public void Example_Move05_06_07_DislayCanvas()
        {
            var printer = new EmergencyHullPaintingRobot();
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(0, 0); //color=0: 'white' | direction 0: 'left'
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
/*
.....
.....
..^..
.##..
.....
*/
            // Act
            printer.OutputAndMove(0, 1); //color=0: 'white' | direction 1: 'right'
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'

            // Assert
            printer.NbrOfPanelsPainted.ShouldBe(6);
            printer.ShowDrawing().ShouldBe(@"
.....
..<#.
...#.
.##..
.....");
        }
    }
}