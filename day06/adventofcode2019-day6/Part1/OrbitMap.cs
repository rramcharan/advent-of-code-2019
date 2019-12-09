using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode2019_day6.Part1
{
    public class OrbitMap
    {
        public Orbit Root { get; private set; }
        public Dictionary<string, Orbit> Orbits { get; private set; }
        private OrbitMap()
        {
            Orbits = new Dictionary<string, Orbit>();
        }
        public static OrbitMap LoadMap(string map)
        {
            var result = new OrbitMap();

            using (StringReader reader = new StringReader(map))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var relation = OrbitRelation.Parse(line);
                    result.AddRelation(relation);
                }
            }
            return result;

        }

        private void AddRelation(OrbitRelation relation)
        {
            var orbit1 = GetOrbitByName(relation.OrbitName1);
            var orbit2 = GetOrbitByName(relation.OrbitName2);

            if (orbit1 == null)
            {
                orbit1 = AddOrbit(relation.OrbitName1, null);
                if (Root == null)
                {
                    Root = orbit1;
                }
                //throw new Exception($"Can't find orbit 1 by name: '{relation.OrbitName1}'");
            }
            if (orbit2 == null)
            {
                orbit2 = AddOrbit(relation.OrbitName2, orbit1);
            }
            else
                orbit2.AddArround(orbit1);
            //throw new Exception($"Orbit 2 already added. Orbit name: '{relation.OrbitName2}'");
        }
        private Orbit GetOrbitByName(string name)
        {
            if (Orbits.ContainsKey(name))
            {
                return Orbits[name];
            }
            return null;
        }
        private Orbit AddOrbit(string name, Orbit arround)
        {
            // if (arround == null) throw new ArgumentNullException(nameof(arround));
            
            var orbit = new Orbit { Name = name };
            orbit.AddArround(arround);

            Orbits.Add(name, orbit);
            return orbit;
        }

        public int TotalNumberOfOrbits()
        {
            Console.WriteLine($"Total number of orbits: {Orbits.Values.Count}");
            return Orbits.Values.Sum(o => o.CountConnections);
            //return Orbits.Values.Sum(orbit => TotalNumberOfOrbits(orbit));
        }

        public int TotalNumberOfOrbits(string name)
        {
            var orbit = GetOrbitByName(name);
            if (orbit == null)
                throw new Exception($"Orbit '{name}' does not exist");
            var total = TotalNumberOfOrbits(orbit);
            return total;
        }
        private int TotalNumberOfOrbits(Orbit orbit)
        {
            var count = new OrbitCounter(Orbits, Root, orbit).Count();
            System.Diagnostics.Debug.WriteLine($"{orbit.Name}: {count}");
            return count;
        }

    }
}
