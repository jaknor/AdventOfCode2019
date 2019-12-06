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

        [Fact]
        public void CanCreateMapForExampleMap()
        {
            var result = new OrbitMap(new[]
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
                "K)L"
            });

            result.Objects.Count.ShouldBe(12);
            result.Objects.Count(o => o.IsCom).ShouldBe(1);
            var com = result.Objects.First(o => o.IsCom);
            com.Children.Count.ShouldBe(1);
            var B = com.Children[0];
            var C = B.Children[0];
            var D = C.Children[0];
            var E = D.Children[0];
            var F = E.Children[0];
            var G = B.Children[1];
            var H = G.Children[0];
            var I = D.Children[1];
            var J = E.Children[1];
            var K = J.Children[0];
            var L = K.Children[0];

            B.Children.Count.ShouldBe(2);
            C.Children.Count.ShouldBe(1);
            D.Children.Count.ShouldBe(2);
            E.Children.Count.ShouldBe(2);
            F.Children.Count.ShouldBe(0);
            G.Children.Count.ShouldBe(1);
            H.Children.Count.ShouldBe(0);
            I.Children.Count.ShouldBe(0);
            J.Children.Count.ShouldBe(1);
            K.Children.Count.ShouldBe(1);
            L.Children.Count.ShouldBe(0);
        }

        [Fact]
        public void CanCalculateOrbitsForExampleMap()
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
                "K)L"
            });

            var com = map.Objects.First(o => o.IsCom);

            var result = new OrbitCalculator().GetTotalOrbits(com);

            result.ShouldBe(42);
        }

        [Fact]
        public void CanCalculateOrbitsForExampleMapOutOfOrder()
        {
            var map = new OrbitMap(new[]
            {
                "J)K",
                "B)C",
                "K)L",
                "C)D",
                "D)E",
                "G)H",
                "COM)B",
                "E)F",
                "B)G",
                "D)I",
                "E)J"
            });

            var com = map.Objects.First(o => o.IsCom);

            var result = new OrbitCalculator().GetTotalOrbits(com);

            result.ShouldBe(42);
        }
    }
}
