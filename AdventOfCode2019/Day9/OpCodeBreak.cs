namespace AdventOfCode2019.Day9
{
    public class OpCodeBreak : OpCode
    {
        public OpCodeBreak(int operatorIndex, ParameterMode[] parameterModes, IRelativBase relativBase) : base(operatorIndex, parameterModes, relativBase)
        {
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            return (values, 0);
        }
    }
}