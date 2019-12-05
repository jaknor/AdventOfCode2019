namespace AdventOfCode2019.Day5
{
    public class OpCodeMultiplication : OpCode
    {
        public OpCodeMultiplication(int operatorIndex, ParameterMode[] parameterModes) : base(operatorIndex, parameterModes)
        {
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;
            var resultIndexIndex = OperatorIndex + 3;
            

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];
            var indexOfResult = values[resultIndexIndex];

            values[indexOfResult] = values[indexOfValue1] * values[indexOfValue2];

            return (values, 4);
        }
    }
}