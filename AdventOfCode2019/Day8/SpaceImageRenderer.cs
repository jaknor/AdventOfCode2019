namespace AdventOfCode2019.Day8
{
    using System.Collections.Generic;

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
                    row.Add(encodedSpaceImage.Layers[rowIndex, columnIndex]);
                }
                rows.Add(row);
            }

            return new SpaceImage(rows);
        }
    }
}