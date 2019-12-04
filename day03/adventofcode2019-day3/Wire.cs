namespace adventofcode2019_day3
{
    public class Wire
    {
        public Wire(int x, int y, string name)
        {
            StartPoint = new Point(x, y);
            LastPoint = new Point(x, y);
            Name = name;
        }
        public string Name { get; set; }
        public Point StartPoint { get; private set; }
        public Point LastPoint { get; private set; }
        public Dictionary<Point, int> Points;
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
    }
}
