using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day12.Day12Part1
{
    public class Moon
    {
        public Moon()
        {
            Position = new Position();
            Velocity = new Velocity();
        }

        //private readonly string Name;

        public Position Position { get; private set; }
        public Velocity Velocity { get; private  set; }

        public long Energy => (Position.Energy * Velocity.Energy);

        public object State => $"{Position.X};{Position.Y}{Position.Z};{Velocity.X};{Velocity.Y}{Velocity.Z}";
    }
}
