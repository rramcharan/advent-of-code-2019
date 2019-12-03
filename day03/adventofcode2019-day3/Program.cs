using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Board
    {
        public Board()
        {
            Connector = new int[10, 11];
            for (var x = 0; x < 10; x++)
                for (var y = 0; y < 11; y++)
                    Connector[x, y] = 0;
            Central = new Point(1,8);
        }

        public int[,] Connector { get; private set; }
        public Point Central { get; private set; }

        public void Wire(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            var point = new Point(Central.X, Central.Y);
            var movements = path.Replace(" ","").Split(',');
            foreach(var movement in movements)
            {
                point = Move(point, movement);
            }
        }

        public Point Move(Point point, string movement)
        {
            var direction = movement.Substring(0, 1);
            var steps = Convert.ToInt32(movement.Substring(1, 1));
            switch (direction)
            {
                case "U":
                    return Move(point, 0, -1 * steps);
                case "D":
                    return Move(point, 0, steps);
                case "L":
                    return Move(point, -1 * steps, 0);
                case "R":
                    return Move(point, steps, 0);
                default:
                    throw new Exception($"Unknown direction: {direction}");
            }
        }

        private Point Move(Point point, int xSteps, int ySteps)
        {
            if (xSteps == 0 && ySteps == 0) return point;
            if (xSteps != 0 && ySteps != 0) throw new Exception($"Unsuported move: x: {xSteps} and y: {ySteps}");

            var x = point.X;
            var y = point.Y;
            var xDirection = xSteps > 0 ? 1 : -1;
            var yDirection = ySteps > 0 ? 1 : -1;
            for (int moveX = 0; moveX < Math.Abs(xSteps); moveX++)
            {
                x = point.X + moveX + (1 * xDirection);
                Connector[x, y]++;
            }

            for (int moveY = 0; moveY < Math.Abs(ySteps); moveY++)
            {
                y = point.Y + moveY + (1 * yDirection);
                Connector[x, y]++;
            }

            return new Point(x,y);
        }

        public static int ManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
