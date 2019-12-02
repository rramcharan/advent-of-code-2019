using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day2
{
    public class GravityAssistPart1
    {
        private readonly int[] _codes;

        private GravityAssistPart1(params int[] codes)
        {
            _codes = codes;
        }

        public int[] Codes => _codes;

        public int Code(int index) => _codes[index];

        public static GravityAssistPart1 Process(params int[] codes)
        {
            var result = new GravityAssistPart1(codes);
            result.ProcessAll();
            return result;
        }

        public static GravityAssistPart1 RestoreGravityAsistAndProcessCodes(params int[] codes)
        {
            var result = new GravityAssistPart1(codes);
            result.RestoreGravityAsist();
            result.ProcessAll();
            return result;
        }

        private void RestoreGravityAsist()
        {
            _codes[1] = 12;
            _codes[2] = 2;
        }

        private void ProcessAll()
        {
            var executionIndex = 0;
            while (ProcessAt(executionIndex))
            {
                executionIndex += 4;
            }

        }

        private bool ProcessAt(int executionIndex)
        {
            var opCode = _codes[executionIndex];
            if (opCode == 99) return false;

            var pos1 = _codes[executionIndex + 1];
            var pos2 = _codes[executionIndex + 2];
            var pos3 = _codes[executionIndex + 3];

            var val1 = _codes[pos1];
            var val2 = _codes[pos2];
            var result = opCode == 1
                ? val1 + val2
                : opCode == 2
                  ? val1 * val2
                  : throw new Exception($"Invalid opCode: '{opCode}'");

            _codes[pos3] = result;
            return true;
        }
    }
}
