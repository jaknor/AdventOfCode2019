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
    }
}
