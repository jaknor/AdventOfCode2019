namespace AdventOfCode2019.Day6
{
    using System.Collections.Generic;

    public class OrbitMap
    {
        public OrbitMap(string[] orbits)
        {
            Objects = new List<SpaceObject>();
            foreach (var orbit in orbits)
            {
                var orbitObjects = orbit.Split(")");
                var com = new SpaceObject(orbitObjects[0]);
                var satellite = new SpaceObject(orbitObjects[1]);
                com.AddOrbitingObject(satellite);
                Objects.Add(com);
                Objects.Add(satellite);
            }
        }

        public List<SpaceObject> Objects { get; }
    }
}