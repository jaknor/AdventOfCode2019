namespace AdventOfCode2019.Day6
{
    public class OrbitCalculator
    {
        public int GetTotalOrbits(SpaceObject com, int distance = 1)
        {
            var orbits = com.Children.Count * distance;

            foreach (var spaceObject in com.Children)
            {
                orbits += GetTotalOrbits(spaceObject, distance + 1);
            }

            return orbits;
        }
    }
}