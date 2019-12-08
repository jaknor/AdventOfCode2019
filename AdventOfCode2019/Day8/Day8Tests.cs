namespace AdventOfCode2019.Day8
{
    using Shouldly;
    using Xunit;

    public class Day8Tests
    {
        [Fact]
        public void LayerWith1x1ImageNoOnesOrTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("3").ShouldBe((0, 0));
        }

        [Fact]
        public void LayerWith2x2ImageOneOnesAndOneTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("3132").ShouldBe((0,1));
        }

        [Fact]
        public void LayerWith2x2ImageTwoOnesAndTwoTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("1122").ShouldBe((0,4));
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwos()
        {
            var verifier = new ImageLayer();

            verifier.Check("431822851134").ShouldBe((0,6));
        }

        [Fact]
        public void LayerWith1x2ImageZeroAvailable()
        {
            var verifier = new ImageLayer();

            verifier.Check("01").ShouldBe((1,0));
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwosAndThreeZeros()
        {
            var verifier = new ImageLayer();

            verifier.Check("031822801104").ShouldBe((3, 6));
        }
    }
}
