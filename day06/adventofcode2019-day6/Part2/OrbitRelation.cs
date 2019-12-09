using System;

namespace adventofcode2019_day6.Part2
{
    public class OrbitRelation
    {
        public string OrbitName1 { get; private set; }
        public string OrbitName2 { get; private set; }

        public static OrbitRelation Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("No relation specified!");

            var parts = text.Split(')');
            if (parts.Length != 2)
                throw new ArgumentException($"Relation should be specified with two orbits. Error in: '{text}'");

            var orbit1 = parts[0];
            var orbit2 = parts[1];
            if (string.IsNullOrWhiteSpace(orbit1))
                throw new ArgumentException($"Orbit 1 not specified. Error in: '{text}'");
            if (string.IsNullOrWhiteSpace(orbit2))
                throw new ArgumentException($"Orbit 2 not specified. Error in: '{text}'");

            var result = new OrbitRelation
            {
                OrbitName1 = orbit1,
                OrbitName2 = orbit2
            };
            return result;
        }
    }
}
