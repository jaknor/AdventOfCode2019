namespace AdventOfCode2019.Day9
{
    using System.Collections.Generic;

    public class OpCodeMultiplication : OpCode
    {
        public OpCodeMultiplication(long operatorIndex, ParameterMode[] parameterModes, IRelativBase relativBase) : base(operatorIndex, parameterModes, relativBase)
        {
        }

        public override (Dictionary<long, long> values, long indexChange) Operate(Dictionary<long, long> values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;
            var resultIndexIndex = OperatorIndex + 3;

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];
            var indexOfResult = values[resultIndexIndex];

            values[indexOfResult] = GetValueByMode(values, ParameterModes[0], indexOfValue1) * GetValueByMode(values, ParameterModes[1], indexOfValue2);

            return (values, 4);
        }
    }
}