namespace adventofcode2019_day10.Day10Part2
{
    public class Asteroid
    {
        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int NbrOfVisibleAsteroids { get; set; }
    }
}
