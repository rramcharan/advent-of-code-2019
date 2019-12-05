using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventofcode2019_day4.Part2;

namespace adventofcode2019_day4.Tests
{
    [TestClass()]
    public class PasswordValidatorPart2Tests
    {
        #region Examples

        [TestMethod()]
        public void IsValidTest_Example01_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(111122));
        }

        [TestMethod()]
        public void IsValidTest_Example02_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(112233));
        }

        [TestMethod()]
        public void IsValidTest_Example03_IsNotValid()
        {
            Assert.IsFalse(new PasswordValidator().IsValid(123444));
        }

        #endregion

        #region Valid passwords

        [TestMethod()]
        public void IsValidTest_Double01_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(112345));
        }

        [TestMethod()]
        public void IsValidTest_Double02_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(123455));
        }

        [TestMethod()]
        public void IsValidTest_Double03_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(123345));
        }

        [TestMethod()]
        public void IsValidTest_Double04_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(113455));
        }

        [TestMethod()]
        public void IsValidTest_Double05_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(111455));
        }

        [TestMethod()]
        public void IsValidTest_Double06_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(111445));
        }

        [TestMethod()]
        public void IsValidTest_122345_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(122345));
        }
        [TestMethod()]
        public void IsValidTest_135677_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(135677));
        }
        #endregion

        #region Invalid passwords
        [TestMethod()]
        public void IsValidTest_Doubles01_IsNotValid()
        {
            Assert.IsFalse(new PasswordValidator().IsValid(111111));
        }

        [TestMethod()]
        public void IsValidTest_Doubles02_IsNotValid()
        {
            Assert.IsFalse(new PasswordValidator().IsValid(111345));
        }
        [TestMethod()]
        public void IsValidTest_Doubles03_IsNotValid()
        {
            Assert.IsFalse(new PasswordValidator().IsValid(123555));
        }
        [TestMethod()]
        public void IsValidTest_Doubles04_IsNotValid()
        {
            Assert.IsFalse(new PasswordValidator().IsValid(111222));
        }

        [TestMethod()]
        public void IsValidTest_TooShort_IsNotValid()
        {
            Assert.IsFalse(new PasswordValidator().IsValid(22));
        }

        [TestMethod()]
        public void IsValidTest_TooLong_IsNotValid()
        {
            // 223450 does not meet these criteria(decreasing pair of digits 50).
            Assert.IsFalse(new PasswordValidator().IsValid(2234555));
        }

        [TestMethod()]
        public void IsValidTest_NotIncreasing01_IsNotValid()
        {
            // 223450 does not meet these criteria(decreasing pair of digits 50).
            Assert.IsFalse(new PasswordValidator().IsValid(213456));
        }

        [TestMethod()]
        public void IsValidTest_NotIncreasing02_IsNotValid()
        {
            // 223450 does not meet these criteria(decreasing pair of digits 50).
            Assert.IsFalse(new PasswordValidator().IsValid(232455));
        }

        [TestMethod()]
        public void IsValidTest_NotIncreasing03_IsNotValid()
        {
            // 223450 does not meet these criteria(decreasing pair of digits 50).
            Assert.IsFalse(new PasswordValidator().IsValid(223454));
        }

        [TestMethod()]
        public void IsValidTest_123789_IsNotValid()
        {
            // 123789 does not meet these criteria (no double).
            Assert.IsFalse(new PasswordValidator().IsValid(123789));
        }

        [TestMethod()]
        public void IsValidTest_123289_IsNotValid()
        {
            // 123789 does not meet these criteria (no double).
            // not all incresing
            Assert.IsFalse(new PasswordValidator().IsValid(123289));
        }
        #endregion

        #region number of valid password in range
        [TestMethod()]
        public void NumberOfValidPasswords_00_IsValid()
        {
            Assert.AreEqual(0,Password.NumberOfValidInRange(111111, 111115));
        }
        [TestMethod()]
        public void NumberOfValidPasswords_01_IsValid()
        {
            Assert.AreEqual(1, Password.NumberOfValidInRange(123456, 123466));
        }

        [TestMethod()]
        public void NumberOfValidPasswords_02_IsValid()
        {
            Assert.AreEqual(1, Password.NumberOfValidInRange(123456, 123467));
        }
        [TestMethod()]
        public void NumberOfValidPasswords_03_IsValid()
        {
            Assert.AreEqual(0, Password.NumberOfValidInRange(111111, 111121));
        }
        [TestMethod()]
        public void NumberOfValidPasswords_04_IsValid()
        {
            Assert.AreEqual(1, Password.NumberOfValidInRange(111111, 111122));
        }
        [TestMethod()]
        public void NumberOfValidPasswords_05_IsValid()
        {
            Assert.AreEqual(3, Password.NumberOfValidInRange(111111, 111144));
        }

        #endregion

        #region Puzzle input
        [TestMethod()]
        public void Puzzle()
        {
            Assert.AreEqual(1206, Password.NumberOfValidInRange(147981,691423));
        }

        #endregion
    }
}