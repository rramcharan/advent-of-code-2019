using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2019_day6.Part2
{
    public class OrbitCounter
    {
        private Dictionary<string, Orbit> _allOrbits;
        public Dictionary<string, int> ConnectedOrbits { get; private set; }

        private List<string> Routes = new List<string>();
        private Orbit _Root;
        private Orbit _orbit;

        public OrbitCounter(Dictionary<string, Orbit> orbits, Orbit root, Orbit orbit)
        {
            _allOrbits = orbits;
            _Root = root;
            _orbit = orbit;
            ConnectedOrbits = new Dictionary<string, int>();
            CountConnectedOrbits(orbit);
        }

        private void CountConnectedOrbits(Orbit orbit)
        {
            if (orbit == null) return;
            if (ConnectedOrbits.ContainsKey(orbit.Name)) return;

            ConnectedOrbits[orbit.Name] = orbit.CountConnections;

            foreach(var arround in orbit.Arounds)
            {
                CountConnectedOrbits(arround);
            }
        }

        public int Count => ConnectedOrbits[_orbit.Name]; 

        //private void TotalNumberOfOrbits(int offset, Orbit orbit)
        //{
        //    if (orbit == null) return;
        //    if (orbit == _Root) return;
        //    if (orbit.Arounds.Count == 0) return;

        //    var nbrOfArrounds = 0;
        //    foreach (var orbitArround in orbit.Arounds)
        //    {
        //        nbrOfArrounds++;
        //        TotalNumberOfOrbits(offset, orbit, orbitArround, nbrOfArrounds);
        //    }
        //}

        //private void TotalNumberOfOrbits(int offset, Orbit fromOrbit, Orbit toOrbit, int orbitIndex)
        //{
        //    if (toOrbit == null)
        //    {
        //        if (fromOrbit.Arounds.Count == 1)
        //            Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {fromOrbit.Name}-->NULL: {fromOrbit.Name}[1/1]");
        //        else
        //            Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {fromOrbit.Name}-->NULL: {fromOrbit.Name}[{orbitIndex}/{fromOrbit.Arounds.Count}]");
        //        return; 
        //    }

        //    string route = $"{fromOrbit.Name}-->{toOrbit.Name}";
        //    //Console.WriteLine($"{" ".PadRight((offset+1) * 2)}- {route}");
        //    if (fromOrbit.Arounds.Count == 1)
        //        Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {route}: {fromOrbit.Name}[1/1]");
        //    else
        //        Console.WriteLine($"{" ".PadRight((offset + 1) * 2)}- {route}: {fromOrbit.Name}[{orbitIndex}/{fromOrbit.Arounds.Count}]");

        //    //if (Routes.Contains(route)) return;
        //    Routes.Add(route);

        //    TotalNumberOfOrbits(offset + 1, toOrbit);

        //}

        //private int GetIndexOfOrbit(Orbit fromOrbit, Orbit toOrbit)
        //{
        //    for (var index = 0; index < fromOrbit.Arounds.Count; index++)
        //        if (fromOrbit.Arounds[index] == toOrbit) return index;
        //    return 0;
        //}
    }
}
