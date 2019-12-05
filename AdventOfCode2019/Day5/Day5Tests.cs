namespace AdventOfCode2019.Day5
{
    using Moq;
    using Shouldly;
    using Xunit;

    public class Day5Tests
    {
        private Mock<IInput> _input;
        private Mock<IOutput> _output;

        public Day5Tests()
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

        [Fact]
        public void NegativeValuesAsImmediate()
        {
            var valueAt0 = new IntCode(new int[] { 1101, 100, -1, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(99);
        }

        [Fact]
        public void ProgramConsideredFinishedIfHaltAfterOutput()
        {
            var intCode = new IntCode(new int[] { 04, 0, 99 }, _input.Object, _output.Object);

            intCode.Finished.ShouldBeTrue();
        }

        [Fact]
        public void ProgramNotConsideredFinishedIfHaltAfterAddition()
        {
            var intCode = new IntCode(new int[] { 01, 0, 0, 0, 99 }, _input.Object, _output.Object);

            intCode.Finished.ShouldBeFalse();
        }

        [Fact]
        public void ProgramNotConsideredFinishedIfHaltAfterMultiply()
        {
            var intCode = new IntCode(new int[] { 02, 0, 0, 0, 99 }, _input.Object, _output.Object);

            intCode.Finished.ShouldBeFalse();
        }

        [Fact]
        public void Part1FullInput()
        {
            var input = new CalendarCommaInput("Day5\\Day5Input.txt");
            var values = input.Read();

            _input.Setup(i => i.Get()).Returns(1);

            new IntCode(values, _input.Object, _output.Object);

            _output.Verify(o => o.Push(0), Times.Exactly(9));
            _output.Verify(o => o.Push(12440243));
        }

        [Fact]
        public void OpCodeJumpIfTrueWithFalseAndPositional()
        {
            var valueAt0 = new IntCode(new int[] { 05, 2, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(5);
        }

        [Fact]
        public void OpCodeJumpIfTrueWithTrueAndPositional()
        {
            var valueAt0 = new IntCode(new int[] { 05, 1, 1, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(2);
        }

        [Fact]
        public void OpCodeJumpIfTrueWithFalseAndImmediate()
        {
            var valueAt0 = new IntCode(new int[] { 105, 0, 1, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(105);
        }

        [Fact]
        public void OpCodeJumpIfTrueWithTrueAndImmediate()
        {
            var valueAt0 = new IntCode(new int[] { 1105, 1, 2, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(2);
        }
    }
}
