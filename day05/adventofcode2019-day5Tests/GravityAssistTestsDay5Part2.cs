using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day5.Part2;

namespace adventofcode2019_day5.Tests
{

    [TestClass()]
    public class GravityAssistTestsDay5Part2
    {
        #region Examples

        [TestMethod()]
        public void ExampleDay5Part1_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1002,4,3,4,33,
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(1002, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(4, result.Code(1), "position 1 is unexpected");
            Assert.AreEqual(3, result.Code(2), "position 2 is unexpected");
            Assert.AreEqual(4, result.Code(3), "position 3 is unexpected");
            Assert.AreEqual(99, result.Code(4), "position 4 is unexpected");
        }

        [TestMethod()]
        public void ExampleDay5Part1_Test02()
        {
            // Arrange
            var input = new int[]
            {
                1101,100,-1,4,0,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(1101, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(100, result.Code(1), "position 1 is unexpected");
            Assert.AreEqual(-1, result.Code(2), "position 2 is unexpected");
            Assert.AreEqual(4, result.Code(3), "position 3 is unexpected");
            Assert.AreEqual(99, result.Code(4), "position 4 is unexpected");
        }

        #endregion

        #region input
        [TestMethod()]
        public void Input_Test01()
        {
            // Arrange
            var input = new int[]
            {
                3,50,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(4, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(3, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(1, result.Code(50), "position 1 is unexpected");
            Assert.AreEqual(@"HALT
", result.Output.ToString());
        }

        #endregion

        #region output
        [TestMethod()]
        public void Output_Test01()
        {
            // Arrange
            var input = new int[]
            {
                4,0,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(3, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(4, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(@"4
HALT
", result.Output.ToString());
        }

        [TestMethod()]
        public void Output_Test02()
        {
            // Arrange
            var input = new int[]
            {
                104,0,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(3, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(104, result.Code(0), "position 0 is unexpected");
            Assert.AreEqual(0, result.Code(1), "position 1 is unexpected");
            Assert.AreEqual(@"0
HALT
", result.Output.ToString());
        }

        #endregion

        #region Opcode 5 (jump-if-true)

        [TestMethod()]
        public void JumpIfTrue_NoJump_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1105,0,200,
                4,0,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(6, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1105, result.Code(0));
            Assert.AreEqual(0, result.Code(1));
            Assert.AreEqual(200, result.Code(2));
            Assert.AreEqual(4, result.Code(3));
            Assert.AreEqual(0, result.Code(4));
            Assert.AreEqual(99, result.Code(5));
            Assert.AreEqual(@"1105
HALT
", result.Output.ToString());
        }

        [TestMethod()]
        public void JumpIfTrue_Jump_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1105,1,5,
                1104,100,
                1104,200,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(8, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(@"200
HALT
", result.Output.ToString());
        }

        #endregion

        #region Opcode 6 (jump-if-false)

        [TestMethod()]
        public void JumpIfFalse_NoJump_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1106,1,200,
                104,4,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(6, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(@"4
HALT
", result.Output.ToString());
        }

        [TestMethod()]
        public void JumpIfFalse_Jump_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1106,0,5,
                4,0,
                4,7,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(8, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(@"99
HALT
", result.Output.ToString());
        }

        #endregion

        #region Opcode 7 (less than)

        [TestMethod()]
        public void LessThan_Set_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1107,1,2,2,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(5, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1107, result.Code(0));
            Assert.AreEqual(1, result.Code(1));
            Assert.AreEqual(1, result.Code(2));
            Assert.AreEqual(2, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
        }

        [TestMethod()]
        public void LessThan_Set_Test02()
        {
            // Arrange
            var input = new int[]
            {
                1107,200,300,5,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(6, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1107, result.Code(0));
            Assert.AreEqual(200, result.Code(1));
            Assert.AreEqual(300, result.Code(2));
            Assert.AreEqual(5, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
            Assert.AreEqual(1, result.Code(5));
        }

        [TestMethod()]
        public void LessThan_Reset_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1107,3,2,2,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(5, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1107, result.Code(0));
            Assert.AreEqual(3, result.Code(1));
            Assert.AreEqual(0, result.Code(2));
            Assert.AreEqual(2, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
        }

        [TestMethod()]
        public void LessThan_Reset_Test02()
        {
            // Arrange
            var input = new int[]
            {
                1107,400,300,5,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(6, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1107, result.Code(0));
            Assert.AreEqual(400, result.Code(1));
            Assert.AreEqual(300, result.Code(2));
            Assert.AreEqual(5, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
            Assert.AreEqual(0, result.Code(5));
        }

        [TestMethod()]
        public void LessThan_Reset_OnEqueal_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1107,400,400,5,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(6, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1107, result.Code(0));
            Assert.AreEqual(400, result.Code(1));
            Assert.AreEqual(400, result.Code(2));
            Assert.AreEqual(5, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
            Assert.AreEqual(0, result.Code(5));
        }
        #endregion

        #region Opcode 8 (equal)

        [TestMethod()]
        public void Equal_Set_Test01()
        {
            // Arrange
            var input = new int[]
            {
                1108,10,10,2,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(5, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1108, result.Code(0));
            Assert.AreEqual(10, result.Code(1));
            Assert.AreEqual(1, result.Code(2));
            Assert.AreEqual(2, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
        }

        [TestMethod()]
        public void Equal_Set_Test02()
        {
            // Arrange
            var input = new int[]
            {
                0108,300,1,5,
                99,
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(6, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(0108, result.Code(0));
            Assert.AreEqual(300, result.Code(1));
            Assert.AreEqual(1, result.Code(2));
            Assert.AreEqual(5, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
            Assert.AreEqual(1, result.Code(5));
        }

        [TestMethod()]
        public void Equal_NotEqual_Reset_Test01()
        {
            // Arrange
            var input = new int[]
            {
                8,0,2,2,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(5, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(8, result.Code(0));
            Assert.AreEqual(0, result.Code(1));
            Assert.AreEqual(0, result.Code(2));
            Assert.AreEqual(2, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
        }

        [TestMethod()]
        public void Equal_NotEqual_Reset_Test02()
        {
            // Arrange
            var input = new int[]
            {
                1108,4,2,2,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(5, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1108, result.Code(0));
            Assert.AreEqual(4, result.Code(1));
            Assert.AreEqual(0, result.Code(2));
            Assert.AreEqual(2, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
        }

        [TestMethod()]
        public void Equal_NotEqual_Reset_Test03()
        {// Arrange
            var input = new int[]
            {
                1008,4,77,2,
                99
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(5, result.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(1008, result.Code(0));
            Assert.AreEqual(4, result.Code(1));
            Assert.AreEqual(0, result.Code(2));
            Assert.AreEqual(2, result.Code(3));
            Assert.AreEqual(99, result.Code(4));
        }

        #endregion


        #region Puzzle
        [TestMethod()]
        public void Puzzle()
        {
            // Arrange
            var input = new int[]
            {
                3,225,1,225,6,6,1100,1,238,225,104,0,1102,91,92,225,1102,85,13,225,1,47,17,224,101,-176,224,224,4,224,1002,223,8,223,1001,224,7,224,1,223,224,223,1102,79,43,225,1102,91,79,225,1101,94,61,225,1002,99,42,224,1001,224,-1890,224,4,224,1002,223,8,223,1001,224,6,224,1,224,223,223,102,77,52,224,1001,224,-4697,224,4,224,102,8,223,223,1001,224,7,224,1,224,223,223,1101,45,47,225,1001,43,93,224,1001,224,-172,224,4,224,102,8,223,223,1001,224,1,224,1,224,223,223,1102,53,88,225,1101,64,75,225,2,14,129,224,101,-5888,224,224,4,224,102,8,223,223,101,6,224,224,1,223,224,223,101,60,126,224,101,-148,224,224,4,224,1002,223,8,223,1001,224,2,224,1,224,223,223,1102,82,56,224,1001,224,-4592,224,4,224,1002,223,8,223,101,4,224,224,1,224,223,223,1101,22,82,224,1001,224,-104,224,4,224,1002,223,8,223,101,4,224,224,1,223,224,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,8,226,677,224,102,2,223,223,1005,224,329,1001,223,1,223,1007,226,226,224,1002,223,2,223,1006,224,344,101,1,223,223,108,226,226,224,1002,223,2,223,1006,224,359,1001,223,1,223,107,226,677,224,102,2,223,223,1006,224,374,101,1,223,223,8,677,677,224,102,2,223,223,1006,224,389,1001,223,1,223,1008,226,677,224,1002,223,2,223,1006,224,404,101,1,223,223,7,677,677,224,1002,223,2,223,1005,224,419,101,1,223,223,1108,226,677,224,1002,223,2,223,1005,224,434,101,1,223,223,1108,226,226,224,102,2,223,223,1005,224,449,1001,223,1,223,107,226,226,224,102,2,223,223,1005,224,464,101,1,223,223,1007,677,677,224,102,2,223,223,1006,224,479,101,1,223,223,1007,226,677,224,102,2,223,223,1005,224,494,1001,223,1,223,1008,226,226,224,1002,223,2,223,1005,224,509,1001,223,1,223,1108,677,226,224,1002,223,2,223,1006,224,524,1001,223,1,223,108,677,677,224,1002,223,2,223,1005,224,539,101,1,223,223,108,226,677,224,1002,223,2,223,1005,224,554,101,1,223,223,1008,677,677,224,1002,223,2,223,1006,224,569,1001,223,1,223,1107,677,677,224,102,2,223,223,1005,224,584,1001,223,1,223,7,677,226,224,102,2,223,223,1005,224,599,1001,223,1,223,8,677,226,224,1002,223,2,223,1005,224,614,1001,223,1,223,7,226,677,224,1002,223,2,223,1006,224,629,101,1,223,223,1107,677,226,224,1002,223,2,223,1005,224,644,1001,223,1,223,1107,226,677,224,102,2,223,223,1006,224,659,1001,223,1,223,107,677,677,224,1002,223,2,223,1005,224,674,101,1,223,223,4,223,99,226
            };

            // Act
            var result = GravityAssistPart2.Process(input);

            // Arrange
            Assert.AreEqual(@"0
0
0
0
0
0
0
0
0
16489636
HALT
", result.Output.ToString());
        }

        #endregion
    }

}