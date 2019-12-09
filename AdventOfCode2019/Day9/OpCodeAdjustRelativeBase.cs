namespace AdventOfCode2019.Day9
{
    public class OpCodeAdjustRelativeBase : OpCode
    {
        private readonly IRelativBaseModifier _relativBaseModifier;

        public OpCodeAdjustRelativeBase(int currentIndex, ParameterMode[] parameterMode, IRelativBaseModifier relativBaseModifier) : base(currentIndex, parameterMode, (IRelativBase)relativBaseModifier)
        {
            _relativBaseModifier = relativBaseModifier;
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var parameterIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[parameterIndexIndex];

            _relativBaseModifier.Update(indexOfResult);

            return (values, 2);
        }
    }
}