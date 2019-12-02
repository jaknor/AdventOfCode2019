namespace AdventOfCode2019.Day2
{
    public class IntCode
    {
        private readonly int[] _values;

        public IntCode(int[] values)
        {
            _values = values;
        }

        public int this[int index] => _values[index];
    }
}