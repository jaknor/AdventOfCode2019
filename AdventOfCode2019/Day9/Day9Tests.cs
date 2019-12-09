namespace AdventOfCode2019.Day9
{
    using Moq;
    using Shouldly;
    using Xunit;

    public class Day9Tests
    {
        [Fact]
        public void CanUseRelativeModeWhenRelativeBaseIsZero()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new []{ 2201, 1, 2, 0, 99 }, input.Object, output.Object)[0];

            result.ShouldBe(3);
        }
    }
}
