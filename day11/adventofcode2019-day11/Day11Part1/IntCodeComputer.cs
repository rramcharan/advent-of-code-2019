using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2019_day11.Day11Part1
{
    public class IntCodeComputer
    {
        public string Name { get; private set; }
        private Dictionary<int, int> _intCodes;
        private Queue<int> _userInput;
        private int _instructionPointer;
        public List<int> Output = new List<int>();
        public StringBuilder OutputConsole = new StringBuilder();

        #region Ctor...

        private IntCodeComputer(int[] intCodes) : this(intCodes, null)
        {
        }

        private IntCodeComputer(int[] intCodes, int[] userInput)
        {
            Name = "?";
            InitIntCodes(intCodes);
            InitInput(userInput);
            _instructionPointer = 0;
        }
        #endregion

        #region Init...

        private void InitIntCodes(int[] intCodes)
        {
            _intCodes = new Dictionary<int, int>();
            if (intCodes != null)
            {
                for (int index = 0; index < intCodes.Length; index++)
                    _intCodes[index] = intCodes[index];
            }
        }

        private void InitInput(int[] userInput)
        {
            _userInput = new Queue<int>();
            SetInput(userInput);
        }

        private void SetInput(int[] userInput)
        {
            if (_userInput.Count > 0)
                throw new Exception("Computer has input arguments queued. Can't re-initialise!");

            if (userInput == null) return;
            if (userInput.Length == 0) return;

            foreach (var input in userInput)
                AddInput(input);
        }

        public void AddInput(int input)
        {
            _userInput.Enqueue(input);
        }
        #endregion

        public bool IsHalted { get; private set; }
        public bool IsWaitingForInput { get; private set; }

        public Dictionary<int, int> Codes => _intCodes;

        public int Code(int address) => _intCodes[address];
        public int Noun
        {
            get => _intCodes[1];
            set { _intCodes[1] = value; }
        }
        public int Verb
        {
            get => _intCodes[2];
            set { _intCodes[2] = value; }
        }

        public static IntCodeComputer Create(string name, int[] intCodes, int[] userInput)
        {
            var computer = new IntCodeComputer(intCodes, userInput);
            computer.Name = name;

            return computer;
        }
        public static IntCodeComputer Create(params int[] intCodes)
        {
            return new IntCodeComputer(intCodes);

        }
        public static IntCodeComputer Process(params int[] intCodes)
        {
            return ProcessWithUserInput(intCodes, null);
        }
        public static IntCodeComputer ProcessWithUserInput(int[] intCodes, int[] userInput)
        {
            var result = new IntCodeComputer(intCodes, userInput);
            result.ProcessInstructions();
            return result;
        }

        public static IntCodeComputer RestoreGravityAsistAndProcessCodes(int noun, int verb, params int[] initialState)
        {
            var result = new IntCodeComputer(initialState, null);
            result.RestoreGravityAsist(noun, verb);
            result.ProcessInstructions();
            return result;
        }

        public void ProcessWithUserInput(int[] userInput)
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
        private void RestoreGravityAsist(int noun, int verb)
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
                case Opcode.Halt:
                    IsHalted = true;
                    return false;
            }

            return false;
        }

        public bool NextUserInputAvailable()
        {
            return _userInput.Count > 0;
        }
        public int NextUserInput()
        {
            var input = _userInput.Dequeue();
            return input;
        }

        private void JumpIfTrue(int instructionPointer, Instruction instruction)
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

        private void JumpIfFalse(int instructionPointer, Instruction instruction)
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

        private void SetResetIfLessThan(int instructionPointer, Instruction instruction)
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

        private void SetResetIfEquals(int instructionPointer, Instruction instruction)
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

        private void InstructionPointerIncrement(int value)
        {
            SetInstructionPointer(_instructionPointer + value);
        }

        private void SetInstructionPointer(int value)
        {
            _instructionPointer = value;
        }

        private int GetValue(int from, ParameterMode mode)
        {
            var address = _intCodes[from];
            var value = mode == ParameterMode.Immediate ? address : _intCodes[address];
            return value;
        }

        private void SetValue(int value, int at, ParameterMode mode)
        {
            if (mode == ParameterMode.Immediate)
                throw new Exception("Parameter should be a Position mode parameter");

            var address = _intCodes[at];
            _intCodes[address] = value;
        }

        private void SendToOutput(int number)
        {
            Output.Add(number);
            //SendToOutput(number.ToString(CultureInfo.InvariantCulture));
        }

        #endregion
    }
}
