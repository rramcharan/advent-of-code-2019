using System;
using System.Collections.Generic;

namespace adventofcode2019_day3
{
    public class Connector
    {
        public Connector()
        {
            Wires = new Dictionary<Wire, int>();
        }
        public Dictionary<Wire, int> Wires { get; private set; }
    }
    public class Connectors
    {
        public Connectors()
        {
            Rows = new Dictionary<int, ConnectorCol>();
        }
        public Dictionary<int, ConnectorCol> Rows { get; set; }

        public Connector GetConnector(int row, int col)
        {
            if (!Rows.ContainsKey(row)) Rows[row] = new ConnectorCol();

            return Rows[row].GetConnector(col);
        }

        public int GetWiresCount(int row, int col)
        {
            if (!Rows.ContainsKey(row)) return 0;

            return Rows[row].GetWiresCount(col);
        }
    }
    public class ConnectorCol
    {
        public ConnectorCol()
        {
            Columns = new Dictionary<int, Connector>();
        }
        public Dictionary<int, Connector> Columns { get; set; }

        public Connector GetConnector(int col)
        {
            if (!Columns.ContainsKey(col)) Columns[col] = new Connector();

            return Columns[col];
        }
        public int GetWiresCount(int col)
        {
            if (!Columns.ContainsKey(col)) return 0;

            return Columns[col].Wires.Count;
        }
    }
}
