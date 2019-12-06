namespace AdventOfCode2019.Day6
{
    public class OrbitCalculator
    {
        private readonly SpaceObject _com;

        public OrbitCalculator(SpaceObject com)
        {
            _com = com;
        }

        public int GetTotalOrbits()
        {
            return _com.Children.Count;
        }
    }
}