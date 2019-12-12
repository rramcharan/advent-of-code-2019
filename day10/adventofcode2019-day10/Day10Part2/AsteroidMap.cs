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

        public int DimensionX => Map[0].Count;
        public int DimensionY => Map.Count;
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
            return asteroid.VisibleAsteroids();
        }

        //private int VisibleCountMap(int x, int y)
        //{
        //    var something = Map[x][y];
        //    if (something is Asteroid asteroid)
        //        return VisibleCountMap(asteroid);
        //    return 0;
        //}
        //private int VisibleCountMap(Asteroid refAsteroid)
        //{
        //    foreach (var asteroid in Asteroids)
        //    {
        //        if (refAsteroid == asteroid) continue;
        //        var visibleAnge = Angle.Calculate(x, y, x1, y1);
        //        refAsteroid.OtherAsteroids.Add(asteroid, new AsteroidMeasurement { Angle = visibleAnge });
        //    }

        //    var x = refAsteroid.X;
        //    var y = refAsteroid.Y;
        //    for (var y1 = 0; y1 < DimensionY; y1++)
        //    {
        //        for (var x1 = 0; x1 < DimensionX; x1++)
        //        {
        //            var asteroid = Map[x1][y1] as Asteroid;
        //            if (asteroid == null) continue;
                    
        //            var visibleAnge = Angle.Calculate(x,y, x1, y1);
        //            refAsteroid.OtherAsteroids.Add(asteroid, new AsteroidMeasurement { Angle = visibleAnge });

        //        }
        //    }

        //    return 0;
        //}
        public void BuildAsteroidsMeasurementMap()
        {
            foreach (var asteroid in Asteroids)
            {
                BuildAsteroidsMeasurementMap(asteroid);
            }
        }

        private void BuildAsteroidsMeasurementMap(Asteroid refAsteroid)
        {
            foreach (var asteroid in Asteroids)
            {
                if (refAsteroid == asteroid) continue;

                var visibleAnge = CalculateAngle(refAsteroid, asteroid);
                refAsteroid.OtherAsteroids.Add(asteroid, new AsteroidMeasurement { Angle = visibleAnge });
            }
        }
        private double CalculateAngle(Asteroid refAsteroid, Asteroid asteroid) 
            => Angle.Calculate(refAsteroid.X, refAsteroid.Y, asteroid.X, asteroid.Y);
    }
}
