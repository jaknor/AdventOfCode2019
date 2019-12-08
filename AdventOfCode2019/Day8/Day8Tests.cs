namespace AdventOfCode2019.Day8
{
    using System.Collections.Generic;
    using System.Linq;
    using Shouldly;
    using Xunit;

    public class Day8Tests
    {
        [Fact]
        public void LayerWith1x1ImageNoOnesOrTwos()
        {
            var layer = new ImageLayer("3");

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(0);
        }

        [Fact]
        public void LayerWith2x2ImageOneOnesAndOneTwos()
        {
            var layer = new ImageLayer("3132");

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(1);
        }

        [Fact]
        public void LayerWith2x2ImageTwoOnesAndTwoTwos()
        {
            var layer = new ImageLayer("1122");

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(4);
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwos()
        {
            var layer = new ImageLayer("431822851134");

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(6);
        }

        [Fact]
        public void LayerWith1x2ImageZeroAvailable()
        {
            var layer = new ImageLayer("01");

            layer.NrOfZeros.ShouldBe(1);
            layer.Checksum.ShouldBe(0);
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwosAndThreeZeros()
        {
            var layer = new ImageLayer("031822801104");

            layer.NrOfZeros.ShouldBe(3);
            layer.Checksum.ShouldBe(6);
        }

        [Fact]
        public void WhenTwoLayersFirstOneWithLowestZerosThenChecksumFromFirstLayerReturned()
        {
            var verifier = new SpaceImageVerifier();

            var result = verifier.Verify("12342210", 4, 1);

            result.ShouldBe(1);
        }

        [Fact]
        public void MultiRowImageFirstLayerBestOption()
        {
            var verifier = new SpaceImageVerifier();

            var result = verifier.Verify("1234226012302210", 4, 2);

            result.ShouldBe(3);
        }

        [Fact]
        public void FullInput()
        {
            var input = new CalendarLineInput("Day8\\Day8Input.txt");
            var values = input.ReadString();

            var verifier = new SpaceImageVerifier();

            var result = verifier.Verify(values[0], 25, 6);

            result.ShouldBe(1560);
        }
    }

    public class SpaceImageVerifier
    {
        public int Verify(string imageData, int width, int height)
        {
            var layers = new List<ImageLayer>();

            var layerLength = width * height;
            while (imageData.Length > layerLength)
            {
                layers.Add(new ImageLayer(imageData.Substring(0, layerLength)));
                imageData = imageData.Substring(layerLength);
            }

            var lowestZero = layers.Min(l => l.NrOfZeros);

            return layers.Single(l => l.NrOfZeros == lowestZero).Checksum;
        }
    }
}
