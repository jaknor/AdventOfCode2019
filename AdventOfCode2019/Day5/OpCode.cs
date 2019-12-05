namespace AdventOfCode2019.Day5
{
    public abstract class OpCode
    {
        protected readonly int OperatorIndex;

        public OpCode(int operatorIndex)
        {
            OperatorIndex = operatorIndex;
        }

        public static OpCode Create(int[] values, int currentIndex, IInput input)
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
            }

            return new OpCodeBreak(currentIndex);
        }

        public abstract int[] Operate(int[] values);
    }

    public class OpCodeInput : OpCode
    {
        private readonly IInput _input;
        public OpCodeInput(int currentIndex, IInput input) : base(currentIndex)
        {
            _input = input;
        }

        public override int[] Operate(int[] values)
        {
            var resultIndexIndex = OperatorIndex + 1;
            var indexOfResult = values[resultIndexIndex];

            values[indexOfResult] = _input.Get();

            return values;
        }
    }

    public class OpCodeMultiplication : OpCode
    {
        public OpCodeMultiplication(int operatorIndex) : base(operatorIndex)
        {
        }

        public override int[] Operate(int[] values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;
            var resultIndexIndex = OperatorIndex + 3;
            

            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];
            var indexOfResult = values[resultIndexIndex];

            values[indexOfResult] = values[indexOfValue1] * values[indexOfValue2];

            return values;
        }
    }

    public class OpCodeBreak : OpCode
    {
        public OpCodeBreak(int operatorIndex) : base(operatorIndex)
        {
        }

        public override int[] Operate(int[] values)
        {
            return values;
        }
    }

    public class OpCodeAddition : OpCode
    {
        public OpCodeAddition(int operatorIndex) : base(operatorIndex)
        {
        }

        public override int[] Operate(int[] values)
        {
            var firstIndexIndex = OperatorIndex + 1;
            var secondIndexIndex = OperatorIndex + 2;
            var resultIndexIndex = OperatorIndex + 3;


            var indexOfValue1 = values[firstIndexIndex];
            var indexOfValue2 = values[secondIndexIndex];
            var indexOfResult = values[resultIndexIndex];

            values[indexOfResult] = values[indexOfValue1] + values[indexOfValue2];

            return values;
        }
    }
}