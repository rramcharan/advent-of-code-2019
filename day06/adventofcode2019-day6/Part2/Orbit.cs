using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2019_day6.Part2
{
    public class Orbit
    {
        public Orbit()
        {
            Arounds = new List<Orbit>();
        }
        public string Name { get; set; }
        public List<Orbit> Arounds { get; set; }
        public int CountConnections
        {
            get
            { 
                int aantal = 0;
                foreach(var orbit in Arounds)
                {
                    if (orbit!= null)
                    {
                        aantal += 1 + orbit.CountConnections;
                    }
                }
                return aantal;
            }
        }

        internal void AddArround(Orbit orbit)
        {
            if (Arounds.Contains(orbit))
                throw new Exception($"Orbit '{orbit.Name}' is already added.");
            Arounds.Add(orbit);
        }
    }
}
