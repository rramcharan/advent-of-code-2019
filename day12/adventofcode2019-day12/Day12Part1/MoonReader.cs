using System;
using System.Text.RegularExpressions;


namespace adventofcode2019_day12.Day12Part1
{
    public class MoonReader
    {
        private static Regex _re = new Regex(@"^<x=(?<x>-?\d+),\sy=(?<y>-?\d+), z=(?<z>-?\d+)>$", RegexOptions.Compiled);
        public static Moon Parse(string line)
        {
            var m = _re.Match(line);
            if (!m.Success) throw new ArgumentException($"Can't parse line: {line}");
            var moon = new Moon();
            moon.Position.X = Convert.ToInt32(m.Groups["x"].Value);
            moon.Position.Y = Convert.ToInt32(m.Groups["y"].Value);
            moon.Position.Z = Convert.ToInt32(m.Groups["z"].Value);

            return moon;
        }
    }
}
