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

            var result = new IntCode(new long[]{ 2201, 1, 2, 0, 99 }, input.Object, output.Object)[0];

            result.ShouldBe(3);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForAddCalculation()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new long[] { 09, 1, 2201, 1, 2, 0, 99 }, input.Object, output.Object)[0];

            result.ShouldBe(2202);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForMultiplication()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new long[] { 09, 1, 2202, 1, 3, 0, 99 }, input.Object, output.Object)[0];

            result.ShouldBe(2202 * 3);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForEquals()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new long[] { 09, 1, 2208, 0, 6, 0, 99, 1 }, input.Object, output.Object)[0];

            result.ShouldBe(1);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForJumpIfFalse()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new long[] { 09, 1, 2206, 5, 11, 99, 0, 1101, 1, 1, 0, 99, 7}, input.Object, output.Object)[0];

            result.ShouldBe(2);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForJumpIfTrue()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new long[] { 09, 1, 2205, 5, 11, 99, 1, 1101, 1, 1, 0, 99, 7 }, input.Object, output.Object)[0];

            result.ShouldBe(2);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForLessThan()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new long[] { 09, 1, 2207, 6, 7, 0, 99, 5, 10 }, input.Object, output.Object)[0];

            result.ShouldBe(1);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItForOutput()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var result = new IntCode(new long[] { 09, 1, 2204, 1, 99 }, input.Object, output.Object)[0];

            output.Verify(o => o.Push(2204), Times.Once);
        }

        [Fact]
        public void CanModifyRelativeBaseAndUseItToStoreInput()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            input.Setup(i => i.Get()).Returns(234);

            var result = new IntCode(new long[] { 09, 1, 203, -1, 99 }, input.Object, output.Object)[0];

            result.ShouldBe(234);
        }

        [Fact]
        public void Example1()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var values = new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            new IntCode(values, input.Object, output.Object);

            int index = 0;
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
            ((long)output.Invocations[index].Arguments[0]).ShouldBe(values[index++]);
        }

        [Fact]
        public void Example2()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var values = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            new IntCode(values, input.Object, output.Object);

            
            ((long)output.Invocations[0].Arguments[0]).ToString().Length.ShouldBe(16);
        }

        [Fact]
        public void Example3()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            var values = new long[] { 104, 1125899906842624, 99 };
            new IntCode(values, input.Object, output.Object);


            ((long)output.Invocations[0].Arguments[0]).ShouldBe(values[1]);
        }

        [Fact]
        public void FullInputPart1()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            input.Setup(i => i.Get()).Returns(1);

            var instructions = new CalendarCommaInput("Day9\\Day9Input.txt");
            var values = instructions.ReadLong();

            new IntCode(values, input.Object, output.Object);

            output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            output.Verify(o => o.Push(3340912345), Times.Once);
        }

        [Fact]
        public void FullInputPart2()
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            input.Setup(i => i.Get()).Returns(2);

            var instructions = new CalendarCommaInput("Day9\\Day9Input.txt");
            var values = instructions.ReadLong();

            new IntCode(values, input.Object, output.Object);

            output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            output.Verify(o => o.Push(51754), Times.Once);
        }
    }
}
