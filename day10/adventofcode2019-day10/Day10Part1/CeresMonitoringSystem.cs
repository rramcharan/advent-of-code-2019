using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace adventofcode2019_day10.Day10Part1
{
    public class CeresMonitoringSystem
    {
        private CeresMonitoringSystem()
        {
            Map = new AsteroidMap();
        }
        public AsteroidMap Map { get; private set; }

        public static CeresMonitoringSystem LoadAsteroidsMap(string textMap)
        {
            var system = new CeresMonitoringSystem();
            var y = 0;
            using (StringReader reader = new StringReader(textMap))
            {
                var map = new Dictionary<int, Dictionary<int,bool>>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var x = 0;
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line)) continue;
                    foreach(var pos in line)
                    {
                        if (!map.ContainsKey(x)) map[x] = new Dictionary<int, bool>();
                        map[x][y] = pos == '#';
                        x++;
                    }
                    y++;
                }
                system.Map.Load(map);
            }

            return system;
        }

        public Asteroid MostVisibleNbrOfAsteriods()
        {
            Asteroid asteroids = null;
            var highestCount = 0;
            var identicalNbrOfCounts = 0;
            {
                for (var x = 0; x < Map.DimensionX; x++)
                {
                    for (var y = 0; y < Map.DimensionY; y++)
                    {
                        var count = Map.VisibleAsteriodsCount(x, y);
                        if (count > highestCount)
                        {
                            highestCount = count;
                            asteroids = new Asteroid(x, y) { NbrOfVisibleAsteroids=count};
                            identicalNbrOfCounts = 1;
                        }
                        else if (count == highestCount)
                        {
                            identicalNbrOfCounts++;
                        }
                    }
                }
            }
            if (asteroids==null)  throw new Exception("Can't find asteroid with the most visible asteroids.");
            if (identicalNbrOfCounts != 1) throw new Exception($"Too many asteroids found with {highestCount} visible asteroids.");

            return asteroids;
        }


        /// <summary>
        /// Upper left corner=(0,0)
        /// </summary>
        public int VisibleAsteriodsCount(int x, int y)
        {
            return Map.VisibleAsteriodsCount(x, y);
        }

        public string VisibleAsteriodsMap()
        {
            var sb = new StringBuilder();
            {
                for (var y = 0; y < Map.DimensionY; y++)
                {
                    sb.AppendLine();
                    for (var x = 0; x < Map.DimensionX; x++)
                    {
                        var count = Map.VisibleAsteriodsCount(x, y);
                        sb.Append(count == 0 ? "." : count.ToString());
                    }
                }
            }
            return sb.ToString();
        }
    }
}
