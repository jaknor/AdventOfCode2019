namespace AdventOfCode2019.Day9
{
    using System.Text;
    using Moq;
    using Shouldly;
    using Xunit;

    public class Day9PreviousIntCodeTests
    {
        private Mock<IInput> _input;
        private Mock<IOutput> _output;

        public Day9PreviousIntCodeTests()
        {
            _input = new Mock<IInput>();
            _output = new Mock<IOutput>();
        }

        [Fact]
        public void IntcodeWithOnlyOpCode99()
        {
            var valueAt0 = new IntCode(new long[]{99}, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(99);
        }

        [Fact]
        public void IntcodeWithAdditionOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new long[] { 01, 0, 0, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(2);
        }

        [Fact]
        public void IntcodeWithInsufficientNumbersForFinalOpCode()
        {
            var valueAt0 = new IntCode(new long[] { 01, 5, 0, 0, 99, 5 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(6);
        }

        [Fact]
        public void IntcodeWithMultiplicationOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new long[] { 02, 1, 1, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(1);
        }

        [Fact]
        public void IntcodeWithMultipleDifferentOperations()
        {
            var valueAt0 = new IntCode(new long[] { 01, 1, 1, 4, 99, 5, 6, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(30);
        }

        [Fact]
        public void IntcodeWithInputOpCodeStopAfterOneIteration()
        {
            var input = 42;
            _input.Setup(x => x.Get()).Returns(input);

            var valueAt0 = new IntCode(new long[] { 03, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(input);
        }

        [Fact]
        public void IntcodeWithInputOpCodeFollowedByAddStopAfterTwoIteration()
        {
            var input = 42;
            _input.Setup(x => x.Get()).Returns(input);

            var valueAt0 = new IntCode(new long[] { 03, 0, 1, 0, 6, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(input + 99);
        }

        [Fact]
        public void IntcodeWithOutputOpCodeStopAfterOneIteration()
        {
            var valueAt0 = new IntCode(new long[] { 04, 2, 99 }, _input.Object, _output.Object)[0];

            _output.Verify(_ => _.Push(99));
        }

        [Fact]
        public void IntcodeWithOutputOpCodeDoesNotStop()
        {
            var valueAt0 = new IntCode(new long[] { 04, 4, 1, 2, 6, 0, 99 }, _input.Object, _output.Object)[0];

            _output.Verify(_ => _.Push(6));
            valueAt0.ShouldBe(100);
        }

        [Fact]
        public void ParametersToAddForAddInstructionAreImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1101, 5, 5, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(10);
        }

        [Fact]
        public void ParametersToMultiplyForMultiplyInstructionAreImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1102, 5, 5, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(25);
        }

        [Fact]
        public void OutputParameterImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 104, 25, 99 }, _input.Object, _output.Object)[0];

            _output.Verify(_ => _.Push(25));
        }

        [Fact]
        public void NegativeValuesAsImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1101, 100, -1, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(99);
        }

        [Fact]
        public void ProgramConsideredFinishedIfHaltAfterOutput()
        {
            var intCode = new IntCode(new long[] { 04, 0, 99 }, _input.Object, _output.Object);

            intCode.Finished.ShouldBeTrue();
        }

        [Fact]
        public void ProgramNotConsideredFinishedIfHaltAfterAddition()
        {
            var intCode = new IntCode(new long[] { 01, 0, 0, 0, 99 }, _input.Object, _output.Object);

            intCode.Finished.ShouldBeFalse();
        }

        [Fact]
        public void ProgramNotConsideredFinishedIfHaltAfterMultiply()
        {
            var intCode = new IntCode(new long[] { 02, 0, 0, 0, 99 }, _input.Object, _output.Object);

            intCode.Finished.ShouldBeFalse();
        }

        [Fact]
        public void OpCodeJumpIfTrueWithFalseAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 05, 2, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(5);
        }

        [Fact]
        public void OpCodeJumpIfTrueWithTrueAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 05, 3, 4, 10, 5, 1101, 4, 4, 0, 99}, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(8);
        }

        [Fact]
        public void OpCodeJumpIfTrueWithFalseAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 105, 0, 1, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(105);
        }

        [Fact]
        public void OpCodeJumpIfTrueWithTrueAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1105, 1, 3, 1101, 4, 3, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(7);
        }

        [Fact]
        public void OpCodeJumpIfFalseWithFalseAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 06, 2, 1, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(6);
        }

        [Fact]
        public void OpCodeJumpIfFalseWithTrueAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 06, 3, 9, 0, 1101, 53, 1, 0, 99, 4}, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(54);
        }

        [Fact]
        public void OpCodeJumpIfFalseWithFalseAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 106, 1, 1, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(106);
        }

        [Fact]
        public void OpCodeJumpIfFalseWithTrueAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1106, 0, 4, 99, 1101, 3, 8, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(11);
        }

        [Fact]
        public void OpCodeLessThanWithFalseAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 07, 6, 5, 0, 99, 1, 2 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(0);
        }

        [Fact]
        public void OpCodeLessThanWithTrueAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 07, 5, 6, 0, 99, 1, 2 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(1);
        }

        [Fact]
        public void OpCodeLessThanWithFalseAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1107, 2, 1, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(0);
        }

        [Fact]
        public void OpCodeLessThanWithTrueAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1107, 1, 2, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(1);
        }

        [Fact]
        public void OpCodeEqualsWithFalseAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 08, 6, 5, 0, 99, 1, 2 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(0);
        }

        [Fact]
        public void OpCodeEqualsWithTrueAndPositional()
        {
            var valueAt0 = new IntCode(new long[] { 08, 5, 6, 0, 99, 1, 1 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(1);
        }

        [Fact]
        public void OpCodeEqualsWithFalseAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1108, 2, 1, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(0);
        }

        [Fact]
        public void OpCodeEqualsWithTrueAndImmediate()
        {
            var valueAt0 = new IntCode(new long[] { 1108, 2, 2, 0, 99 }, _input.Object, _output.Object)[0];

            valueAt0.ShouldBe(1);
        }

        [Fact]
        public void EightIsEqualToEightPositional()
        {
            _input.Setup(_ => _.Get()).Returns(8);

            new IntCode(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(1));
        }

        [Fact]
        public void SevenIsNotEqualToEightPositional()
        {
            _input.Setup(_ => _.Get()).Returns(7);

            new IntCode(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(0));
        }

        [Fact]
        public void EightIsNotLessThanEightImmediate()
        {
            _input.Setup(_ => _.Get()).Returns(8);

            new IntCode(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(0));
        }

        [Fact]
        public void SevenIsLessThanEightImmediate()
        {
            _input.Setup(_ => _.Get()).Returns(7);

            new IntCode(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(1));
        }

        [Fact]
        public void ZeroIsZeroPosition()
        {
            _input.Setup(_ => _.Get()).Returns(0);

            new IntCode(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(0));
        }

        [Fact]
        public void TenIsNotZeroPosition()
        {
            _input.Setup(_ => _.Get()).Returns(10);

            new IntCode(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(1));
        }

        [Fact]
        public void TenIsNotZeroImmediate()
        {
            _input.Setup(_ => _.Get()).Returns(10);

            new IntCode(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(1));
        }

        [Fact]
        public void LargeExampleBelowEight()
        {
            _input.Setup(_ => _.Get()).Returns(7);

            new IntCode(new long[] { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(999));
        }

        [Fact]
        public void LargeExampleIsEight()
        {
            _input.Setup(_ => _.Get()).Returns(8);

            new IntCode(new long[] { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(1000));
        }

        [Fact]
        public void LargeExampleAboveEight()
        {
            _input.Setup(_ => _.Get()).Returns(9);

            new IntCode(new long[] { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,
                1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,
                999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 }, _input.Object, _output.Object);

            _output.Verify(o => o.Push(It.IsAny<long>()), Times.Once);
            _output.Verify(o => o.Push(1001));
        }
    }
}
