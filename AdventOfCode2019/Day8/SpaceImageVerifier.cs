namespace AdventOfCode2019.Day8
{
    using System.Linq;

    public class SpaceImageVerifier
    {
        public int Verify(EncodedSpaceImage image)
        {
            var lowestZero = image.Layers.Min(l => l.NrOfZeros);

            return image.Layers.Single(l => l.NrOfZeros == lowestZero).Checksum;
        }
    }
}