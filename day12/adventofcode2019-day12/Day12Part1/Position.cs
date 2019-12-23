using System;

namespace adventofcode2019_day12.Day12Part1
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public long Energy => (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z));
    }
}
