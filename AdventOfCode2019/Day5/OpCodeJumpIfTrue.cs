namespace AdventOfCode2019.Day5
{
    public class OpCodeJumpIfTrue : OpCode
    {
        public OpCodeJumpIfTrue(int currentIndex, ParameterMode[] parameterMode) : base(currentIndex, parameterMode)
        {
            
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];

            var indexChange = 3;
            if ((ParameterModes[0] == ParameterMode.Position ? values[indexOfValue1] : indexOfValue1) > 0)
            {
                values[OperatorIndex] = ParameterModes[1] == ParameterMode.Position ? values[indexOfValue2] : indexOfValue2;
                indexChange = 0;
            }

            return (values, indexChange);
        }
    }
}