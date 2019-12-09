namespace AdventOfCode2019.Day9
{
    using System.Collections.Generic;

    public class OpCodeOutput : OpCode
    {
        private readonly IOutput _output;

        public OpCodeOutput(long currentIndex, IOutput output, ParameterMode[] parameterModes, IRelativBase relativBase) : base(currentIndex, parameterModes, relativBase)
        {
            _output = output;
        }

        public override (Dictionary<long, long> values, long indexChange) Operate(Dictionary<long, long> values)
        {
            var resultIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[resultIndexIndex];

            _output.Push(GetValueByMode(values, ParameterModes[0], indexOfResult));

            return (values, 2);
        }
    }
}