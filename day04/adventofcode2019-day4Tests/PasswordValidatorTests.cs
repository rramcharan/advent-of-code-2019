using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day4.Tests
{
    [TestClass()]
    public class PasswordValidatorTests
    {
        #region Valid passwords

        [TestMethod()]
        public void IsValidTest_111111_IsValid()
        {
            Assert.IsTrue(new PasswordValidator().IsValid(111111));
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
        public void NumberOfValidPasswords_01_IsValid()
        {
            Assert.AreEqual(5,Password.NumberOfValidInRange(111111, 111115));
        }

        [TestMethod()]
        public void NumberOfValidPasswords_02_IsValid()
        {
            Assert.AreEqual(9, Password.NumberOfValidInRange(111111, 111120));
        }
        [TestMethod()]
        public void NumberOfValidPasswords_03_IsValid()
        {
            Assert.AreEqual(10, Password.NumberOfValidInRange(111111, 111122));
        }

        #endregion

        #region Puzzle input
        [TestMethod()]
        public void Puzzle()
        {
            Assert.AreEqual(1790, Password.NumberOfValidInRange(147981,691423));
        }

        #endregion
    }
}