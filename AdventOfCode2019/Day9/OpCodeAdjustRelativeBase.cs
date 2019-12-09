namespace AdventOfCode2019.Day9
{
    using System.Collections.Generic;

    public class OpCodeAdjustRelativeBase : OpCode
    {
        private readonly IRelativBaseModifier _relativBaseModifier;

        public OpCodeAdjustRelativeBase(long currentIndex, ParameterMode[] parameterMode, IRelativBaseModifier relativBaseModifier) : base(currentIndex, parameterMode, (IRelativBase)relativBaseModifier)
        {
            _relativBaseModifier = relativBaseModifier;
        }

        public override (Dictionary<long, long> values, long indexChange) Operate(Dictionary<long, long> values)
        {
            var parameterIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[parameterIndexIndex];

            _relativBaseModifier.Update(GetValueByMode(values, ParameterModes[0], indexOfResult));

            return (values, 2);
        }
    }
}