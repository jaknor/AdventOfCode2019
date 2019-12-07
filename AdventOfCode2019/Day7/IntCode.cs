namespace AdventOfCode2019.Day7
{
    public class IntCode
    {
        private readonly int[] _values;
        private readonly OpCode _lastOperation;

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
                _lastOperation = opCode;
            }
        }

        public bool Finished => _lastOperation is OpCodeOutput;


        public int this[int index] => _values[index];
    }
}