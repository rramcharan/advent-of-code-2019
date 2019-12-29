using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode2019_day12.Day12Part1
{
    public class Planet
    {
        public Planet()
        {
            Moons = new Moon[4];
        }
        public int NumberOfMoons { get; set; }
        public Moon[] Moons { get; private set; }

        public long Energy => Moons.Sum(m => m.Energy);

        public void AddMoon(Moon moon)
        {
            Moons[NumberOfMoons]=moon;
            NumberOfMoons++;
        }

        public void AddMoons(string text)
        {
            using (StringReader reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    var moon = MoonReader.Parse(line);
                    AddMoon(moon);
                }
            }
        }

        public object ShowMoon()
        {
            var sb = new StringBuilder();
            for (var x = 0; x < NumberOfMoons; x++)
            {
                var moon = Moons[x];
                sb.AppendLine();
                sb.Append($"pos=<x={moon.Position.X}, y={moon.Position.Y}, z={moon.Position.Z}>, ");
                sb.Append($"vel=<x={moon.Velocity.X}, y={moon.Velocity.Y}, z={moon.Velocity.Z}>");
            }
            return sb.ToString();
        }

        public void Move(int steps)
        {
            for (var step = 0; step < steps; step++)
            {
                MoveOneStep();
            }
        }

        private void MoveOneStep()
        {
            foreach (var moon in Moons)
            {
                UpdateVelocity(moon);
            }
            foreach (var moon in Moons)
            {
                UpdatePosition(moon);
            }
        }

        const int _plusOne = 1;
        const int _minOne = -1;
        private void UpdateVelocity(Moon refMoon)
        {
            if (refMoon == null) throw new ArgumentNullException(nameof(refMoon));

            foreach(var moon in Moons)
            {
                if (refMoon == moon) continue;
                
                if (refMoon.Position.X != moon.Position.X)
                    refMoon.Velocity.X += (refMoon.Position.X < moon.Position.X) ? _plusOne :_minOne;

                if (refMoon.Position.Y != moon.Position.Y)
                    refMoon.Velocity.Y += (refMoon.Position.Y < moon.Position.Y) ? _plusOne : _minOne;

                if (refMoon.Position.Z != moon.Position.Z)
                    refMoon.Velocity.Z += (refMoon.Position.Z < moon.Position.Z) ? _plusOne : _minOne;
            }
        }

        //private void UpdateVelocity(Moon refMoon)
        //{
        //    if (refMoon == null) throw new ArgumentNullException(nameof(refMoon));

        //    foreach (var moon in Moons)
        //    {
        //        if (refMoon == moon) continue;

        //        if (refMoon.Position.X > moon.Position.X) refMoon.Velocity.X--;
        //        if (refMoon.Position.X < moon.Position.X) refMoon.Velocity.X++;

        //        if (refMoon.Position.Y > moon.Position.Y) refMoon.Velocity.Y--;
        //        if (refMoon.Position.Y < moon.Position.Y) refMoon.Velocity.Y++;

        //        if (refMoon.Position.Z > moon.Position.Z) refMoon.Velocity.Z--;
        //        if (refMoon.Position.Z < moon.Position.Z) refMoon.Velocity.Z++;
        //    }
        //}

        private void UpdatePosition(Moon moon)
        {
            moon.Position.X += moon.Velocity.X;
            moon.Position.Y += moon.Velocity.Y;
            moon.Position.Z += moon.Velocity.Z;
        }

    }
}
