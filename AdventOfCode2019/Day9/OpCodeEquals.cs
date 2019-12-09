namespace AdventOfCode2019.Day9
{
    public class OpCodeEquals : OpCode
    {
        public OpCodeEquals(int currentIndex, ParameterMode[] parameterMode, IRelativBase relativBase) : base(currentIndex, parameterMode, relativBase) { }
        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;
            var resultIndexIndex = OperatorIndex + 3;

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];
            var indexOfResult = values[resultIndexIndex];

            var parameter1 = GetValueByMode(values, ParameterModes[0], indexOfValue1);
            var parameter2 = GetValueByMode(values, ParameterModes[1], indexOfValue2);
            if (parameter1 == parameter2)
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