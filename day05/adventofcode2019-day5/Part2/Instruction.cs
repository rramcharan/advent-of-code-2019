using System;

namespace adventofcode2019_day5.Part2
{
    public class Instruction
    {
        private Instruction() { }

        public Opcode Opcode { get; set; }
        public ParameterMode ModeParam1 { get; set; }
        public ParameterMode ModeParam2 { get; set; }
        public ParameterMode ModeParam3 { get; set; }
        public static Instruction Parse(int code)
        {
            var result = new Instruction
            {
                Opcode = SetOpcode(code % 100),
                ModeParam1 = GetParameterMode(code / 100 % 10),
                ModeParam2 = GetParameterMode(code / 1000 % 10),
                ModeParam3 = GetParameterMode(code / 10000 % 10)
            };

            return result;
        }

        private static Opcode SetOpcode(int code)
        {
            switch (code)
            {
                case 1: return Opcode.Add;
                case 2: return Opcode.Multiply;
                case 3: return Opcode.ReadInput;
                case 4: return Opcode.WriteOutput;
                case 5: return Opcode.JumpIfTrue;
                case 6: return Opcode.JumpIfFalse;
                case 7: return Opcode.SetResetIfLessThan;
                case 8: return Opcode.SetResetIfEquals;
                case 99: return Opcode.Halt;
                default: throw new ArgumentException($"Unknown opcode {code}", nameof(code));
            }
        }

        private static ParameterMode GetParameterMode(int number)
        {
            if (number == 0) return ParameterMode.Position;
            if (number == 1) return ParameterMode.Immediate;

            throw new ArgumentException($"Number '{number}' is not supported", nameof(number));
        }
    }
}
