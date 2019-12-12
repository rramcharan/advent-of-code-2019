using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day10.Day10Part2
{
    public static class Angle
    {
        public static double Calculate(int x1, int y1, int x2, int y2)
        {
            var angle = Math.Atan2(y1 - y2, x1 - x2);
            return angle;
        }
        public static double CalculateInDegrees(int x1, int y1, int x2, int y2)
        {
            var angle = Calculate(x1, y1, x2, y2);
            var degrees = angle * 180 / Math.PI;

            return degrees;
        }
    }
}
