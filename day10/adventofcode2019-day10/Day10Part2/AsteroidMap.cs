using System.Collections.Generic;

namespace adventofcode2019_day10.Day10Part2
{
    public class AsteroidMap
    {
        public int DimensionX { get; private set; }
        public int DimensionY { get; private set; }
        public Dictionary<int, Dictionary<int, bool>> Map { get; private set; }
        public bool IsAndroid(int x, int y) => Map[x][y];

        internal void Load(Dictionary<int, Dictionary<int, bool>> map)
        {
            Map = map;
            DimensionX = map[0].Count;
            DimensionY = map.Count;
        }

        public int VisibleAsteriodsCount(int x, int y)
        {
            var count = VisibleCountMap(x, y);
            return count;
        }

        private int VisibleCountMap(int x, int y)
        {
            if (!IsAndroid(x, y)) return 0;

            var counter = 0;
            var angles = new List<double>();
            //var counterMap = new Dictionary<int, Dictionary<int, double>>();
            for (var y1 = 0; y1 < DimensionY; y1++)
            {
                for (var x1 = 0; x1 < DimensionX; x1++)
                {
                    if (x == x1 && y == y1) continue;
                    if (!IsAndroid(x1,y1)) continue;
                    
                    var visibleAnge = Angle.Calculate(x,y, x1, y1);
                    //System.Console.WriteLine($"asteroid({x1},{y1}) - angle: {visibleAnge}");
                    if (angles.Contains(visibleAnge)) continue;

                    counter++;
                    angles.Add(visibleAnge);
                }
            }

            //System.Console.WriteLine($"VisibleCountMap({x},{y}): {counter}");
            return counter;
        }           
    }
}
