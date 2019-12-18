using adventofcode2019_day11.Day11Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace adventofcode2019_day11Tests.Day11Part1
{
    [TestClass()]
    public class InputTests
    {
        #region input correct order

        [TestMethod()]
        public void Input_NoInput_Test01()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };

            // Act
            var computer = IntCodeComputer.Create(intCodes);

            // Arrange
            computer.NextUserInputAvailable().ShouldBeFalse();
        }

        [TestMethod()]
        public void Input_OneInput_Test01()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };
            var computer = IntCodeComputer.Create(intCodes);

            // Act
            computer.AddInput(20);

            // Arrange
            computer.NextUserInputAvailable().ShouldBeTrue();
        }

        [TestMethod()]
        public void Input_OneInput_Test02()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };
            var computer = IntCodeComputer.Create(intCodes);
            computer.AddInput(20);

            // Act

            // Arrange
            computer.NextUserInputAvailable().ShouldBeTrue();
            computer.NextUserInput().ShouldBe(20);
            computer.NextUserInputAvailable().ShouldBeFalse();
        }

        [TestMethod()]
        public void Input_MulitpleInput_Test01()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };
            var computer = IntCodeComputer.Create(intCodes);
            computer.AddInput(20);
            computer.AddInput(30);
            computer.AddInput(40);

            // Act

            // Arrange
            computer.NextUserInputAvailable().ShouldBeTrue();
            computer.NextUserInput().ShouldBe(20);
            computer.NextUserInput().ShouldBe(30);
            computer.NextUserInput().ShouldBe(40);
            computer.NextUserInputAvailable().ShouldBeFalse();
        }

        [TestMethod()]
        public void Input_MulitpleInput_Test02()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };
            var computer = IntCodeComputer.Create("aa", intCodes, new long[] { 20, 30, 40 });

            // Act

            // Arrange
            computer.NextUserInputAvailable().ShouldBeTrue();
            computer.NextUserInput().ShouldBe(20);
            computer.NextUserInput().ShouldBe(30);
            computer.NextUserInput().ShouldBe(40);
            computer.NextUserInputAvailable().ShouldBeFalse();
        }

        [TestMethod()]
        public void Input_MulitpleInput_Test03()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };
            var computer = IntCodeComputer.Create("aa", intCodes, new long[] { 20, 30, 40 });

            // Act
            computer.AddInput(50);

            // Arrange
            computer.NextUserInputAvailable().ShouldBeTrue();
            computer.NextUserInput().ShouldBe(20);
            computer.NextUserInput().ShouldBe(30);
            computer.NextUserInput().ShouldBe(40);
            computer.NextUserInput().ShouldBe(50);
            computer.NextUserInputAvailable().ShouldBeFalse();
        }
        #endregion


        #region input
        [TestMethod()]
        public void Input_GiveAllInputToCumpterDuringProcessRequest_Test01()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };
            var computer = IntCodeComputer.Create(intCodes);

            // Act
            computer.ProcessWithUserInput(new long[] { 1 });

            // Arrange
            computer.IsHalted.ShouldBeTrue();
            Assert.AreEqual(4, computer.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(3, computer.Code(0), "position 0 is unexpected");
            Assert.AreEqual(1, computer.Code(50), "position 1 is unexpected");
            computer.Output.Count.ShouldBe(0);
        }

        #endregion

        #region Process code while input is specified later
        [TestMethod()]
        public void Input_AfterWaitingForInput_Test01()
        {
            // Arrange
            var intCodes = new long[]
            {
                3,50,
                99
            };
            var computer = IntCodeComputer.Create(intCodes);

            // Act
            computer.Process();
            computer.IsWaitingForInput.ShouldBeTrue();
            computer.AddInput(1);
            computer.Process();

            // Arrange
            computer.IsHalted.ShouldBeTrue();
            Assert.AreEqual(4, computer.Codes.Keys.Count, "unexpected number of elements");
            Assert.AreEqual(3, computer.Code(0), "position 0 is unexpected");
            Assert.AreEqual(1, computer.Code(50), "position 1 is unexpected");
            computer.Output.Count.ShouldBe(0);
        }

        #endregion

    }
}
