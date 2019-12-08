namespace AdventOfCode2019.Day8
{
    internal class ImageLayer
    {
        public (int nrOfZeros, int checksum) Check(string imageDate)
        {
            var nrOfZeros = 0;
            var nrOfOnes = 0;
            var nrOfTwos = 0;

            foreach (var pixel in imageDate)
            {
                if (pixel == '0')
                    nrOfZeros++;
                if (pixel == '1')
                    nrOfOnes++;
                if (pixel == '2')
                    nrOfTwos++;
            }

            return (nrOfZeros, nrOfOnes * nrOfTwos);
        }
    }
}