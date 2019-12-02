namespace AdventOfCode2019.Day2
{
    public class OpCode
    {
        private readonly int _operator;

        public OpCode(int[] values, int currentIndex)
        {
            var operatorIndex = currentIndex;
            var firstIndexIndex = currentIndex + 1;
            var secondIndexIndex = currentIndex + 2;
            var resultIndexIndex = currentIndex + 3;

            _operator = values[operatorIndex];
            if (firstIndexIndex < values.Length - 1)
            {
                IndexOfValue1 = values[firstIndexIndex];
            }
            if (secondIndexIndex < values.Length - 1)
            {
                IndexOfValue1 = values[secondIndexIndex];
            }
            if (resultIndexIndex < values.Length - 1)
            {
                IndexOfValue1 = values[resultIndexIndex];
            }
        }

        public int IndexOfValue1 { get; }

        public int IndexOfValue2 { get; }

        public int IndexOfResult { get; }

        public bool Break => _operator == (int) OpCodeOperator.Break;
    }
}