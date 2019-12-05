namespace AdventOfCode2019.Day5
{
    using System.ComponentModel.DataAnnotations;

    public abstract class OpCode
    {
        protected readonly int OperatorIndex;
        protected readonly ParameterMode[] ParameterModes;

        public OpCode(int operatorIndex, ParameterMode[] parameterModes)
        {
            OperatorIndex = operatorIndex;
            ParameterModes = parameterModes;
        }

        public static OpCode Create(int[] values, int currentIndex, IInput input, IOutput output)
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
                index--;
                modeIndex++;
            }

            var @operator = int.Parse(operatorString);

            switch (@operator)
            {
                case (int)OpCodeOperator.Addition:
                    return new OpCodeAddition(currentIndex, parameterMode);
                case (int)OpCodeOperator.Multiplication:
                    return new OpCodeMultiplication(currentIndex, parameterMode);
                case (int)OpCodeOperator.Input:
                    return new OpCodeInput(currentIndex, input, parameterMode);
                case (int)OpCodeOperator.Output:
                    return new OpCodeOutput(currentIndex, output, parameterMode);
                case (int)OpCodeOperator.JumpIfTrue:
                    return new OpCodeJumpIfTrue(currentIndex, parameterMode);
                case (int)OpCodeOperator.JumpIfFalse:
                    return new OpCodeJumpIfFalse(currentIndex, parameterMode);
                case (int)OpCodeOperator.LessThan:
                    return new OpCodeLessThan(currentIndex, parameterMode);
            }

            return new OpCodeBreak(currentIndex, parameterMode);
        }

        public abstract (int[] values, int indexChange) Operate(int[] values);
    }

    public enum ParameterMode
    {
        Position,
        Immediate
    }
}