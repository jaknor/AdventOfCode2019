namespace AdventOfCode2019.Day5
{
    using Moq;
    using Shouldly;
    using Xunit;

    public class Day5Part1Tests
    {
        private Mock<IInput> _input;
        private Mock<IOutput> _output;

        public Day5Part1Tests()
        {
            _input = new Mock<IInput>();
            _output = new Mock<IOutput>();
        }

        [Fact]
        public void IntcodeWithOnlyOpCode99()
        {
            var valueAt0 = new IntCode(new int[]{99}, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(99);
        }

        [Fact]
        public void IntcodeWithAdditionOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new int[] { 01, 0, 0, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(2);
        }

        [Fact]
        public void IntcodeWithInsufficientNumbersForFinalOpCode()
        {
            var valueAt0 = new IntCode(new int[] { 01, 5, 0, 0, 99, 5 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(6);
        }

        [Fact]
        public void IntcodeWithMultiplicationOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new int[] { 02, 1, 1, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(1);
        }

        [Fact]
        public void IntcodeWithMultipleDifferentOperations()
        {
            var valueAt0 = new IntCode(new int[] { 01, 1, 1, 4, 99, 5, 6, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(30);
        }

        [Fact]
        public void IntcodeWithInputOpCodeStopAfterOneIteration()
        {
            var input = 42;
            _input.Setup(x => x.Get()).Returns(input);

            var valueAt0 = new IntCode(new int[] { 03, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(input);
        }

        [Fact]
        public void IntcodeWithInputOpCodeFollowedByAddStopAfterTwoIteration()
        {
            var input = 42;
            _input.Setup(x => x.Get()).Returns(input);

            var valueAt0 = new IntCode(new int[] { 03, 0, 1, 0, 6, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(input + 99);
        }

        [Fact]
        public void IntcodeWithOutputOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new int[] { 04, 2, 99 }, _input.Object, _output.Object)[0];

            _output.Verify(_ => _.Push(99));
        }

        [Fact]
        public void IntcodeWithOutputOpCodeDoesNotStop()
        {
            var valueAt0 = new IntCode(new int[] { 04, 4, 1, 2, 6, 0, 99 }, _input.Object, _output.Object)[0];

            _output.Verify(_ => _.Push(6));
            valueAt0.ShouldBe(100);
        }

        [Fact]
        public void ParametersToAddForAddInstructionAreImmediate()
        {
            var valueAt0 = new IntCode(new int[] { 1101, 5, 5, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(10);
        }

        [Fact]
        public void ParametersToMultiplyForMultiplyInstructionAreImmediate()
        {
            var valueAt0 = new IntCode(new int[] { 1102, 5, 5, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(25);
        }

        [Fact]
        public void OutputParameterImmediate()
        {
            var valueAt0 = new IntCode(new int[] { 104, 25, 99 }, _input.Object, _output.Object)[0];

            _output.Verify(_ => _.Push(25));
        }
    }
}
