namespace AdventOfCode2019.Day9
{
    using System.Collections.Generic;

    public class OpCodeJumpIfFalse : OpCode
    {
        public OpCodeJumpIfFalse(long currentIndex, ParameterMode[] parameterMode, IRelativBase relativBase) : base(currentIndex, parameterMode, relativBase)
        {
            
        }

        public override (Dictionary<long, long> values, long indexChange) Operate(Dictionary<long, long> values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];

            long indexChange = 3;
            if (GetValueByMode(values, ParameterModes[0], indexOfValue1) == 0)
            {
                var parameter2 = GetValueByMode(values, ParameterModes[1], indexOfValue2);
                indexChange = parameter2 - OperatorIndex;
            }

            return (values, indexChange);
        }
    }
}