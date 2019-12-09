using System.Collections.Generic;

namespace adventofcode2019_day6.Part1
{
    public class OrbitCounterNotProper
    {
        private int Counter = 0;

        public OrbitCounterNotProper(Dictionary<string, Orbit> orbits, Orbit root, Orbit orbit)
        {
            Orbits = orbits;
            Root = root;
            Counter = TotalNumberOfOrbits(orbit);
        }

        public Dictionary<string, Orbit> Orbits { get; }
        private Dictionary<Orbit, int> _orbitCounted = new Dictionary<Orbit, int>();
        public Orbit Root { get; }

        internal int Count()
        {
            return Counter;
        }

        private int TotalNumberOfOrbits(Orbit orbit)
        {
            if (orbit == null) return 0;
            if (orbit == Root) return 0;
            if (_orbitCounted.ContainsKey(orbit)) return 0;
            var count = orbit.Arounds.Count + TotalNumberOfOrbits(orbit.Arounds);

            _orbitCounted[orbit] = count;
            System.Diagnostics.Debug.WriteLine($"counting total {orbit.Name}: {count}");
            return count;
        }

        private int TotalNumberOfOrbits(List<Orbit> orbits)
        {
            var count = 0;
            foreach (var orbit in orbits)
                count += TotalNumberOfOrbits(orbit);
            return count;
        }
    }
}
