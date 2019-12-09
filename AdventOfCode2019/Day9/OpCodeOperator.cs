namespace AdventOfCode2019.Day9
{
    public enum OpCodeOperator
    {
        Addition = 1,
        Multiplication = 2,
        Input = 3,
        Output = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equal = 8,
        AdjustRelativeBase = 9,
        Break = 99,
    }
}