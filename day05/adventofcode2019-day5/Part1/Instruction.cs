using System;

namespace adventofcode2019_day5.Part1
{
    public class Instruction
    {
        private Instruction() { }

        public int Opcode { get; set; }
        public ParameterMode ModeParam1 { get; set; }
        public ParameterMode ModeParam2 { get; set; }
        public ParameterMode ModeParam3 { get; set; }
        public static Instruction Parse(int code)
        {
            var result = new Instruction();
            result.Opcode = code % 100;
            result.ModeParam1 = GetParameterMode(code / 100 % 10);
            result.ModeParam2 = GetParameterMode(code / 1000 % 10);
            result.ModeParam3 = GetParameterMode(code / 10000 % 10);

            return result;
        }

        private static ParameterMode GetParameterMode(int number)
        {
            if (number == 0) return ParameterMode.Position;
            if (number == 1) return ParameterMode.Immediate;

            throw new ArgumentException($"Number '{number}' is not supported", nameof(number));
        }
    }
}
