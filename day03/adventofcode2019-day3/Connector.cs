using System.Collections.Generic;

namespace adventofcode2019_day3
{
    public class Connector
    {
        public Connector()
        {
            Wires = new List<Wire>();
        }
        public List<Wire> Wires { get; private set; }
    }
}
