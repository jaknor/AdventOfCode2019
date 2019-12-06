namespace AdventOfCode2019.Day6
{
    using System.Collections.Generic;

    public class SpaceObject
    {
        public SpaceObject(string identifier)
        {
            Identity = identifier;
            Children = new List<SpaceObject>();
        }

        public bool IsCom => Identity == "COM";

        public bool You => Identity == "YOU";

        public bool Santa => Identity == "SAN";
        public List<SpaceObject> Children { get; }
        public string Identity { get; }

        public void AddOrbitingObject(SpaceObject satellite)
        {
            Children.Add(satellite);
        }
    }
}