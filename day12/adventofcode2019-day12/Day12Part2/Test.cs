using adventofcode2019_day12.Day12Part1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day12.Day12Part2
{
    public class PlanetMovesToAPrevPositionCalculator
    {
        private int _nbrOfMoons;
        private Planet _planet;

        private PlanetMovesToAPrevPositionCalculator(Planet planet)
        {
            _planet = planet;
            _nbrOfMoons = _planet.NumberOfMoons;
        }

        public long NumberOfMovesToAPreviousPosition()
        {
            var stopwatchMove = new Stopwatch();
            var stopwatchCompare = new Stopwatch();

            AddMoveToList(_planet);
            var nbrOfMoves = 1L;
            _planet.Move(1);
            while (true)
            {
                stopwatchCompare.Start();
                if (APreviousPositionReached(_planet)) break;
                stopwatchCompare.Stop();

                stopwatchMove.Start();
                _planet.Move(1);
                stopwatchMove.Stop();

                nbrOfMoves++;
                //if (nbrOfMoves % 1000000 == 0) Console.WriteLine($"move: {nbrOfMoves}");
                //if (nbrOfMoves % 100000000 == 0)
                    // if (nbrOfMoves % 100000000 == 0)
                    // if (nbrOfMoves % 3000000 == 0)
                if (nbrOfMoves % 10000 == 0) Console.WriteLine($"move: {nbrOfMoves}");
                if (nbrOfMoves % 100000 == 0)
                {
                    Console.WriteLine($"move: {nbrOfMoves}");
                    nbrOfMoves = 0;
                    break;
                }

            }
            Console.WriteLine($"move: {nbrOfMoves}");

            Console.WriteLine($"Move   : {stopwatchMove.Elapsed.ToString("G")}");
            Console.WriteLine($"Compare: {stopwatchCompare.Elapsed.ToString("G")}");
            return nbrOfMoves;
        }

        private List<List<Moon>> ListOfMoves = new List<List<Moon>>();
        private bool APreviousPositionReached(Planet planet)
        {
            foreach (var planetMoved in ListOfMoves)
            {
                if (IsSameState(planet.Moons, planetMoved))
                    return true;
            }
            AddMoveToList(planet);
            return false;
        }

        private void AddMoveToList(Planet planet)
        {
            var moonsCopy = new List<Moon>();
            for (var idx = 0; idx < _nbrOfMoons; idx++)
            {
                var moon = planet.Moons[idx];
                var moonCopy = new Moon();

                moonCopy.Position.X = moon.Position.X;
                moonCopy.Position.Y = moon.Position.Y;
                moonCopy.Position.Z = moon.Position.Z;

                moonCopy.Velocity.X = moon.Velocity.X;
                moonCopy.Velocity.Y = moon.Velocity.Y;
                moonCopy.Velocity.Z = moon.Velocity.Z;

                moonsCopy.Add(moonCopy);
            }
            ListOfMoves.Add(moonsCopy);
        }

        private bool IsSameState(Moon[] moons1, List<Moon> moons2)
        {
            for (var idx = 0; idx < _nbrOfMoons; idx++)
            {
                var refMoon = moons1[idx];
                var moon = moons2[idx];

                if (refMoon.Position.X != moon.Position.X) return false;
                if (refMoon.Position.Y != moon.Position.Y) return false;
                if (refMoon.Position.Z != moon.Position.Z) return false;

                if (refMoon.Velocity.X != moon.Velocity.X) return false;
                if (refMoon.Velocity.Y != moon.Velocity.Y) return false;
                if (refMoon.Velocity.Z != moon.Velocity.Z) return false;
            }

            return true;
        }

        public static PlanetMovesToAPrevPositionCalculator AddMoons(string text)
        {
            var planet = new Planet();
            planet.AddMoons(text);

            var result = new PlanetMovesToAPrevPositionCalculator(planet);
            return result;
        }
    }
}
