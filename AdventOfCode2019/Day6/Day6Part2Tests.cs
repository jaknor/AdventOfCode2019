namespace AdventOfCode2019.Day6
{
    using System.Linq;
    using Shouldly;
    using Xunit;

    public class Day6Part2Tests
    {
        [Fact]
        public void WeAreAlreadyInTheRightPlace()
        {
            var map = new OrbitMap(new[]
            {
                "COM)YOU",
                "COM)SAN",
            });

            var you = map.Objects.First(o => o.You);
            var santa = map.Objects.First(o => o.Santa);

            var result = new YouToSantaDistanceCalculator().GetDistance(you, santa);

            result.ShouldBe(0);
        }

    }
}
