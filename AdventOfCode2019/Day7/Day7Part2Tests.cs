namespace AdventOfCode2019.Day7
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Shouldly;
    using Xunit;

    public class Day7Part2Tests
    {
        [Fact]
        public void CanCalculateThrustForFirstExample()
        {
            var phase1 = 9;
            var phase2 = 8;
            var phase3 = 7;
            var phase4 = 6;
            var phase5 = 5;

            var values1 = new[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 };
            var values2 = new[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 };
            var values3 = new[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 };
            var values4 = new[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 };
            var values5 = new[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 };

            var thrusterSignal = 0;

            var input1 = new FakeInput();
            var input2 = new FakeInput();
            var input3 = new FakeInput();
            var input4 = new FakeInput();
            var input5 = new FakeInput();

            input1.Add(phase1, 0);
            input2.Add(phase2);
            input3.Add(phase3);
            input4.Add(phase4);
            input5.Add(phase5);

            var output1 = new FakeOutput(input2);
            var output2 = new FakeOutput(input3);
            var output3 = new FakeOutput(input4);
            var output4 = new FakeOutput(input5);
            var output5 = new FakeOutput(input1);

            Task.WaitAll(new[]
            {
                Task.Run(() => { new IntCode(values1, input1, output1); }),
                Task.Run(() => { new IntCode(values2, input2, output2); }),
                Task.Run(() => { new IntCode(values3, input3, output3); }),
                Task.Run(() => { new IntCode(values4, input4, output4); }),
                Task.Run(() => { new IntCode(values5, input5, output5); })
            });

            thrusterSignal = input1.Get();

            thrusterSignal.ShouldBe(139629729);
        }

        [Fact]
        public void CanCalculateThrustForSecondExample()
        {
            var phase1 = 9;
            var phase2 = 7;
            var phase3 = 8;
            var phase4 = 5;
            var phase5 = 6;

            var values1 = new[] { 3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54, -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4, 53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10 };
            var values2 = new[] { 3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54, -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4, 53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10 };
            var values3 = new[] { 3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54, -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4, 53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10 };
            var values4 = new[] { 3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54, -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4, 53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10 };
            var values5 = new[] { 3, 52, 1001, 52, -5, 52, 3, 53, 1, 52, 56, 54, 1007, 54, 5, 55, 1005, 55, 26, 1001, 54, -5, 54, 1105, 1, 12, 1, 53, 54, 53, 1008, 54, 0, 55, 1001, 55, 1, 55, 2, 53, 55, 53, 4, 53, 1001, 56, -1, 56, 1005, 56, 6, 99, 0, 0, 0, 0, 10 };

            var thrusterSignal = 0;

            var input1 = new FakeInput();
            var input2 = new FakeInput();
            var input3 = new FakeInput();
            var input4 = new FakeInput();
            var input5 = new FakeInput();

            input1.Add(phase1, 0);
            input2.Add(phase2);
            input3.Add(phase3);
            input4.Add(phase4);
            input5.Add(phase5);

            var output1 = new FakeOutput(input2);
            var output2 = new FakeOutput(input3);
            var output3 = new FakeOutput(input4);
            var output4 = new FakeOutput(input5);
            var output5 = new FakeOutput(input1);

            Task.WaitAll(new[]
            {
                Task.Run(() => { new IntCode(values1, input1, output1); }),
                Task.Run(() => { new IntCode(values2, input2, output2); }),
                Task.Run(() => { new IntCode(values3, input3, output3); }),
                Task.Run(() => { new IntCode(values4, input4, output4); }),
                Task.Run(() => { new IntCode(values5, input5, output5); })
            });

            thrusterSignal = input1.Get();

            thrusterSignal.ShouldBe(18216);
        }

        [Fact]
        public void FullInputPart2()
        {
            const int MinPhase = 5;
            const int MaxPhase = 9;

            var input = new CalendarCommaInput("Day7\\Day7Input.txt");
            var values1 = input.Read();
            var values2 = input.Read();
            var values3 = input.Read();
            var values4 = input.Read();
            var values5 = input.Read();
            var maxThrusterSignal = 0;

            for (int phase1 = MinPhase; phase1 <= MaxPhase; phase1++)
            {
                for (int phase2 = MinPhase; phase2 <= MaxPhase; phase2++)
                {
                    while (phase2 == phase1)
                    {
                        phase2++;
                    }
                    for (int phase3 = MinPhase; phase3 <= MaxPhase; phase3++)
                    {
                        while (phase3 == phase1 || phase3 == phase2)
                        {
                            phase3++;
                        }
                        for (int phase4 = MinPhase; phase4 <= MaxPhase; phase4++)
                        {
                            while (phase4 == phase1 || phase4 == phase2 || phase4 == phase3)
                            {
                                phase4++;
                            }
                            for (int phase5 = MinPhase; phase5 <= MaxPhase; phase5++)
                            {
                                while (phase5 == phase1 || phase5 == phase2 || phase5 == phase3 || phase5 == phase4)
                                {
                                    phase5++;
                                }

                                if (phase1 <= MaxPhase && phase2 <= MaxPhase && phase3 <= MaxPhase &&
                                    phase4 <= MaxPhase && phase5 <= MaxPhase)
                                {
                                    var input1 = new FakeInput();
                                    var input2 = new FakeInput();
                                    var input3 = new FakeInput();
                                    var input4 = new FakeInput();
                                    var input5 = new FakeInput();

                                    input1.Add(phase1, 0);
                                    input2.Add(phase2);
                                    input3.Add(phase3);
                                    input4.Add(phase4);
                                    input5.Add(phase5);

                                    var output1 = new FakeOutput(input2);
                                    var output2 = new FakeOutput(input3);
                                    var output3 = new FakeOutput(input4);
                                    var output4 = new FakeOutput(input5);
                                    var output5 = new FakeOutput(input1);

                                    Task.WaitAll(new[]
                                    {
                                        Task.Run(() => { new IntCode(values1, input1, output1); }),
                                        Task.Run(() => { new IntCode(values2, input2, output2); }),
                                        Task.Run(() => { new IntCode(values3, input3, output3); }),
                                        Task.Run(() => { new IntCode(values4, input4, output4); }),
                                        Task.Run(() => { new IntCode(values5, input5, output5); })
                                    });

                                    var thrusterSignal = input1.Get();

                                    if (thrusterSignal > maxThrusterSignal)
                                    {
                                        maxThrusterSignal = thrusterSignal;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            maxThrusterSignal.ShouldBe(101490);
        }
    }

    public class FakeInput : IInput
    {
        private Queue<int> _values;

        public FakeInput()
        {
            _values = new Queue<int>();
        }

        public int Get()
        {
            while (!_values.TryPeek(out int peekResult))
            {
                Thread.Sleep(1);
            }

            return _values.Dequeue();
        }

        public void Add(params int[] values)
        {
            foreach (var value in values)
            {
                _values.Enqueue(value);
            }
        }
    }

    public class FakeOutput : IOutput
    {
        private readonly FakeInput _input;

        public FakeOutput(FakeInput input)
        {
            _input = input;
        }

        public void Push(int value)
        {
            _input.Add(value);
        }
    }
}
