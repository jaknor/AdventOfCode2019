namespace AdventOfCode2019.Day7
{
    internal class MultiplicationOperator : IOperation
    {
        public int Apply(int value1, int value2)
        {
            return value1 * value2;
        }
    }
}