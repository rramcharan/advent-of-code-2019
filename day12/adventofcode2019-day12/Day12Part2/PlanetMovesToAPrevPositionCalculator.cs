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
                // if (nbrOfMoves % 100000000 == 0)
                // if (nbrOfMoves % 3000000 == 0)
                //if (nbrOfMoves % 10000 == 0) Console.WriteLine($"move: {nbrOfMoves}");
                //if (nbrOfMoves % 100000 == 0)
                if (nbrOfMoves % 1000000 == 0) Console.WriteLine($"move: {nbrOfMoves}");
                if (nbrOfMoves % 100000000 == 0)
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
        private Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<Velocity>>>>> MoonsMovements =
            new Dictionary<int, Dictionary<int, Dictionary<int, Dictionary<int, List<Velocity>>>>>();
        private bool APreviousPositionReached(Planet planet)
        {
            if (IsSameState(planet))
                return true;

            AddMoveToList(planet);
            return false;
        }

        private void AddMoveToList(Planet planet)
        {
            for (var idx = 0; idx < _nbrOfMoons; idx++)
            {
                var moon = planet.Moons[idx];
                if (!MoonsMovements.ContainsKey(idx))
                    MoonsMovements.Add(idx, new Dictionary<int, Dictionary<int, Dictionary<int, List<Velocity>>>>());

                if (!MoonsMovements[idx].ContainsKey(moon.Position.X))
                    MoonsMovements[idx].Add(moon.Position.X, new Dictionary<int, Dictionary<int, List<Velocity>>>());

                if (!MoonsMovements[idx][moon.Position.X].ContainsKey(moon.Position.Y))
                    MoonsMovements[idx][moon.Position.X].Add(moon.Position.Y, new Dictionary<int, List<Velocity>>());

                if (!MoonsMovements[idx][moon.Position.X][moon.Position.Y].ContainsKey(moon.Position.Z))
                    MoonsMovements[idx][moon.Position.X][moon.Position.Y][moon.Position.Z] = new List<Velocity>();

                var velocity = new Velocity
                {
                    X = moon.Velocity.X,
                    Y = moon.Velocity.Y,
                    Z = moon.Velocity.Z,
                };

                MoonsMovements[idx][moon.Position.X][moon.Position.Y][moon.Position.Z].Add(velocity);
            }
        }

        private bool IsSameState(Planet planet)
        {
            for (var idx = 0; idx < _nbrOfMoons; idx++)
            {
                var nbrOfMoonsMatches = 0;
                var moon = planet.Moons[idx];
                if (MoonsMovements.ContainsKey(idx)
                    && MoonsMovements[idx].ContainsKey(moon.Position.X)
                    && MoonsMovements[idx][moon.Position.X].ContainsKey(moon.Position.Y)
                    && MoonsMovements[idx][moon.Position.X][moon.Position.Y].ContainsKey(moon.Position.Z))
                {
                    var aMovedMoons = MoonsMovements[idx][moon.Position.X][moon.Position.Y][moon.Position.Z];
                    foreach (var aMovedMoon in aMovedMoons)
                    {
                        if (aMovedMoon.X == moon.Velocity.X &&
                            aMovedMoon.Y == moon.Velocity.Y &&
                            aMovedMoon.Z == moon.Velocity.Z)
                        {
                            nbrOfMoonsMatches++;
                            if (nbrOfMoonsMatches == _nbrOfMoons) return true;
                        }
                    }
                }
                else
                    return false;

            }
            return false;
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
