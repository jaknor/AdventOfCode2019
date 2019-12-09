namespace AdventOfCode2019.Day9
{
    public abstract class OpCode
    {
        protected readonly int OperatorIndex;
        protected readonly ParameterMode[] ParameterModes;
        private readonly IRelativBase _relativBase;

        public OpCode(int operatorIndex, ParameterMode[] parameterModes, IRelativBase relativeBase)
        {
            OperatorIndex = operatorIndex;
            ParameterModes = parameterModes;
            _relativBase = relativeBase;
        }

        public static OpCode Create(int[] values, int currentIndex, IInput input, IOutput output, RelativeBase @base)
        {
            var operatorIndex = currentIndex;
            
            var instruction = values[operatorIndex].ToString();
            var index = instruction.Length;
            var operatorString = string.Empty;
            while (index > 0 && operatorString.Length<2)
            {
                operatorString = instruction[index - 1] + operatorString;
                index--;
            }

            var parameterMode = new[] { ParameterMode.Position, ParameterMode.Position, ParameterMode.Position };
            instruction = instruction.Remove(instruction.Length - operatorString.Length);
            index = instruction.Length;
            var modeIndex = 0;
            while (index > 0)
            {
                if (instruction[index - 1] == '1')
                {
                    parameterMode[modeIndex] = ParameterMode.Immediate;
                }
                else if (instruction[index - 1] == '2')
                {
                    parameterMode[modeIndex] = ParameterMode.Relative;
                }
                index--;
                modeIndex++;
            }

            var @operator = int.Parse(operatorString);

            switch (@operator)
            {
                case (int)OpCodeOperator.Addition:
                    return new OpCodeAddition(currentIndex, parameterMode, @base);
                case (int)OpCodeOperator.Multiplication:
                    return new OpCodeMultiplication(currentIndex, parameterMode, @base);
                case (int)OpCodeOperator.Input:
                    return new OpCodeInput(currentIndex, input, parameterMode, @base);
                case (int)OpCodeOperator.Output:
                    return new OpCodeOutput(currentIndex, output, parameterMode, @base);
                case (int)OpCodeOperator.JumpIfTrue:
                    return new OpCodeJumpIfTrue(currentIndex, parameterMode, @base);
                case (int)OpCodeOperator.JumpIfFalse:
                    return new OpCodeJumpIfFalse(currentIndex, parameterMode, @base);
                case (int)OpCodeOperator.LessThan:
                    return new OpCodeLessThan(currentIndex, parameterMode, @base);
                case (int)OpCodeOperator.Equal:
                    return new OpCodeEquals(currentIndex, parameterMode, @base);
                case (int)OpCodeOperator.AdjustRelativeBase:
                    return new OpCodeAdjustRelativeBase(currentIndex, parameterMode, @base);
            }

            return new OpCodeBreak(currentIndex, parameterMode, @base);
        }

        public abstract (int[] values, int indexChange) Operate(int[] values);

        protected int GetValueByMode(int[] values, ParameterMode mode, int valueOrIndex)
        {
            if (mode == ParameterMode.Immediate)
            {
                return valueOrIndex;
            }

            var offSet = mode == ParameterMode.Relative ? _relativBase.Get() : 0;

            return values[valueOrIndex + offSet];
        }
    }

    public enum ParameterMode
    {
        Position,
        Immediate,
        Relative
    }
}