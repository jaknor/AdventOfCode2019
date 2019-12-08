namespace AdventOfCode2019.Day8
{
    using Shouldly;
    using Xunit;

    public class Day8Tests
    {
        [Fact]
        public void OneLayer1x1ImageNoOnesOrTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("3").ShouldBe(0);
        }

        [Fact]
        public void OneLayer2x2ImageOneOnesAndOneTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("3132").ShouldBe(1);
        }

        [Fact]
        public void OneLayer2x2ImageTwoOnesAndTwoTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("1122").ShouldBe(4);
        }

        [Fact]
        public void OneLayer3x4ImageThreeOnesAndTwoTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("431022851134").ShouldBe(6);
        }
    }
}
