namespace AdventOfCode2019.Day5
{
    public class OpCodeBreak : OpCode
    {
        public OpCodeBreak(int operatorIndex, ParameterMode[] parameterModes) : base(operatorIndex, parameterModes)
        {
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            return (values, 0);
        }
    }
}