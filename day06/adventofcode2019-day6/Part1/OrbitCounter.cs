using System;
using System.Collections.Generic;

namespace adventofcode2019_day6.Part1
{
    public class OrbitCounter
    {
        private Dictionary<string, Orbit> _orbits;
        private List<string> Routes = new List<string>();
        private Orbit _Root;
        private Dictionary<Orbit, int> _orbitCounted = new Dictionary<Orbit, int>();

        public OrbitCounter(Dictionary<string, Orbit> orbits, Orbit root, Orbit orbit)
        {
            _orbits = orbits;
            _Root = root;
            Console.WriteLine(orbit.Name);
            TotalNumberOfOrbits(0, orbit);
        }

        public int Count()
        {
            return Routes.Count; ;
        }

        private void TotalNumberOfOrbits(int offset, Orbit orbit)
        {
            if (orbit == null) return;
            if (orbit == _Root) return;
            if (orbit.Arounds.Count == 0) return;

            var nbrOfArrounds = 0;
            foreach (var orbitArround in orbit.Arounds)
            {
                nbrOfArrounds++;
                TotalNumberOfOrbits(offset, orbit, orbitArround, nbrOfArrounds);
            }
        }

        private void TotalNumberOfOrbits(int offset, Orbit fromOrbit, Orbit toOrbit, int orbitIndex)
        {
            if (toOrbit == null)
            {
                if (fromOrbit.Arounds.Count == 1)
                    Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {fromOrbit.Name}-->NULL: {fromOrbit.Name}[1/1]");
                else
                    Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {fromOrbit.Name}-->NULL: {fromOrbit.Name}[{orbitIndex}/{fromOrbit.Arounds.Count}]");
                return; 
            }

            string route = $"{fromOrbit.Name}-->{toOrbit.Name}";
            //Console.WriteLine($"{" ".PadRight((offset+1) * 2)}- {route}");
            if (fromOrbit.Arounds.Count == 1)
                Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {route}: {fromOrbit.Name}[1/1]");
            else
                Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {route}: {fromOrbit.Name}[{orbitIndex}/{fromOrbit.Arounds.Count}]");

            //if (Routes.Contains(route)) return;
            Routes.Add(route);

            TotalNumberOfOrbits(offset + 1, toOrbit);

        }

        //private int GetIndexOfOrbit(Orbit fromOrbit, Orbit toOrbit)
        //{
        //    for (var index = 0; index < fromOrbit.Arounds.Count; index++)
        //        if (fromOrbit.Arounds[index] == toOrbit) return index;
        //    return 0;
        //}
    }
}
