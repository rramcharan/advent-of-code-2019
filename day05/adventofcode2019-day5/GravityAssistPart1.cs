using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day5
{
    public class GravityAssistPart1
    {
        private readonly Dictionary<int,int> _memory;
        private int _instructionPointer;
        public StringBuilder Output = new StringBuilder();

        private GravityAssistPart1(params int[] initialState)
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

        public static GravityAssistPart1 Process(params int[] initialState)
        {
            var result = new GravityAssistPart1(initialState);
            result.ProcessInstructions();
            return result;
        }

        public static GravityAssistPart1 RestoreGravityAsistAndProcessCodes(int noun, int verb, params int[] initialState)
        {
            var result = new GravityAssistPart1(initialState);
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

        private readonly int OpcodeAdd = 1;
        private readonly int OpcodeMultiply = 2;
        private readonly int OpcodeReadInput = 3;
        private readonly int OpcodeWriteOutput = 4;

        private bool ProcessNextInstruction()
        {
            var instructionPointer = _instructionPointer;
            var instruction = Instruction.Parse(_memory[instructionPointer]);
            var opCode = instruction.Opcode;
            if (opCode == 99)
            {
                SendToOutput("HALT");
                return false;
            }
            if (opCode == OpcodeAdd || opCode == OpcodeMultiply)
            {
                var address1 = _memory[instructionPointer + 1];
                var address2 = _memory[instructionPointer + 2];
                var address3 = _memory[instructionPointer + 3];

                var parameter1 = instruction.ModeParam1 == ParameterMode.Immediate ? address1 : _memory[address1];
                var parameter2 = instruction.ModeParam2 == ParameterMode.Immediate ? address2 : _memory[address2];
                var result = opCode == 1
                    ? parameter1 + parameter2
                    : opCode == 2
                      ? parameter1 * parameter2
                      : throw new Exception($"Invalid opCode: '{opCode}'");

                if (instruction.ModeParam3 == ParameterMode.Immediate)
                    throw new Exception("Third parameter should be a Position mode parameter");

                _memory[address3] = result;

                _instructionPointer += 4;
                return true;
            }
            else if (opCode == OpcodeReadInput)
            {
                var address1 = _memory[instructionPointer + 1];
                if (instruction.ModeParam1 == ParameterMode.Immediate)
                    throw new Exception("Opcode=3: First parameter should be a Position mode parameter");
                _memory[address1] = 1;

                _instructionPointer += 2;
                return true;
            }
            else if (opCode == OpcodeWriteOutput)
            {
                var address1 = _memory[instructionPointer + 1];
                var parameter1 = instruction.ModeParam1 == ParameterMode.Immediate ? address1 : _memory[address1];
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
