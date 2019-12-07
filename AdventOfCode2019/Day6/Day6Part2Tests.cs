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

        [Fact]
        public void SantaIsDownstream()
        {
            var map = new OrbitMap(new[]
            {
                "COM)YOU",
                "COM)B",
                "B)SAN",
            });

            var you = map.Objects.First(o => o.You);
            var santa = map.Objects.First(o => o.Santa);

            var result = new YouToSantaDistanceCalculator().GetDistance(you, santa);

            result.ShouldBe(1);
        }

        [Fact]
        public void SantaIsUpstream()
        {
            var map = new OrbitMap(new[]
            {
                "COM)SAN",
                "COM)B",
                "B)YOU",
            });

            var you = map.Objects.First(o => o.You);
            var santa = map.Objects.First(o => o.Santa);

            var result = new YouToSantaDistanceCalculator().GetDistance(you, santa);

            result.ShouldBe(1);
        }

        [Fact]
        public void ExampleMap()
        {
            var map = new OrbitMap(new[]
            {
                "COM)B",
                "B)C",
                "C)D",
                "D)E",
                "E)F",
                "B)G",
                "G)H",
                "D)I",
                "E)J",
                "J)K",
                "K)L",
                "K)YOU",
                "I)SAN"
            });

            var you = map.Objects.First(o => o.You);
            var santa = map.Objects.First(o => o.Santa);

            var result = new YouToSantaDistanceCalculator().GetDistance(you, santa);

            result.ShouldBe(4);
        }

        [Fact]
        public void ExampleMap2()
        {
            var map = new OrbitMap(new[]
            {
                "COM)B",
                "B)C",
                "C)D",
                "D)E",
                "E)F",
                "B)G",
                "G)H",
                "D)I",
                "E)J",
                "J)K",
                "K)L",
                "K)YOU",
                "I)SAN",
                "F)Q"
            });

            var you = map.Objects.First(o => o.You);
            var santa = map.Objects.First(o => o.Santa);

            var result = new YouToSantaDistanceCalculator().GetDistance(you, santa);

            result.ShouldBe(4);
        }

        [Fact]
        public void FullInput()
        {
            var input = new CalendarLineInput("Day6\\Day6Input.txt");

            var map = new OrbitMap(input.ReadString());

            var you = map.Objects.First(o => o.You);
            var santa = map.Objects.First(o => o.Santa);

            var result = new YouToSantaDistanceCalculator().GetDistance(you, santa);

            result.ShouldBe(442);
        }

    }
}
