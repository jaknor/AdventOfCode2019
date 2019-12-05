namespace AdventOfCode2019.Day5
{
    public class IntCode
    {
        private readonly int[] _values;

        public IntCode(int[] values, IInput input)
        {
            _values = values;

            for (int i = 0; i < _values.Length; i+=4)
            {
                var opCode = OpCode.Create(_values, i, input);

                var valuesBefore = _values.Clone();
                _values = opCode.Operate(_values);

                if (valuesBefore == _values)
                    break;
            }
        }

        public int this[int index] => _values[index];
    }
}