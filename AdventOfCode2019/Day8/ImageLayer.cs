﻿namespace AdventOfCode2019.Day8
{
    internal class ImageLayer
    {
        public int Check(string imageDate)
        {
            var nrOfOnes = 0;
            var nrOfTwos = 0;

            foreach (var pixel in imageDate)
            {
                if (pixel == '1')
                    nrOfOnes++;
                if (pixel == '2')
                    nrOfTwos++;
            }

            return nrOfOnes * nrOfTwos;
        }
    }
}