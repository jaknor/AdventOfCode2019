namespace AdventOfCode2019.Day8
{
    using System.Collections.Generic;
    using System.Linq;

    public class SpaceImage
    {
        public SpaceImage(List<List<SpaceImageColor>> rows)
        {
            Rows = rows;
        }

        private List<List<SpaceImageColor>> Rows { get; }

        public SpaceImageColor this[int row, int column] => Rows[row].ElementAt(column);
    }
}