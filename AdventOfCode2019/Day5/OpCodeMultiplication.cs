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

            values[indexOfResult] = (ParameterModes[0] == ParameterMode.Position ? values[indexOfValue1] : indexOfValue1) * (ParameterModes[1] == ParameterMode.Position ? values[indexOfValue2] : indexOfValue2);

            return (values, 4);
        }
    }
}