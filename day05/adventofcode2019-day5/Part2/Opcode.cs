using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day5.Part2
{
    public enum Opcode:int
    {
        OpcodeAdd = 1,
        OpcodeMultiply = 2,
        OpcodeReadInput = 3,
        OpcodeWriteOutput = 4,
        Halt = 99,
    }
}
