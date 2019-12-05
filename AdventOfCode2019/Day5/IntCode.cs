namespace AdventOfCode2019.Day5
{
    using System.Linq;

    public class IntCode
    {
        private readonly int[] _values;

        public IntCode(int[] values, IInput input)
        {
            _values = values;

            var indexChange = 0;
            for (int i = 0; i < _values.Length; i+=indexChange)
            {
                var opCode = OpCode.Create(_values, i, input);

                int[] valuesBefore = new int[_values.Length];
                _values.CopyTo(valuesBefore, 0);
                var result = opCode.Operate(_values);
                _values = result.values;
                indexChange = result.indexChange;

                if (valuesBefore.SequenceEqual(_values))
                    break;
            }
        }

        public int this[int index] => _values[index];
    }
}