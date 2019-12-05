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
    public class InstructionTests
    {
        #region Only opcode
        [TestMethod()]
        public void ParseTest_OnlyOpcode_OneDigit()
        {
            // Act
            var instruction = Instruction.Parse(1);

            // Assert
            Assert.AreEqual(1, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam3);
        }

        [TestMethod()]
        public void ParseTest_OnlyOpcode_TwoDigit()
        {
            // Act
            var instruction = Instruction.Parse(12);

            // Assert
            Assert.AreEqual(12, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam3);
        }
        #endregion

        #region Opcode with params
        [TestMethod()]
        public void ParseTest_OpcodeAndParam1()
        {
            // Act
            var instruction = Instruction.Parse(102);

            // Assert
            Assert.AreEqual(2, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam3);
        }

        [TestMethod()]
        public void ParseTest_OpcodeAndParam1And2_Test01()
        {
            // Act
            var instruction = Instruction.Parse(1102);

            // Assert
            Assert.AreEqual(2, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam3);
        }

        [TestMethod()]
        public void ParseTest_OpcodeAndParam1And2_Test02()
        {
            // Act
            var instruction = Instruction.Parse(1002);

            // Assert
            Assert.AreEqual(2, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam3);
        }

        [TestMethod()]
        public void ParseTest_OpcodeAndParam1And2And3_Test01()
        {
            // Act
            var instruction = Instruction.Parse(10015);

            // Assert
            Assert.AreEqual(15, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam3);
        }

        [TestMethod()]
        public void ParseTest_OpcodeAndParam1And2And3_Test02()
        {
            // Act
            var instruction = Instruction.Parse(11015);

            // Assert
            Assert.AreEqual(15, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Position, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam3);
        }

        [TestMethod()]
        public void ParseTest_OpcodeAndParam1And2And3_Test03()
        {
            // Act
            var instruction = Instruction.Parse(11115);

            // Assert
            Assert.AreEqual(15, instruction.Opcode);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam1);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam2);
            Assert.AreEqual(ParameterMode.Immediate, instruction.ModeParam3);
        }

        #endregion
    }
}