using adventofcode2019_day7.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day7Tests.Part1
{
    [TestClass()]
    public class GravityAssistDay7Part1Tests
    {
        #region dummy
        [TestMethod()]
        public void Dummy()
        {// Arrange
            var input = new int[]
            {
                3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99
            };

            // Act
            var result = GravityAssistPart2.ProcessWithUserInput(input, new int[] { 9 });

            // Arrange
            result.Output.ShouldBe(new List<int> { 1001 });
        }

        #endregion
    }
}
