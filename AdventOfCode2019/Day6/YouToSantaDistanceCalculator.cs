namespace AdventOfCode2019.Day6
{
    using System.Linq;

    public class YouToSantaDistanceCalculator
    {
        public int GetDistance(SpaceObject you, SpaceObject santa)
        {
            var (found, distance) = Search(you.Parent, santa, you, true, 0);

            return distance;
        }

        private (bool found, int distance) Search(SpaceObject root, SpaceObject searchingFor, SpaceObject except,
            bool searchRoot, int distance)
        {
            if (!root.Children.Any())
            {
                return (false, -1);
            }

            foreach (var child in root.Children.Where(c => c != except))
            {
                if (child == searchingFor)
                {
                    return (true, distance);
                }

                var (foundInChild, distanceFromChild) = Search(child, searchingFor, null, false, distance + 1);
                if (foundInChild)
                {
                    return (true, distanceFromChild);
                }
            }

            if (searchRoot)
            {
                return Search(root.Parent, searchingFor, root, true, distance + 1);
            }

            return (false, -1);
        }
    }
}