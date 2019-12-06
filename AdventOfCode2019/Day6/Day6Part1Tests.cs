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

            var result = new OrbitCalculator().GetTotalOrbits(com);

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

            var result = new OrbitCalculator().GetTotalOrbits(com);

            result.ShouldBe(2);
        }

        [Fact]
        public void CanCreateMapForComWithOneDirectAndOneInDirectObject()
        {
            var result = new OrbitMap(new[]
            {
                "COM)B",
                "B)C"
            });

            result.Objects.Count.ShouldBe(3);
            result.Objects.Count(o => o.IsCom).ShouldBe(1);
            var com = result.Objects.First(o => o.IsCom);
            com.Children.Count.ShouldBe(1);
            com.Children[0].Children.Count.ShouldBe(1);
        }

        [Fact]
        public void CanCalculateOrbitsForComWithOneDirectAndOneInDirectObject()
        {
            var map = new OrbitMap(new[]
            {
                "COM)B",
                "B)C"
            });

            var com = map.Objects.First(o => o.IsCom);

            var result = new OrbitCalculator().GetTotalOrbits(com);

            result.ShouldBe(3);
        }

        [Fact]
        public void CanCreateMapForComWith1Direct2IndirectAndOneOfThemHasIndirect()
        {
            var result = new OrbitMap(new[]
            {
                "COM)B",
                "B)C",
                "B)E",
                "E)F",
            });

            result.Objects.Count.ShouldBe(5);
            result.Objects.Count(o => o.IsCom).ShouldBe(1);
            var com = result.Objects.First(o => o.IsCom);
            com.Children.Count.ShouldBe(1);
            com.Children[0].Children.Count.ShouldBe(2);
            com.Children[0].Children[0].Children.Count.ShouldBe(0);
            com.Children[0].Children[1].Children.Count.ShouldBe(1);
        }

        public void CanCalculateOrbitsForComWith1Direct2IndirectAndOneOfThemHasIndirect()
        {
            var map = new OrbitMap(new[]
            {
                "COM)B",
                "B)C",
                "B)E",
                "E)F",
            });

            var com = map.Objects.First(o => o.IsCom);

            var result = new OrbitCalculator().GetTotalOrbits(com);

            result.ShouldBe(8);
        }
    }
}
