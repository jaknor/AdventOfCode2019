namespace AdventOfCode2019.Day6
{
    using System.Collections.Generic;
    using System.Linq;

    public class OrbitMap
    {
        public OrbitMap(string[] orbits)
        {
            Objects = new List<SpaceObject>();
            foreach (var orbit in orbits)
            {
                var orbitObjects = orbit.Split(")");
                var center = new SpaceObject(orbitObjects[0]);
                var satellite = new SpaceObject(orbitObjects[1]);

                center = Objects.FirstOrDefault(o => o.Identity == center.Identity) ?? center;
                satellite = Objects.FirstOrDefault(o => o.Identity == satellite.Identity) ?? satellite;

                center.AddOrbitingObject(satellite);

                if (Objects.All(o => o.Identity != center.Identity))
                {
                    Objects.Add(center);
                }
                if (Objects.All(o => o.Identity != satellite.Identity))
                {
                    Objects.Add(satellite);
                }
            }
        }

        public List<SpaceObject> Objects { get; }
    }
}