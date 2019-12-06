namespace AdventOfCode2019.Day6
{
    using System.Linq;
    using Shouldly;
    using Xunit;

    public class Day6Part1Tests
    {
        [Fact]
        public void CanCreateMapForComWithOneObject()
        {
            var result = new OrbitMap(new[] {"COM)B"});

            result.Objects.Count.ShouldBe(2);
            result.Objects.Count(o => o.IsCom).ShouldBe(1);
            var com = result.Objects.First(o => o.IsCom);
            com.Children.Count.ShouldBe(1);
        }

        [Fact]
        public void CanCalculateOrbitsForComWithOneObject()
        {
            var map = new OrbitMap(new[] { "COM)B" });

            var com = map.Objects.First(o => o.IsCom);

            var result = new OrbitCalculator(com).GetTotalOrbits();

            result.ShouldBe(1);
        }

        [Fact]
        public void CanCreateMapForComWithTwoDirectObjects()
        {
            var result = new OrbitMap(new[]
            {
                "COM)B",
                "COM)C"
            });

            result.Objects.Count.ShouldBe(3);
            result.Objects.Count(o => o.IsCom).ShouldBe(1);
            var com = result.Objects.First(o => o.IsCom);
            com.Children.Count.ShouldBe(2);
        }

        [Fact]
        public void CanCalculateOrbitsForComWithTwoDirectObject()
        {
            var map = new OrbitMap(new[]
{
                "COM)B",
                "COM)C"
            });

            var com = map.Objects.First(o => o.IsCom);

            var result = new OrbitCalculator(com).GetTotalOrbits();

            result.ShouldBe(2);
        }
    }
}
