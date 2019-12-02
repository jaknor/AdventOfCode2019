namespace AdventOfCode2019.Day2
{
    using Shouldly;
    using Xunit;

    public class Day2Part1Tests
    {
        [Fact]
        public void IntcodeWithOnlyOpCode99()
        {
            var valueAt0 = new IntCode(new int[]{99})[0];

            valueAt0.ShouldBe(99);
        }

        [Fact]
        public void IntcodeWithAdditionOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new int[] { 1, 0, 0, 0, 99 })[0];

            valueAt0.ShouldBe(2);
        }

        [Fact]
        public void IntcodeWithInsufficientNumbersForFinalOpCode()
        {
            var valueAt0 = new IntCode(new int[] { 1, 5, 0, 0, 99, 5 })[0];

            valueAt0.ShouldBe(6);
        }

        [Fact]
        public void IntcodeWithMultiplicationOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new int[] { 2, 1, 1, 0, 99 })[0];

            valueAt0.ShouldBe(1);
        }

        [Fact]
        public void IntcodeWithMultipleDifferentOperations()
        {
            var valueAt0 = new IntCode(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 })[0];

            valueAt0.ShouldBe(30);
        }

        [Fact]
        public void FullInput()
        {
            var input = new CalendarCommaInput("Day2\\Day2Input.txt");

            var values = input.Read();
            
            var valueAt0 = new IntCode(values, 12, 2)[0];

            valueAt0.ShouldBe(2692315);
        }
    }
}
