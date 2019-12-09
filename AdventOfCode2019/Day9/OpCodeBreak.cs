namespace AdventOfCode2019.Day9
{
    using System.Collections.Generic;

    public class OpCodeBreak : OpCode
    {
        public OpCodeBreak(long operatorIndex, ParameterMode[] parameterModes, IRelativBase relativBase) : base(operatorIndex, parameterModes, relativBase)
        {
        }

        public override (Dictionary<long, long> values, long indexChange) Operate(Dictionary<long, long> values)
        {
            return (values, 0);
        }
    }
}