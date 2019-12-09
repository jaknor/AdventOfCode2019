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

        [Fact]
        public void CanModifyRelativeBaseAndUseItForAddCalculation()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new[] { 09, 1, 2201, 1, 2, 0, 99 }, input.Object, output.Object)[0];

            result.ShouldBe(2202);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForMultiplication()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new[] { 09, 1, 2202, 1, 3, 0, 99 }, input.Object, output.Object)[0];

            result.ShouldBe(2202 * 3);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForEquals()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new[] { 09, 1, 2208, 0, 6, 0, 99, 1 }, input.Object, output.Object)[0];

            result.ShouldBe(1);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForJumpIfFalse()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new[] { 09, 1, 2206, 5, 11, 99, 0, 1101, 1, 1, 0, 99, 7}, input.Object, output.Object)[0];

            result.ShouldBe(2);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForJumpIfTrue()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new[] { 09, 1, 2205, 5, 11, 99, 1, 1101, 1, 1, 0, 99, 7 }, input.Object, output.Object)[0];

            result.ShouldBe(2);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForLessThan()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new[] { 09, 1, 2207, 6, 7, 0, 99, 5, 10 }, input.Object, output.Object)[0];

            result.ShouldBe(1);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForOutput()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new[] { 09, 1, 2204, 1, 99 }, input.Object, output.Object)[0];

            output.Verify(o => o.Push(2204), Times.Once);
        }
    }
}
