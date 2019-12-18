namespace adventofcode2019_day11.Day11Part1
{
    public enum Opcode : int
    {
        Add = 1,
        Multiply = 2,
        ReadInput = 3,
        WriteOutput = 4,
        /// <summary>
        /// Opcode 5 is jump-if-true: if the first parameter is non-zero, it sets the instruction pointer to the value from the second parameter. Otherwise, it does nothing
        /// </summary>
        JumpIfTrue = 5,
        /// <summary>
        /// Opcode 6 is jump-if-false: if the first parameter is zero, it sets the instruction pointer to the value from the second parameter. Otherwise, it does nothing.
        /// </summary>
        JumpIfFalse = 6,
        /// <summary>
        /// Opcode 7 is less than: if the first parameter is less than the second parameter, it stores 1 in the position given by the third parameter. Otherwise, it stores 0
        /// </summary>
        SetResetIfLessThan = 7,
        /// <summary>
        /// Opcode 8 is equals: if the first parameter is equal to the second parameter, it stores 1 in the position given by the third parameter. Otherwise, it stores 0
        /// </summary>
        SetResetIfEquals = 8,
        /// <summary>
        /// Set the relative base
        /// </summary>
        SetRelativeBase = 9,
        /// <summary>
        /// End execution
        /// </summary>
        Halt = 99,
    }
}
