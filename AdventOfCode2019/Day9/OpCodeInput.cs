namespace AdventOfCode2019.Day9
{
    using System.Collections.Generic;

    public class OpCodeInput : OpCode
    {
        private readonly IInput _input;
        public OpCodeInput(long currentIndex, IInput input, ParameterMode[] parameterModes, IRelativBase relativBase) : base(currentIndex, parameterModes, relativBase)
        {
            _input = input;
        }

        public override (Dictionary<long, long> values, long indexChange) Operate(Dictionary<long, long> values)
        {
            var resultIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[resultIndexIndex];

            values[indexOfResult] = _input.Get();

            return (values, 2);
        }
    }
}