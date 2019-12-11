using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace adventofcode2019_day9.Part1
{
    public class IntCodeComputer
    {
        public string Name { get; private set; }
        private Dictionary<long, long> _intCodes;
        private Queue<long> _userInput;
        private long _instructionPointer;
        public List<long> Output = new List<long>();
        public StringBuilder OutputConsole = new StringBuilder();
        public long RelativeBase { get; private set; }

        #region Ctor...

        private IntCodeComputer(long[] intCodes) : this(intCodes, null)
        {
        }

        private IntCodeComputer(long[] intCodes, long[] userInput)
        {
            Name = "?";
            InitIntCodes(intCodes);
            InitInput(userInput);
            _instructionPointer = 0;
            RelativeBase = 0;
        }
        #endregion

        #region Init...

        private void InitIntCodes(long[] intCodes)
        {
            _intCodes = new Dictionary<long, long>();
            if (intCodes != null)
            {
                for (long index = 0; index < intCodes.Length; index++)
                    _intCodes[index] = intCodes[index];
            }
        }

        private void InitInput(long[] userInput)
        {
            _userInput = new Queue<long>();
            SetInput(userInput);
        }

        private void SetInput(long[] userInput)
        {
            if (_userInput.Count > 0)
                throw new Exception("Computer has input arguments queued. Can't re-initialise!");

            if (userInput == null) return;
            if (userInput.Length == 0) return;

            foreach (var input in userInput)
                AddInput(input);
        }

        public void AddInput(long input)
        {
            _userInput.Enqueue(input);
        }
        #endregion

        public bool IsHalted { get; private set; }
        public bool IsWaitingForInput { get; private set; }

        public Dictionary<long, long> Codes => _intCodes;

        public long Code(long address) => _intCodes[address];
        public long Noun
        {
            get => _intCodes[1];
            set { _intCodes[1] = value; }
        }
        public long Verb
        {
            get => _intCodes[2];
            set { _intCodes[2] = value; }
        }

        public static IntCodeComputer Create(string name, long[] intCodes, long[] userInput)
        {
            var computer = new IntCodeComputer(intCodes, userInput);
            computer.Name = name;

            return computer;
        }
        public static IntCodeComputer Create(params long[] intCodes)
        {
            return new IntCodeComputer(intCodes);

        }
        public static IntCodeComputer Process(params long[] intCodes)
        {
            return ProcessWithUserInput(intCodes, null);
        }
        public static IntCodeComputer ProcessWithUserInput(long[] intCodes, long[] userInput)
        {
            var result = new IntCodeComputer(intCodes, userInput);
            result.ProcessInstructions();
            return result;
        }

        public static IntCodeComputer RestoreGravityAsistAndProcessCodes(long noun, long verb, params long[] initialState)
        {
            var result = new IntCodeComputer(initialState, null);
            result.RestoreGravityAsist(noun, verb);
            result.ProcessInstructions();
            return result;
        }

        public void ProcessWithUserInput(long[] userInput)
        {
            InitInput(userInput);
            ProcessInstructions();
        }

        public void Process()
        {
            Console.WriteLine($"Run code on {Name}");
            Output.Clear();
            ProcessInstructions();
        }


        #region private methods
        private void RestoreGravityAsist(long noun, long verb)
        {
            Noun = noun;
            Verb = verb;
        }

        private void ProcessInstructions()
        {
            IsWaitingForInput = false;
            while (ProcessNextInstruction())
            {
            }

        }

        private bool ProcessNextInstruction()
        {
            var instructionPointer = _instructionPointer;
            var instruction = Instruction.Parse(_intCodes[instructionPointer]);
            var opCode = instruction.Opcode;

            switch (opCode)
            {
                case Opcode.Add:
                case Opcode.Multiply:
                    var value1 = GetValue(instructionPointer + 1, instruction.ModeParam1);
                    var value2 = GetValue(instructionPointer + 2, instruction.ModeParam2);

                    var result = opCode == Opcode.Add
                        ? value1 + value2
                        : opCode == Opcode.Multiply
                          ? value1 * value2
                          : throw new Exception($"Invalid opCode: '{opCode}'");

                    SetValue(result, instructionPointer + 3, instruction.ModeParam3);
                    InstructionPointerIncrement(4);
                    return true;
                case Opcode.ReadInput:
                    if (NextUserInputAvailable())
                    {
                        var userInput = NextUserInput();
                        SetValue(userInput, instructionPointer + 1, instruction.ModeParam1);
                        InstructionPointerIncrement(2);
                        return true;
                    }
                    IsWaitingForInput = true;
                    return false;
                case Opcode.WriteOutput:
                    SendToOutput(GetValue(instructionPointer + 1, instruction.ModeParam1));
                    InstructionPointerIncrement(2);
                    return true;
                case Opcode.JumpIfTrue:
                    JumpIfTrue(instructionPointer, instruction);
                    return true;
                case Opcode.JumpIfFalse:
                    JumpIfFalse(instructionPointer, instruction);
                    return true;
                case Opcode.SetResetIfLessThan:
                    SetResetIfLessThan(instructionPointer, instruction);
                    return true;
                case Opcode.SetResetIfEquals:
                    SetResetIfEquals(instructionPointer, instruction);
                    return true;
                case Opcode.SetRelativeBase:
                    SetRelativeBase(instructionPointer, instruction);
                    return true;
                case Opcode.Halt:
                    IsHalted = true;
                    return false;
            }

            return false;
        }

        private void SetRelativeBase(long instructionPointer, Instruction instruction)
        {
            var value1 = GetValue(instructionPointer + 1, instruction.ModeParam1);
            RelativeBase += value1;

            InstructionPointerIncrement(2);
        }

        public bool NextUserInputAvailable()
        {
            return _userInput.Count > 0;
        }
        public long NextUserInput()
        {
            var input = _userInput.Dequeue();
            return input;
        }

        private void JumpIfTrue(long instructionPointer, Instruction instruction)
        {
            var value1 = GetValue(instructionPointer + 1, instruction.ModeParam1);
            var value2 = GetValue(instructionPointer + 2, instruction.ModeParam2);
            if (value1 == 0)
            {
                InstructionPointerIncrement(3);
            }
            else
            {
                // Jump
                SetInstructionPointer(value2);
            }
        }

        private void JumpIfFalse(long instructionPointer, Instruction instruction)
        {
            var value1 = GetValue(instructionPointer + 1, instruction.ModeParam1);
            var value2 = GetValue(instructionPointer + 2, instruction.ModeParam2);
            if (value1 == 0)
            {
                // Jump
                SetInstructionPointer(value2);
            }
            else
            {
                InstructionPointerIncrement(3);
            }
        }

        private void SetResetIfLessThan(long instructionPointer, Instruction instruction)
        {
            var value1 = GetValue(instructionPointer + 1, instruction.ModeParam1);
            var value2 = GetValue(instructionPointer + 2, instruction.ModeParam2);
            if (value1 < value2)
            {
                SetValue(1, instructionPointer + 3, instruction.ModeParam3);
            }
            else
            {
                SetValue(0, instructionPointer + 3, instruction.ModeParam3);
            }

            InstructionPointerIncrement(4);
        }

        private void SetResetIfEquals(long instructionPointer, Instruction instruction)
        {
            var value1 = GetValue(instructionPointer + 1, instruction.ModeParam1);
            var value2 = GetValue(instructionPointer + 2, instruction.ModeParam2);
            if (value1 == value2)
            {
                SetValue(1, instructionPointer + 3, instruction.ModeParam3);
            }
            else
            {
                SetValue(0, instructionPointer + 3, instruction.ModeParam3);
            }

            InstructionPointerIncrement(4);
        }

        private void InstructionPointerIncrement(long value)
        {
            SetInstructionPointer(_instructionPointer + value);
        }

        private void SetInstructionPointer(long value)
        {
            _instructionPointer = value;
        }

        private long GetValue(long from, ParameterMode mode)
        {
            var address = _intCodes[from];
            switch (mode)
            {
                case ParameterMode.Immediate:
                    return address;
                case ParameterMode.Position:
                    if (_intCodes.ContainsKey(address))
                        return _intCodes[address];
                    return 0;
                case ParameterMode.Relative:
                    var newAddress = RelativeBase + address;
                    return _intCodes[newAddress];
                default:
                    throw new Exception($"Not implemented mode: '{mode}'");
            }
        }

        private void SetValue(long value, long at, ParameterMode mode)
        {
            long address;
            switch (mode)
            {
                case ParameterMode.Position:
                    address = _intCodes[at];
                    break;
                case ParameterMode.Relative:
                    address = _intCodes[at] + RelativeBase;
                    break;
                default:
                    throw new Exception($"Parameter mode '{mode}' is not supported.");
            }

            _intCodes[address] = value;
        }

        private void SendToOutput(long number)
        {
            Output.Add(number);
            //SendToOutput(number.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}
