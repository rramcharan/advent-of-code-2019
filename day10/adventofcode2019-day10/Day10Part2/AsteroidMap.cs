using System;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2019_day10.Day10Part2
{
    public class AsteroidMap
    {
        public AsteroidMap()
        {
            Map = new Dictionary<int, Dictionary<int, IAsteroid>>();
            Asteroids = new List<Asteroid>();
        }

        public int DimensionY => Map[0].Count;
        public int DimensionX => Map.Count;
        public Dictionary<int, Dictionary<int, IAsteroid>> Map { get; private set; }
        public List<Asteroid> Asteroids { get; private set; }
        public bool IsAndroid(int x, int y) => Map[x][y].IsAsteroid;

        public void AddAsteroid(IAsteroid asteroid)
        {
            if (!Map.ContainsKey(asteroid.X)) Map[asteroid.X] = new Dictionary<int, IAsteroid>();
            Map[asteroid.X][asteroid.Y] = asteroid;

            if (asteroid is Asteroid)
                Asteroids.Add(asteroid as Asteroid);
        }

        public int VisibleAsteriodsCount(int x, int y)
        {
            if (!Map.ContainsKey(x)) return 0;
            if (!Map[x].ContainsKey(y)) return 0;

            var asteroid = Map[x][y];
            BuildAsteroidsMeasurementMap(asteroid as Asteroid);
            return asteroid.NbrOfVisibleAsteroids;
        }
        public int VisibleAsteriodsCount(Asteroid refAsteroid)
        {
            BuildAsteroidsMeasurementMap(refAsteroid);
            return refAsteroid.NbrOfVisibleAsteroids;
        }

        public void BuildAsteroidsMeasurementMap()
        {
            foreach (var asteroid in Asteroids)
            {
                BuildAsteroidsMeasurementMap(asteroid);
            }
        }

        private void BuildAsteroidsMeasurementMap(Asteroid refAsteroid)
        {
            if (refAsteroid == null) return;

            var nbrX = Map.Count;
            refAsteroid.OtherAsteroids.Clear();
            foreach (var asteroid in Asteroids)
            {
                if (refAsteroid == asteroid) continue;

                var visibleAnge = CalculateAngle(nbrX, asteroid, refAsteroid);
                refAsteroid.OtherAsteroids.Add(asteroid, new AsteroidMeasurement
                {
                    Asteroid = asteroid,
                    Angle = visibleAnge,
                    Distance = CalculateDistance(asteroid, refAsteroid)
                });
            }
            // Correct angles for asteroid with the same angle
            var _items = from a in refAsteroid.OtherAsteroids.Values
                         orderby a.Angle
                         group a by a.Angle;

            foreach (var _itemGroup in _items)
            {
                var subGroep = _itemGroup.OrderBy(a => a.Distance).ToList();
                if (subGroep.Count > 1)
                {
                    for (var idx = 1; idx < subGroep.Count; idx++)
                    {
                        subGroep[idx].Angle += idx * 360M;
                    }
                }
            }
        }
        private decimal CalculateAngle(int nbrX, Asteroid refAsteroid, Asteroid asteroid) 
            => Angle.CalculateInDegreesClockWiseTopIs0(nbrX-refAsteroid.X, refAsteroid.Y, nbrX-asteroid.X, asteroid.Y);
        private decimal CalculateDistance(Asteroid refAsteroid, Asteroid asteroid) 
            => Convert.ToDecimal(Math.Sqrt(Math.Pow((asteroid.X - refAsteroid.X), 2) + Math.Pow((asteroid.Y - refAsteroid.Y), 2)));

    }
}
