namespace AdventOfCode2019.Day6
{
    using System.Collections.Generic;

    public class SpaceObject
    {
        private readonly string _identifier;

        public SpaceObject(string identifier)
        {
            _identifier = identifier;
            Children = new List<SpaceObject>();
        }

        public bool IsCom => _identifier == "COM";

        public List<SpaceObject> Children { get; }

        public void AddOrbitingObject(SpaceObject satellite)
        {
            Children.Add(satellite);
        }
    }
}