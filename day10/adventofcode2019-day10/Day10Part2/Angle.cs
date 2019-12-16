using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day10.Day10Part2
{
    public static class Angle
    {
        public static double CalculateAngleInRadian(int x1, int y1, int x2, int y2)
        {
            //var angle = Math.Atan2(y1 - y2, x1 - x2);
            var angle = Math.Atan2(y2 - y1, x2 - x1);
            if (angle < 0) angle = (Math.PI * 2) + angle;
            return angle;
        }

        public static double CalculateAngleInRadianClockwise(int x1, int y1, int x2, int y2)
        {
            var angle = CalculateAngleInRadian(x1, y1, x2, y2) * -1;
            if (angle < 0) angle = (Math.PI * 2) + angle;
            return angle;
            ////var angle = Math.Atan2(y1 - y2, x1 - x2);
            //var angle = Math.Atan2(y2 - y1, x2 - x1);
            //angle = CorrectAngleRadian(angle) * -1;
            //angle = CorrectAngleRadian(angle);
            //return angle;
        }

        public static double CalculateAngleInRadianClockWiseTopIs0(int x1, int y1, int x2, int y2)
        {
            var angle = (CalculateAngleInRadian(x1, y1, x2, y2) * -1) + (Math.PI / 2);
            if (angle < 0) angle = (Math.PI * 2) + angle;
            if (angle < 0) angle = (Math.PI * 2) + angle;
            return angle;

            ////var angle = Math.Atan2(y1 - y2, x1 - x2);
            //var angle = Math.Atan2(y2 - y1, x2 - x1) - (Math.PI / 2);
            //return CorrectAngleRadian(angle);
        }
        private static double CorrectAngleRadian(double angle)
        {
            if (angle < 0)
            {
                if (angle == Math.PI * -1) return Math.PI;
                if (angle < Math.PI) angle = (Math.PI) - angle;
                else throw new Exception($"Can't correct angle: {angle}");
            }
            if (angle == (2 * Math.PI)) return 0;
            if (angle >= (2 * Math.PI)) angle = angle - (2 * Math.PI);
            if (angle >= (2 * Math.PI))
                throw new Exception($"Can'tcorrect angle: {angle}");

            //if (angle == 2 * Math.PI) angle = 0;
            //if (angle >= 2 * Math.PI) throw new Exception($"Invalid angle calculated: {angle}");
            return angle;
        }

        public static decimal CalculateInDegrees(int x1, int y1, int x2, int y2)
        {
            var angle = CalculateAngleInRadian(x1, y1, x2, y2);
            var degrees = angle * 180 / Math.PI;

            return Convert.ToDecimal(degrees);
        }

        public static decimal CalculateInDegreesClockWise(int x1, int y1, int x2, int y2)
        {
            var angle = CalculateAngleInRadianClockwise(x1, y1, x2, y2);
            var degrees = angle * 180 / Math.PI;

            return Convert.ToDecimal(degrees);
        }


        public static decimal CalculateInDegreesClockWiseTopIs0(int x1, int y1, int x2, int y2)
        {
            var angle = CalculateAngleInRadianClockWiseTopIs0(x1, y1, x2, y2);
            var degrees = angle * 180 / Math.PI;

            return Convert.ToDecimal(degrees);
        }

        public static bool Test()
        {
            var a1 = Angle.CalculateInDegrees(0, 0, 3, 0);
            var a2 = Angle.CalculateInDegrees(0, 0, -30, 0);
            var a3 = Angle.CalculateInDegrees(0, 0, 0, 5);
            var a4 = Angle.CalculateInDegrees(0, 0, 0, -5);

            var a10 = Angle.CalculateInDegrees(0, 0, 3, 3);
            var a11 = Angle.CalculateInDegrees(0, 0, 2, 3);

            return false;
        }
    }
}
