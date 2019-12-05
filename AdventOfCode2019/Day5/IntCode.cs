namespace AdventOfCode2019.Day5
{
    public class IntCode
    {
        private readonly int[] _values;

        public IntCode(int[] values, IInput input, IOutput output)
        {
            _values = values;

            int indexChange;
            for (int i = 0; i < _values.Length; i+=indexChange)
            {
                var opCode = OpCode.Create(_values, i, input, output);

                if (opCode is OpCodeBreak)
                    break;

                var result = opCode.Operate(_values);
                _values = result.values;
                indexChange = result.indexChange;
            }
        }

        public int this[int index] => _values[index];
    }
}