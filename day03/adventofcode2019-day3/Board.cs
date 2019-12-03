using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2019_day3
{
    public class Board
    {
        private int MaxX = 11;
        private int MaxY = 10;
        public Board()
        {
            Wires = new List<Wire>();
            Connectors = new Connector[MaxX, MaxY];

            for (var x = 0; x < MaxX; x++)
                for (var y = 0; y < MaxY; y++)
                    Connectors[x, y] = new Connector(); ;
            Central = new Point(1,1);
        }

        private void Resize(int addX, int addY)
        {
        }
        
        public Connector[,] Connectors { get; private set; }
        public List<Wire> Wires { get; private set; }
        public Point Central { get; private set; }
        public string Map => DrawMap();

        public Wire Wire(string path)
        {
            var wire = CreateWire(Central.X, Central.Y);
            if (string.IsNullOrEmpty(path)) return wire;

            var movements = path.Replace(" ","").Split(',');
            foreach(var movement in movements)
            {
                Move(wire, movement);
            }
            return wire;
        }

        public Wire CreateWire(int x, int y)
        {
            var wire = new Wire(x, y, $"Wire-{Wires.Count + 1}");
            Wires.Add(wire);
            Connect(wire, Connectors[x, y]);

            return wire;
        }

        public void Move(Wire wire, string movement)
        {
            var direction = movement.Substring(0, 1);
            var steps = Convert.ToInt32(movement.Substring(1, 1));
            switch (direction)
            {
                case "U":
                    Move(wire, 0, steps);
                    return;
                case "D":
                    Move(wire, 0, -1 * steps);
                    return;
                case "L":
                    Move(wire, -1 * steps, 0);
                    return;
                case "R":
                    Move(wire, steps, 0);
                    return;
                default:
                    throw new Exception($"Unknown direction: {direction}");
            }
        }

        private void Move(Wire wire, int xSteps, int ySteps)
        {
            if (xSteps == 0 && ySteps == 0) return ;
            if (xSteps != 0 && ySteps != 0) throw new Exception($"Unsuported move: x: {xSteps} and y: {ySteps}");

            var x = wire.X;
            var y = wire.Y;
            var xDirection = xSteps > 0 ? 1 : -1;
            var yDirection = ySteps > 0 ? 1 : -1;
            for (int moveX = 0; moveX < Math.Abs(xSteps); moveX++)
            {
                x = wire.X + ((moveX + 1) * xDirection);
                Connect(wire, Connectors[x, y]);
            }
            wire.X = x;

            for (int moveY = 0; moveY < Math.Abs(ySteps); moveY++)
            {
                y = wire.Y + ((moveY + 1) * yDirection);
                Connect(wire, Connectors[x, y]);
            }
            wire.Y = y;
        }

        private void Connect(Wire wire, Connector connector)
        {
            if (connector.Wires.Contains(wire)) return;

            connector.Wires.Add(wire);
        }

        private string DrawMap()
        {
            var map = new string[MaxX, MaxY];
            for (var x = 0; x < MaxX; x++)
            {
                for (var y = 0; y < MaxY; y++)
                {
                    var connector = Connectors[x, y];
                    switch (connector.Wires.Count)
                    {
                        case 0:
                            map[x, y] = ".";
                            break;
                        case 1:
                            map[x, y] = "-";
                            break;
                        case 2:
                            map[x, y] = "x";
                            break;
                        default:
                            map[x, y] = "?";
                            break;
                    }
                }
            }
            map[Central.X, Central.Y] = "o";
            var sb = new StringBuilder();
            for (var y = MaxY-1; y >= 0; y--)
            {
                sb.AppendLine();
                for (var x = 0; x < MaxX; x++)
                {
                    sb.Append(map[x, y]);
                }
            }
            return sb.ToString();
        }

        public static int ManhattanDistance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
