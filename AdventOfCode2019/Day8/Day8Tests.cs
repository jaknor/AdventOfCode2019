namespace AdventOfCode2019.Day8
{
    using Shouldly;
    using Xunit;

    public class Day8Tests
    {
        [Fact]
        public void OneLayer1x1ImageNoOnesOrTwos()
        {
            var verifier = new SpaceImageVerifier();

            verifier.Check("3",1,1).ShouldBe(0);
        }
    }

    internal class SpaceImageVerifier
    {
        public int Check(string imageDate, int width, int height)
        {
            return 0;
        }
    }
}
