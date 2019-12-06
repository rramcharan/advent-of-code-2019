using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace adventofcode2019_day5.Part2
{
    public class GravityAssistPart2
    {
        private readonly Dictionary<int, int> _memory;
        private int _instructionPointer;
        public StringBuilder Output = new StringBuilder();

        private GravityAssistPart2(params int[] initialState)
        {
            _memory = new Dictionary<int, int>();
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
            var result = new GravityAssistPart2(initialState);
            result.ProcessInstructions();
            return result;
        }

        public static GravityAssistPart2 RestoreGravityAsistAndProcessCodes(int noun, int verb, params int[] initialState)
        {
            var result = new GravityAssistPart2(initialState);
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
            if (opCode == Opcode.Halt)
            {
                SendToOutput("HALT");
                return false;
            }
            int address1;
            int address2;
            int address3;
            int parameter1;
            int parameter2;
            switch (opCode)
            {
                case Opcode.OpcodeAdd:
                case Opcode.OpcodeMultiply:
                    address1 = _memory[instructionPointer + 1];
                    address2 = _memory[instructionPointer + 2];
                    address3 = _memory[instructionPointer + 3];

                    parameter1 = instruction.ModeParam1 == ParameterMode.Immediate ? address1 : _memory[address1];
                    parameter2 = instruction.ModeParam2 == ParameterMode.Immediate ? address2 : _memory[address2];
                    var result = opCode == Opcode.OpcodeAdd
                        ? parameter1 + parameter2
                        : opCode == Opcode.OpcodeMultiply
                          ? parameter1 * parameter2
                          : throw new Exception($"Invalid opCode: '{opCode}'");

                    if (instruction.ModeParam3 == ParameterMode.Immediate)
                        throw new Exception("Third parameter should be a Position mode parameter");

                    _memory[address3] = result;

                    _instructionPointer += 4;
                    return true;
                case Opcode.OpcodeReadInput:
                    address1 = _memory[instructionPointer + 1];
                    if (instruction.ModeParam1 == ParameterMode.Immediate)
                        throw new Exception("Opcode=3: First parameter should be a Position mode parameter");
                    _memory[address1] = 1;

                    _instructionPointer += 2;
                    return true;
                case Opcode.OpcodeWriteOutput:
                    address1 = _memory[instructionPointer + 1];
                    parameter1 = instruction.ModeParam1 == ParameterMode.Immediate ? address1 : _memory[address1];
                    SendToOutput(parameter1);

                    _instructionPointer += 2;
                    return true;
            }

            return false;
        }

        private void SendToOutput(int number)
        {
            SendToOutput(number.ToString(CultureInfo.InvariantCulture));
        }
        private void SendToOutput(string text)
        {
            Output.AppendLine(text);
            Console.WriteLine(text);
        }
    }
}
