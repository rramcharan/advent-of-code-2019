using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace adventofcode2019_day10.Day10Part2
{
    public class CeresMonitoringSystem
    {
        private List<AsteroidMeasurement> _asteroidsToVaporize;

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
                var map = new Dictionary<int, Dictionary<int,IAsteroid>>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var x = 0;
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line)) continue;
                    foreach(var pos in line)
                    {
                        if (!map.ContainsKey(x)) map[x] = new Dictionary<int, IAsteroid>();


                        var something = pos == '.'
                            ? NoAsteroid.Create(x, y)
                            : new Asteroid(x, y);
                        x++;
                        system.Map.AddAsteroid(something);
                    }
                    y++;
                }
            }

            system.Map.BuildAsteroidsMeasurementMap();
            return system;
        }

        public Asteroid MostVisibleNbrOfAsteriods()
        {
            Asteroid asteroids = null;
            var highestCount = 0;
            var identicalNbrOfCounts = 0;

            foreach (var asteroid in Map.Asteroids)
            {
                Map.VisibleAsteriodsCount(asteroid);
                var count = asteroid.NbrOfVisibleAsteroids;
                if (count > highestCount)
                {
                    highestCount = count;
                    identicalNbrOfCounts = 1;
                    asteroids = asteroid;
                }
                else if (count == highestCount)
                {
                    identicalNbrOfCounts++;
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
                        var asteroid = Map.Map[x][y];
                        var count = Map.VisibleAsteriodsCount(x, y);
                        sb.Append(count == 0 || !asteroid.IsAsteroid ? "." : count.ToString() );
                    }
                }
            }
            return sb.ToString();
        }

        public string DisplayAsteriodsMap()
        {
            var sb = new StringBuilder();
            {
                for (var y = 0; y < Map.DimensionY; y++)
                {
                    sb.AppendLine();
                    for (var x = 0; x < Map.DimensionX; x++)
                    {
                        var asteroid = Map.Map[x][y];
                        sb.Append(asteroid.IsAsteroid ? "#" : ".");
                    }
                }
            }
            return sb.ToString();
        }

        #region Vaporize

        //public CeresMonitoringSystem Vaporize(int x, int y, int numberToVaporize)
        //{
        //    var asteroidsToVaporize = MarkVaporize(x, y, numberToVaporize);
        //    foreach(var asteroid in asteroidsToVaporize)
        //    {
        //        asteroid.Asteroid.Destroyed = true;
        //    }
        //    return ReBuildMap();
        //}

        public void VaporizeBuildList(int x, int y)
        {
            _asteroidsToVaporize = MarkVaporize(x, y);
        }

        public void Vaporize(int numberToVaporize)
        {
            var asteroidsToVaporize = _asteroidsToVaporize.Take(numberToVaporize);
            foreach (var asteroid in asteroidsToVaporize)
            {
                asteroid.Asteroid.Destroyed = true;
            }
            _asteroidsToVaporize = _asteroidsToVaporize.Skip(numberToVaporize).ToList();
        }


        public void Vaporize(int x, int y, int numberToVaporize)
        {
            var asteroidsToVaporize = MarkVaporize(x, y, numberToVaporize);
            foreach (var asteroid in asteroidsToVaporize)
            {
                asteroid.Asteroid.Destroyed = true;
            }
        }

        private CeresMonitoringSystem ReBuildMap()
        {
            var textMap = DisplayAsteriodsMap();
            return LoadAsteroidsMap(textMap);
            //var map = new AsteroidMap();
            //for (var x = 0; x < Map.DimensionX; x++)
            //{
            //    for (var y = 0; y < Map.DimensionX; y++)
            //    {
            //        var asteroid = Map.Map[x][y];
            //        if (asteroid is NoAsteroid)
            //        {
            //            map.Map[x][y] = asteroid;
            //        }
            //        else
            //        {
            //            var realAsteroid = (Asteroid)asteroid;
            //            map.Map[x][y] = realAsteroid.Destroyed ? NoAsteroid.Create(x,y) : realAsteroid;
            //        }
            //    }
            //}
            //Map = map;
            //Map.BuildAsteroidsMeasurementMap();
        }

        public List<AsteroidMeasurement> MarkVaporize(int x, int y)
        {
            var asteroid = Map.Map[x][y] as Asteroid;
            if (asteroid == null) return null;

            var result = new List<AsteroidMeasurement>();

            var _items = from a in asteroid.OtherAsteroids.Values
                         orderby a.Angle
                         group a by a.Angle;

            foreach (var _itemGroup in _items)
            {
                var subGroep = _itemGroup.OrderBy(a => a.Distance);
                result.Add(subGroep.First());
            }

            var sorted = result.OrderBy(a => a.Angle).ToList();
            return sorted;
        }


        public List<AsteroidMeasurement> MarkVaporize(int x, int y, int numberToVaporize)
        {
            var asteroid = Map.Map[x][y] as Asteroid;
            if (asteroid == null) return null;

            var result = new List<AsteroidMeasurement>();

            var _items = from a in asteroid.OtherAsteroids.Values
                         orderby a.Angle
                         group a by a.Angle;

            foreach (var _itemGroup in _items)
            {
                var subGroep = _itemGroup.OrderBy(a => a.Distance);
                result.Add(subGroep.First());
            }

            var sorted = result.OrderBy(a => a.Angle).Take(numberToVaporize).ToList();
            MarkMapToVaporize(sorted);
            return sorted;
        }

        private void MarkMapToVaporize(List<AsteroidMeasurement> astoroids)
        {
            for (var idx=0; idx<astoroids.Count; idx++)
            {
                var astoroid = astoroids[idx];
                astoroid.ShowAs($"{idx+1}");
            }
        }

        public void MarkToVaporize(int numberToVaporize)
        {
            var asteroidsToVaporize = _asteroidsToVaporize.Take(numberToVaporize).ToList();
            MarkMapToVaporize(asteroidsToVaporize);
        }

        //public object ShowAsteriodsMap()
        //{
        //    for(var y=0;)
        //}



        #endregion
    }
}
