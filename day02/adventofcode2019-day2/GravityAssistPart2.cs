using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day2
{
    public class GravityAssistPart2
    {
        private readonly int[] _memory;

        private GravityAssistPart2(params int[] initialState)
        {
            _memory = initialState;
        }

        public int[] Codes => _memory;

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
            var instructionPointer = 0;
            while (ProcessInstruction(instructionPointer))
            {
                instructionPointer += 4;
            }

        }

        private bool ProcessInstruction(int instructionPointer)
        {
            var opCode = _memory[instructionPointer];
            if (opCode == 99) return false;

            var address1 = _memory[instructionPointer + 1];
            var address2 = _memory[instructionPointer + 2];
            var address3 = _memory[instructionPointer + 3];

            var parameter1 = _memory[address1];
            var parameter2 = _memory[address2];
            var result = opCode == 1
                ? parameter1 + parameter2
                : opCode == 2
                  ? parameter1 * parameter2
                  : throw new Exception($"Invalid opCode: '{opCode}'");

            _memory[address3] = result;
            return true;
        }
    }
}
