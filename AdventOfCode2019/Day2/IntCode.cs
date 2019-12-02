namespace AdventOfCode2019.Day2
{
    public class IntCode
    {
        private readonly int[] _values;

        public IntCode(int[] values)
        {
            _values = values;

            for (int i = 0; i < _values.Length; i+=4)
            {
                if(values[i] == 99)
                {
                    break;
                }

                _values[_values[i + 3]] = _values[_values[i + 1]] + _values[_values[i + 2]];
            }
        }

        public int this[int index] => _values[index];
    }
}