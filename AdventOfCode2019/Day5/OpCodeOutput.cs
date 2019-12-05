namespace AdventOfCode2019.Day5
{
    public class OpCodeOutput : OpCode
    {
        private readonly IOutput _output;

        public OpCodeOutput(int currentIndex, IOutput output) : base(currentIndex)
        {
            _output = output;
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var resultIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[resultIndexIndex];

            _output.Push(values[indexOfResult]);

            return (values, 2);
        }
    }
}