namespace AdventOfCode2019.Day9
{
    public class OpCodeJumpIfFalse : OpCode
    {
        public OpCodeJumpIfFalse(int currentIndex, ParameterMode[] parameterMode, IRelativBase relativBase) : base(currentIndex, parameterMode, relativBase)
        {
            
        }

        public override (int[] values, int indexChange) Operate(int[] values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];

            var indexChange = 3;
            if (GetValueByMode(values, ParameterModes[0], indexOfValue1) == 0)
            {
                var parameter2 = GetValueByMode(values, ParameterModes[1], indexOfValue2);
                indexChange = parameter2 - OperatorIndex;
            }

            return (values, indexChange);
        }
    }
}