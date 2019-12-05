namespace AdventOfCode2019.Day5
{
    public abstract class OpCode
    {
        protected readonly int OperatorIndex;

        public OpCode(int operatorIndex)
        {
            OperatorIndex = operatorIndex;
        }

        public static OpCode Create(int[] values, int currentIndex, IInput input, IOutput output)
        {
            var operatorIndex = currentIndex;
            
            var @operator = values[operatorIndex];

            switch (@operator)
            {
                case (int)OpCodeOperator.Addition:
                    return new OpCodeAddition(currentIndex);
                case (int)OpCodeOperator.Multiplication:
                    return new OpCodeMultiplication(currentIndex);
                case (int)OpCodeOperator.Input:
                    return new OpCodeInput(currentIndex, input);
                case (int)OpCodeOperator.Output:
                    return new OpCodeOutput(currentIndex, output);
            }

            return new OpCodeBreak(currentIndex);
        }

        public abstract (int[] values, int indexChange) Operate(int[] values);
    }
}