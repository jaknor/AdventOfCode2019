namespace AdventOfCode2019.Day5
{
    public class OpCodeInput : OpCode
    {
        private readonly IInput _input;
        public OpCodeInput(int currentIndex, IInput input, ParameterMode[] parameterModes) : base(currentIndex, parameterModes)
        {
            _input = input;
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var resultIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[resultIndexIndex];

            values[indexOfResult] = _input.Get();

            return (values, 2);
        }
    }
}