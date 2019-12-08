namespace AdventOfCode2019.Day8
{
    using System.Linq;

    public class SpaceImageVerifier
    {
        public int Verify(EncodedSpaceImage image)
        {
            var layer = image.Layers.LayerWithLeastBlack();

            return layer.Checksum;
        }
    }
}