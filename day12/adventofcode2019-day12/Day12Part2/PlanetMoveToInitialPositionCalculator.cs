using adventofcode2019_day12.Day12Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day12.Day12Part2
{
    public class PlanetMoveToInitialPositionCalculator
    {
        private Planet _refPlanet;
        private long _energyRefPlanet;
        private int _nbrOfMoons;
        private Planet _planet;

        private PlanetMoveToInitialPositionCalculator(Planet refPlanet, Planet planet)
        {
            _refPlanet = refPlanet;
            _planet = planet;

            _energyRefPlanet = refPlanet.Energy;
            _nbrOfMoons = refPlanet.Moons.Count;
        }

        public long NumberOfMovesToInitalPosition()
        {
            var nbrOfMoves = 1;
            _planet.Move(1);
            while(!InitialPositionReached())
            {
                _planet.Move(1);
                nbrOfMoves++;
                if (nbrOfMoves % 100 == 0) Console.WriteLine($"move: {nbrOfMoves}");
                if (nbrOfMoves % 10000000 == 0) Console.WriteLine($"move: {nbrOfMoves}");
            }
            return nbrOfMoves;
        }

        private bool InitialPositionReached()
        {
            // if (_planet.Energy != _energyRefPlanet) return false;
            for(var idx=0; idx<_nbrOfMoons; idx++)
            {
                var refMoon = _refPlanet.OrderedMoons[idx];
                var moon = _planet.OrderedMoons[idx];

                if (refMoon.Position.X != moon.Position.X) return false;
                if (refMoon.Position.Y != moon.Position.Y) return false;
                if (refMoon.Position.Z != moon.Position.Z) return false;

                if (refMoon.Velocity.X != moon.Velocity.X) return false;
                if (refMoon.Velocity.Y != moon.Velocity.Y) return false;
                if (refMoon.Velocity.Z != moon.Velocity.Z) return false;
            }

            return true;
        }

        public static PlanetMoveToInitialPositionCalculator  AddMoons(string text)
        {
            var refPlanet = new Planet();
            refPlanet.AddMoons(text);

            var planet = new Planet();
            planet.AddMoons(text);

            var result = new PlanetMoveToInitialPositionCalculator(refPlanet, planet);
            return result;
        }
    }
}
