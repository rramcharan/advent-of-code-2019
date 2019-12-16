using System;
using System.Linq;
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
        public bool IsAsteroid => !Destroyed;
        public bool Destroyed { get; set; }

        public int NbrOfVisibleAsteroids => VisibleAsteroids().Count;
        public Dictionary<Asteroid, AsteroidMeasurement> OtherAsteroids { get; private set; }

        public List<Asteroid> VisibleAsteroids() => OtherAsteroids.Values.Where(a => a.Asteroid.IsAsteroid && a.Angle < 360M).Select(am => am.Asteroid).ToList();
    }
    public class NoAsteroid: BaseAsteroid, IAsteroid
    {
        public bool IsAsteroid => false;

        public static IAsteroid Create(int x, int y)
        {
            return new NoAsteroid { X = x, Y = y };
        }

        public int NbrOfVisibleAsteroids => 0;
    }
    public abstract class BaseAsteroid
    {
        public BaseAsteroid()
        {
            Label = "#";
        }

        public int X { get; protected set; }
        public int Y { get; protected set; }
        public string Label { get; set; }
    }

    public class AsteroidMeasurement
    {
        public Asteroid Asteroid { get; set; }
        public decimal Angle { get; set; }
        public decimal Distance { get; set; }

        internal void ShowAs(string label)
        {
            Asteroid.Label = label;
        }
    }

}
