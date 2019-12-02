namespace AdventOfCode2019.Day2
{
    public class IntCode
    {
        private readonly int[] _values;

        public IntCode(int[] values, int? noun = null, int? verb = null)
        {
            _values = values;

            if (noun.HasValue)
            {
                _values[1] = noun.Value;
            }

            if (verb.HasValue)
            {
                _values[2] = verb.Value;
            }

            for (int i = 0; i < _values.Length; i+=4)
            {
                var opCode = new OpCode(_values, i);

                if (opCode.Break)
                {
                    break;
                }

                _values[opCode.IndexOfResult] =  opCode.Operation.Apply(_values[opCode.IndexOfValue1], _values[opCode.IndexOfValue2]);
            }
        }

        public int this[int index] => _values[index];
    }
}