namespace AdventOfCode2019.Day5
{
    public class OpCodeLessThan : OpCode
    {
        public OpCodeLessThan(int currentIndex, ParameterMode[] parameterMode) : base(currentIndex, parameterMode) { }
        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;
            var resultIndexIndex = OperatorIndex + 3;

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];
            var indexOfResult = values[resultIndexIndex];

            var parameter1 = (ParameterModes[0] == ParameterMode.Position ? values[indexOfValue1] : indexOfValue1);
            var parameter2 = (ParameterModes[1] == ParameterMode.Position ? values[indexOfValue2] : indexOfValue2);
            if (parameter1 < parameter2)
            {
                values[indexOfResult] = 1;
            }
            else
            {
                values[indexOfResult] = 0;
            }

            return (values, 4);
        }
    }
}