using System;
using System.Collections.Generic;

namespace adventofcode2019_day3
{
    public class Wire
    {
        public Wire(int x, int y, string name)
        {
            Steps = 0;
            Connectors = new List<Connector>();
            StartPoint = new Point(x, y);
            LastPoint = new Point(x, y);
            ClosestPoint = StartPoint;
            Name = name;
        }
        public string Name { get; private set; }
        public int Steps { get; private set; }
        public int StepsToClosestConnector { get; private set; }

        public Point StartPoint { get; private set; }
        public Point LastPoint { get; private set; }
        public Point ClosestPoint { get; set; }
        public List<Connector> Connectors { get; private set; }

        //public Dictionary<Point, int> Points;
        public int X
        {
            get => LastPoint.X;
            set => LastPoint = new Point(value, LastPoint.Y);
        }
        public int Y
        {
            get => LastPoint.Y;
            set => LastPoint = new Point(LastPoint.X, value);
        }

        public void IncrementStep()
        {
            Steps++;
        }

        public bool SetMinimumStepsToFirstConnector(int steps)
        {
            if (StepsToClosestConnector==0 || StepsToClosestConnector>steps)
            {
                StepsToClosestConnector = steps;
                return true;
            }
            return false;
        }
    }
}
