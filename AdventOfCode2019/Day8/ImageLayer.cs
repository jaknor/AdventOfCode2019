namespace AdventOfCode2019.Day8
{
    internal class ImageLayer
    {
        public ImageLayer(string imageData)
        {
            var nrOfZeros = 0;
            var nrOfOnes = 0;
            var nrOfTwos = 0;

            foreach (var pixel in imageData)
            {
                if (pixel == '0')
                    nrOfZeros++;
                if (pixel == '1')
                    nrOfOnes++;
                if (pixel == '2')
                    nrOfTwos++;
            }

            NrOfZeros = nrOfZeros;
            Checksum = nrOfOnes * nrOfTwos;
        }

        public int Checksum { get; }

        public int NrOfZeros { get; }
    }
}