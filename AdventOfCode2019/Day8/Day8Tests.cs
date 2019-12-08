namespace AdventOfCode2019.Day8
{
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class Day8Tests
    {
        [Fact]
        public void LayerWith1x1ImageNoOnesOrTwos()
        {
            var layer = new ImageLayer("3", 1, 1);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(0);
        }

        [Fact]
        public void LayerWith2x2ImageOneOnesAndOneTwos()
        {
            var layer = new ImageLayer("3132", 2,2);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(1);
        }

        [Fact]
        public void LayerWith2x2ImageTwoOnesAndTwoTwos()
        {
            var layer = new ImageLayer("1122",2,2);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(4);
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwos()
        {
            var layer = new ImageLayer("431822851134",3,4);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(6);
        }

        [Fact]
        public void LayerWith1x2ImageZeroAvailable()
        {
            var layer = new ImageLayer("01",1,2);

            layer.NrOfZeros.ShouldBe(1);
            layer.Checksum.ShouldBe(0);
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwosAndThreeZeros()
        {
            var layer = new ImageLayer("031822801104",3,4);

            layer.NrOfZeros.ShouldBe(3);
            layer.Checksum.ShouldBe(6);
        }

        [Fact]
        public void WhenTwoLayersFirstOneWithLowestZerosThenChecksumFromFirstLayerReturned()
        {
            var verifier = new SpaceImageVerifier();

            var result = verifier.Verify(new EncodedSpaceImage("12342210", 4, 1));

            result.ShouldBe(1);
        }

        [Fact]
        public void MultiRowImageFirstLayerBestOption()
        {
            var verifier = new SpaceImageVerifier();

            var result = verifier.Verify(new EncodedSpaceImage("1234226012302210", 4, 2));

            result.ShouldBe(3);
        }

        [Fact]
        public void FullInput()
        {
            var input = new CalendarLineInput("Day8\\Day8Input.txt");
            var values = input.ReadString();

            var verifier = new SpaceImageVerifier();

            var result = verifier.Verify(new EncodedSpaceImage(values[0], 25, 6));

            result.ShouldBe(1560);
        }

        [Fact]
        public void RenderImageOneLayerAllBlack()
        {
            var renderer = new SpaceImageRenderer();

            var decodedSpaceImage = renderer.Render(new EncodedSpaceImage("0000", 2, 2));

            decodedSpaceImage[0,0].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[0,1].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[1,0].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[1,1].ShouldBe(SpaceImageColor.Black);
        }
    }

    public class SpaceImageRenderer
    {
        public SpaceImage Render(EncodedSpaceImage encodedSpaceImage)
        {
            var rows = new List<List<SpaceImageColor>>();

            for (int rowIndex = 0; rowIndex < encodedSpaceImage.Height; rowIndex++)
            {
                var row = new List<SpaceImageColor>();
                for (int columnIndex = 0; columnIndex < encodedSpaceImage.Width; columnIndex++)
                {
                    row.Add(encodedSpaceImage.Layers[0][rowIndex, columnIndex]);
                }
                rows.Add(row);
            }

            return new SpaceImage(rows);
        }
    }
}
