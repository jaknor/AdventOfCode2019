namespace AdventOfCode2019.Day9
{
    using System.Collections.Generic;
    using System.Linq;

    public class IntCode
    {
        private readonly Dictionary<long, long> _values;
        private readonly OpCode _lastOperation;

        public IntCode(long[] values, IInput input, IOutput output)
        {
            long instructionIndex = 0;
            _values = values.ToDictionary(v => instructionIndex++, v => v);
            RelativeBase @base = new RelativeBase();

            long index = 0;
            var opCode = OpCode.Create(_values, index, input, output, @base);
            
            while (!(opCode is OpCodeBreak))
            {
                var result = opCode.Operate(_values);
                _values = result.values;
                index += result.indexChange;
                _lastOperation = opCode;

                opCode = OpCode.Create(_values, index, input, output, @base);
            }
        }

        public bool Finished => _lastOperation is OpCodeOutput;


        public long this[long index] => _values.SafeGet(index);
    }
}