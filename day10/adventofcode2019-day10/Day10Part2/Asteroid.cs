using System;
using System.Collections.Generic;

namespace adventofcode2019_day10.Day10Part2
{
    public class Asteroid: BaseAsteroid, IAsteroid
    {
        public Asteroid(int x, int y)
        {
            X = x;
            Y = y;
            OtherAsteroids = new Dictionary<Asteroid, AsteroidMeasurement>();
        }
        public bool IsAsteroid => false;

        public int NbrOfVisibleAsteroids => VisibleAsteroids();
        public Dictionary<Asteroid, AsteroidMeasurement> OtherAsteroids { get; private set; }

        public int VisibleAsteroids()
        {
            int count = 0;
            var angles = new List<double>();
            foreach (var asteroid in OtherAsteroids.Keys)
            {
                if (this == asteroid) throw new Exception("Some is wrong. Current asteroid is available in the list of other asteroids.");

                var measurements = OtherAsteroids[asteroid];
                var visibleAnge = measurements.Angle;
                if (angles.Contains(visibleAnge)) continue;

                count++;
                angles.Add(visibleAnge);
            }
            return count;
        }
    }
    public class NoAsteroid: BaseAsteroid, IAsteroid
    {
        public bool IsAsteroid => false;

        public static IAsteroid Create(int x, int y)
        {
            return new NoAsteroid { X = x, Y = y };
        }

        public int VisibleAsteroids() => 0;
    }
    public abstract class BaseAsteroid
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
    }

    public class AsteroidMeasurement
    {
        public double Angle { get; set; }
        public int Distance { get; set; }
    }

}
