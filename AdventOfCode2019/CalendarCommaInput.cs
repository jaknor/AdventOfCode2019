namespace AdventOfCode2019
{
    using System.IO;
    using System.Linq;

    public class CalendarCommaInput
    {
        private readonly string _path;

        public CalendarCommaInput(string path)
        {
            _path = path;
        }

        public int[] Read()
        {
            var lines = File.ReadLines(_path).First().Split(",");

            return lines.Select(l => int.Parse(l)).ToArray();
        }
    }
}
