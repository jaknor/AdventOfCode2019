namespace AdventOfCode2019.Day9
{
    public class OpCodeOutput : OpCode
    {
        private readonly IOutput _output;

        public OpCodeOutput(int currentIndex, IOutput output, ParameterMode[] parameterModes, IRelativBase relativBase) : base(currentIndex, parameterModes, relativBase)
        {
            _output = output;
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var resultIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[resultIndexIndex];

            _output.Push(GetValueByMode(values, ParameterModes[0], indexOfResult));

            return (values, 2);
        }
    }
}