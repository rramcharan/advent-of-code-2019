//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using adventofcode2019_day11.Day11Part1.PaintingRobot;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Shouldly;

//namespace adventofcode2019_day11.Day11Part1.PaintingRobot.Tests
//{
//    [TestClass()]
//    public class SingleMovesTests
//    {
//        [TestMethod()]
//        public void Example_FromUpMoveLeft_DislayCanvas()
//        {
//            var printer = new EmergencyHullPaintingRobot();

//            // Act
//            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'

//            // Assert
//            printer.ShowDrawing().ShouldBe(@"
//.....
//.....
//.<#..
//.....
//.....");
//        }

//        [TestMethod()]
//        public void Example_FromLeftMoveLeft_DislayCanvas()
//        {
//            var printer = new EmergencyHullPaintingRobot();

//            // Act
//            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
//            printer.OutputAndMove(0, 0); //color=0: 'white' | direction 0: 'left'

//            // Assert
//            printer.ShowDrawing().ShouldBe(@"
//.....
//.....
//..#..
//.v...
//.....");
//        }

//        [TestMethod()]
//        public void Example_Move03_04_DislayCanvas()
//        {
//            var printer = new EmergencyHullPaintingRobot();

//            // Act
//            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
//            printer.OutputAndMove(0, 0); //color=0: 'white' | direction 0: 'left'
//            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'
//            printer.OutputAndMove(1, 0); //color=1: 'black' | direction 0: 'left'

//            // Assert
//            printer.ShowDrawing().ShouldBe(@"
//.....
//.....
//..^..
//.##..
//.....");
//        }
//    }
//}