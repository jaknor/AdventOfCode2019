namespace AdventOfCode2019.Day8
{
    using System.Collections.Generic;
    using System.Linq;

    public class ImageLayer
    {
        private List<List<SpaceImageColor>> _rows;

        public ImageLayer(string imageData, int width, int height)
        {
            var rows = new List<List<SpaceImageColor>>();
            for (int rowIndex = 0; rowIndex < height; rowIndex++)
            {
                var row = new List<SpaceImageColor>();
                for (int columnIndex = 0; columnIndex < width; columnIndex++)
                {
                    row.Add(ToColor(imageData[rowIndex * width + columnIndex]));
                }
                rows.Add(row);
            }

            _rows = rows;

            NrOfZeros = rows.SelectMany(r => r.Select(c => c)).Count(p => p == SpaceImageColor.Black);
            Checksum = rows.SelectMany(r => r.Select(c => c)).Count(p => p == SpaceImageColor.White) * rows.SelectMany(r => r.Select(c => c)).Count(p => p == SpaceImageColor.Transparent);
        }

        private SpaceImageColor ToColor(char c)
        {
            return (SpaceImageColor) int.Parse(c.ToString());
        }

        public int Checksum { get; }

        public int NrOfZeros { get; }

        public SpaceImageColor this[int row, int column] => _rows[row].ElementAt(column);
    }
}