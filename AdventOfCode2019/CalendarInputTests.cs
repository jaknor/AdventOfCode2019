namespace AdventOfCode2019
{
    using Shouldly;
    using Xunit;

    public class CalendarInputTests
    {
        [Fact]
        public void InputOfIntegers()
        {
            var expectedArray = new int[] {113045, 63499, 117820, 67582};

            var result = new CalendarInput("CalendarInputTestInput\\IntegerInput.txt").Read();

            result.ShouldBe(expectedArray);
        }
    }
}
