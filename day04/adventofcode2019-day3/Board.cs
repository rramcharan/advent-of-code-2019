using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode2019_day3
{
    public class Board
    {
        private int MaxX = 11;
        private int MaxY = 10;
        public Board():this(11,10)
        {
        }
        public Board(int maxX, int maxY)
        {
            ClosestIntersectionDistance = 0;

            MaxX = maxX;
            MaxY = maxY;

            Wires = new List<Wire>();
            Connectors = new Connectors();

            Central = new Point(1,1);
        }

        public Connectors Connectors { get; private set; }
        public int ClosestIntersectionDistance { get; private set; }
        public List<Wire> Wires { get; private set; }
        public Point Central { get; private set; }
        public string Map => DrawMap();

        //public int StepsToClosestConnector => Wires.Sum(w => w.StepsToClosestConnector);

        public int MinimalStepsToIntersection { get; private set; }

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
            Connect(wire);

            return wire;
        }

        public void Move(Wire wire, string movement)
        {
            var direction = movement.Substring(0, 1);
            var steps = Convert.ToInt32(movement.Substring(1));
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

            var xDirection = xSteps > 0 ? 1 : -1;
            var yDirection = ySteps > 0 ? 1 : -1;
            for (var moveX = 0; moveX < Math.Abs(xSteps); moveX++)
            {
                MoveWireNextStep(wire, xDirection, 0);
            }

            for (var moveY = 0; moveY < Math.Abs(ySteps); moveY++)
            { 
                MoveWireNextStep(wire, 0, yDirection);
            }
        }

        private void MoveWireNextStep(Wire wire, int x, int y)
        {
            wire.IncrementStep();
            wire.X += x;
            wire.Y += y;
            Connect(wire);
        }

        private void Connect(Wire wire)
        {
            var connector = Connectors.GetConnector(wire.X, wire.Y);
            if (connector.Wires.ContainsKey(wire)) return;

            connector.Wires[wire]=wire.Steps;

            if (connector.Wires.Count > 1)
            {
                if ((wire.X != Central.X) || (wire.Y != Central.Y))
                {
                    Console.WriteLine("Intersection");
                    var stepsToIntersection = 0;
                    foreach (var tWire in connector.Wires.Keys)
                    {
                        stepsToIntersection += connector.Wires[tWire];
                        Console.WriteLine($"{tWire.Name} (steps: {connector.Wires[tWire]})");
                        System.Diagnostics.Debug.WriteLine($"{tWire.Name} (steps: {connector.Wires[tWire]})");
                    }
                    SetMinimalStepsToIntersection(stepsToIntersection);

                    var distance = ManhattanDistance(Central, wire.LastPoint);
                    if (ClosestIntersectionDistance == 0 || ClosestIntersectionDistance > distance)
                        ClosestIntersectionDistance = distance;
                    foreach(var aWire in connector.Wires.Keys)
                    {
                        var steps = connector.Wires[aWire];
                        if (aWire.SetMinimumStepsToFirstConnector(steps))
                        {
                            //aWire.ClosestPoint = aWire.LastPoint;
                            aWire.ClosestPoint = new Point(wire.X, wire.Y);
                        }
                    }
                }
            }
        }

        private void SetMinimalStepsToIntersection(int stepsToIntersection)
        {
            if (MinimalStepsToIntersection == 0 || MinimalStepsToIntersection > stepsToIntersection)
            {
                MinimalStepsToIntersection = stepsToIntersection;
            }
        }

        private string DrawMap()
        {
            var map = new string[MaxX, MaxY];
            for (var x = 0; x < MaxX; x++)
            {
                for (var y = 0; y < MaxY; y++)
                {
                    var count = Connectors.GetWiresCount(x, y);
                    switch (count)
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
            var x = Math.Abs(a.X - b.X);
            var y = Math.Abs(a.Y - b.Y);
            return x + y;
        }

    }
}
