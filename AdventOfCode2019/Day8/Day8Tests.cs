namespace AdventOfCode2019.Day8
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using Shouldly;
    using Xunit;
    using Xunit.Abstractions;

    public class Day8Tests
    {
        private readonly ITestOutputHelper output;

        public Day8Tests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void LayerWith1x1ImageNoOnesOrTwos()
        {
            var layer = new ImageLayer(0,"3", 1, 1);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(0);
        }

        [Fact]
        public void LayerWith2x2ImageOneOnesAndOneTwos()
        {
            var layer = new ImageLayer(0, "3132", 2,2);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(1);
        }

        [Fact]
        public void LayerWith2x2ImageTwoOnesAndTwoTwos()
        {
            var layer = new ImageLayer(0, "1122",2,2);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(4);
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwos()
        {
            var layer = new ImageLayer(0, "431822851134",3,4);

            layer.NrOfZeros.ShouldBe(0);
            layer.Checksum.ShouldBe(6);
        }

        [Fact]
        public void LayerWith1x2ImageZeroAvailable()
        {
            var layer = new ImageLayer(0, "01",1,2);

            layer.NrOfZeros.ShouldBe(1);
            layer.Checksum.ShouldBe(0);
        }

        [Fact]
        public void LayerWith3x4ImageThreeOnesAndTwoTwosAndThreeZeros()
        {
            var layer = new ImageLayer(0, "031822801104",3,4);

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

        [Fact]
        public void RenderImageOneLayerMix()
        {
            var renderer = new SpaceImageRenderer();

            var decodedSpaceImage = renderer.Render(new EncodedSpaceImage("1020", 2, 2));

            decodedSpaceImage[0, 0].ShouldBe(SpaceImageColor.White);
            decodedSpaceImage[0, 1].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[1, 0].ShouldBe(SpaceImageColor.Transparent);
            decodedSpaceImage[1, 1].ShouldBe(SpaceImageColor.Black);
        }

        [Fact]
        public void RenderImageTwoLayerFirstLayerWins()
        {
            var renderer = new SpaceImageRenderer();

            var decodedSpaceImage = renderer.Render(new EncodedSpaceImage("00001111", 2, 2));

            decodedSpaceImage[0, 0].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[0, 1].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[1, 0].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[1, 1].ShouldBe(SpaceImageColor.Black);
        }

        [Fact]
        public void RenderImageTwoLayerTransperentGoesToNextLayer()
        {
            var renderer = new SpaceImageRenderer();

            var decodedSpaceImage = renderer.Render(new EncodedSpaceImage("00021111", 2, 2));

            decodedSpaceImage[0, 0].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[0, 1].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[1, 0].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[1, 1].ShouldBe(SpaceImageColor.White);
        }

        [Fact]
        public void RenderExample()
        {
            var renderer = new SpaceImageRenderer();

            var decodedSpaceImage = renderer.Render(new EncodedSpaceImage("0222112222120000", 2, 2));

            decodedSpaceImage[0, 0].ShouldBe(SpaceImageColor.Black);
            decodedSpaceImage[0, 1].ShouldBe(SpaceImageColor.White);
            decodedSpaceImage[1, 0].ShouldBe(SpaceImageColor.White);
            decodedSpaceImage[1, 1].ShouldBe(SpaceImageColor.Black);
        }

        [Fact]
        public void FullInputPart2()
        {
            var input = new CalendarLineInput("Day8\\Day8Input.txt");
            var values = input.ReadString();

            var renderer = new SpaceImageRenderer();

            var image = renderer.Render(new EncodedSpaceImage(values[0], 25, 6));

            Bitmap bmp = new Bitmap(25, 6);

            for (int i = 0; i < 6; i++)
            {
                var line = string.Empty;
                for (int j = 0; j < 25; j++)
                {
                    line += image[i, j] == SpaceImageColor.Black ? " " : "#";
                    bmp.SetPixel(j, i, image[i, j] == SpaceImageColor.Black ? Color.Black : Color.White);
                }

                output.WriteLine(line);
            }

            bmp.Save("Day8Part2.png", ImageFormat.Png);
        }
    }
}
