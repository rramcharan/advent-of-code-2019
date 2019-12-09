using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace adventofcode2019_day7.Day5
{
    public class GravityAssistPart2
    {
        private readonly Dictionary<int, int> _memory;
        private readonly int[] _userInput;
        private int _instructionPointer;
        public List<int> Output = new List<int>();
        public StringBuilder OutputConsole = new StringBuilder();

        private GravityAssistPart2(int[] initialState, int[] userInput)
        {
            _memory = new Dictionary<int, int>();
            _userInput = userInput;
            if (initialState != null)
            {
                for (int index = 0; index < initialState.Length; index++)
                    _memory[index] = initialState[index];
            }
            _instructionPointer = 0;
        }

        public Dictionary<int, int> Codes => _memory;

        public int Code(int address) => _memory[address];
        public int Noun
        {
            get => _memory[1];
            set { _memory[1] = value; }
        }
        public int Verb
        {
            get => _memory[2];
            set { _memory[2] = value; }
        }

        public static GravityAssistPart2 Process(params int[] initialState)
        {
            return ProcessWithUserInput(initialState, null);
        }
        public static GravityAssistPart2 ProcessWithUserInput(int[] initialState, int[] userInput)
        {
            var result = new GravityAssistPart2(initialState, userInput);
            result.ProcessInstructions();
            return result;
        }

        public static GravityAssistPart2 RestoreGravityAsistAndProcessCodes(int noun, int verb, params int[] initialState)
        {
            var result = new GravityAssistPart2(initialState, null);
            result.RestoreGravityAsist(noun, verb);
            result.ProcessInstructions();
            return result;
        }

        private void RestoreGravityAsist(int noun, int verb)
        {
            Noun = noun;
            Verb = verb;
        }

        private void ProcessInstructions()
        {
            while (ProcessNextInstruction())
            {
            }

        }

        private bool ProcessNextInstruction()
        {
            var instructionPointer = _instructionPointer;
            var instruction = Instruction.Parse(_memory[instructionPointer]);
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
                    var userInput = NextUserInput();
                    SetValue(userInput, instructionPointer + 1, instruction.ModeParam1);
                    InstructionPointerIncrement(2);
                    return true;
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
                    //SendToOutput("HALT");
                    return false;
            }

            return false;
        }

        private int _userinputPointer = 0;
        private int NextUserInput()
        {
            if (_userInput == null)
                throw new Exception("No user input specified!");
            if (_userinputPointer >= _userInput.Length)
                throw new Exception($"No user input available at {_userinputPointer}!");

            var value = _userInput[_userinputPointer];
            _userinputPointer++;

            return value;
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
            var address = _memory[from];
            var value = mode == ParameterMode.Immediate ? address : _memory[address];
            return value;
        }

        private void SetValue(int value, int at, ParameterMode mode)
        {
            if (mode == ParameterMode.Immediate)
                throw new Exception("Parameter should be a Position mode parameter");

            var address = _memory[at];
            _memory[address] = value;
        }

        private void SendToOutput(int number)
        {
            Output.Add(number);
            //SendToOutput(number.ToString(CultureInfo.InvariantCulture));
        }
        //private void SendToOutput(string text)
        //{
        //    OutputConsole.AppendLine(text);
        //    Console.WriteLine(text);
        //}
    }
}
