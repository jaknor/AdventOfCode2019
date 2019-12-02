namespace AdventOfCode2019
{
    using System.IO;
    using System.Linq;

    public class CalendarLineInput
    {
        private readonly string _path;

        public CalendarLineInput(string path)
        {
            _path = path;
        }

        public int[] Read()
        {
            var lines = File.ReadLines(_path);

            return lines.Select(l => int.Parse(l)).ToArray();
        }
    }
}
