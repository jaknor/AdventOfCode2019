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
                var opCode = new OpCode(_values, i);

                if (opCode.Break)
                {
                    break;
                }

                _values[opCode.IndexOfResult] = _values[opCode.IndexOfValue1] + _values[opCode.IndexOfValue2];
            }
        }

        public int this[int index] => _values[index];
    }
}