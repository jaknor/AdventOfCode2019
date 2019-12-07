namespace AdventOfCode2019.Day7
{
    using Moq;
    using Shouldly;
    using Xunit;

    public class Day7Part1Tests
    {
        [Fact]
        public void CanCalculateThrustForFirstExample()
        {
            var phase1 = 4;
            var phase2 = 3;
            var phase3 = 2;
            var phase4 = 1;
            var phase5 = 0;

            var values = new[] {3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0};

            var thrusterSignal = 0;
            thrusterSignal = RunAmplifier(phase1, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase2, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase3, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase4, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase5, thrusterSignal, (int[])values.Clone());

            thrusterSignal.ShouldBe(43210);
        }

        [Fact]
        public void CanCalculateThrustForSecondExample()
        {
            var phase1 = 0;
            var phase2 = 1;
            var phase3 = 2;
            var phase4 = 3;
            var phase5 = 4;

            var values = new[] { 3,23,3,24,1002,24,10,24,1002,23,-1,23, 101,5,23,23,1,24,23,23,4,23,99,0,0 };

            var thrusterSignal = 0;
            thrusterSignal = RunAmplifier(phase1, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase2, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase3, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase4, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase5, thrusterSignal, (int[])values.Clone());

            thrusterSignal.ShouldBe(54321);
        }

        [Fact]
        public void CanCalculateThrustForThirdExample()
        {
            var phase1 = 1;
            var phase2 = 0;
            var phase3 = 4;
            var phase4 = 3;
            var phase5 = 2;

            var values = new[] { 3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0 };

            var thrusterSignal = 0;
            thrusterSignal = RunAmplifier(phase1, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase2, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase3, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase4, thrusterSignal, (int[])values.Clone());
            thrusterSignal = RunAmplifier(phase5, thrusterSignal, (int[])values.Clone());

            thrusterSignal.ShouldBe(65210);
        }

        [Fact]
        public void FullInputPart1()
        {
            const int MaxPhase = 4;

            var input = new CalendarCommaInput("Day7\\Day7Input.txt");
            var values = input.Read();
            var maxThrusterSignal = 0;
            
            for (int phase1 = 0; phase1 <= MaxPhase; phase1++)
            {
                for (int phase2 = 0; phase2 <= MaxPhase; phase2++)
                {
                    while (phase2 == phase1)
                    {
                        phase2++;
                    }
                    for (int phase3 = 0; phase3 <= MaxPhase; phase3++)
                    {
                        while (phase3 == phase1 || phase3 == phase2)
                        {
                            phase3++;
                        }
                        for (int phase4 = 0; phase4 <= MaxPhase; phase4++)
                        {
                            while (phase4 == phase1 || phase4 == phase2 || phase4 == phase3)
                            {
                                phase4++;
                            }
                            for (int phase5 = 0; phase5 <= MaxPhase; phase5++)
                            {
                                while (phase5 == phase1 || phase5 == phase2 || phase5 == phase3 || phase5 == phase4)
                                {
                                    phase5++;
                                }
                                var thrusterSignal = 0;
                                thrusterSignal = RunAmplifier(phase1, thrusterSignal, (int[])values.Clone());
                                thrusterSignal = RunAmplifier(phase2, thrusterSignal, (int[])values.Clone());
                                thrusterSignal = RunAmplifier(phase3, thrusterSignal, (int[])values.Clone());
                                thrusterSignal = RunAmplifier(phase4, thrusterSignal, (int[])values.Clone());
                                thrusterSignal = RunAmplifier(phase5, thrusterSignal, (int[])values.Clone());
                                if (thrusterSignal > maxThrusterSignal && phase1 <= MaxPhase && phase2 <= MaxPhase && phase3 <= MaxPhase && phase4 <= MaxPhase && phase5 <= MaxPhase)
                                {
                                    maxThrusterSignal = thrusterSignal;
                                }
                            }
                        }
                    }
                }
            }

            maxThrusterSignal.ShouldBe(101490);
        }

        private int RunAmplifier(int phase, int inputValue, int[] instructions)
        {
            var input = new Mock<IInput>();
            var output = new Mock<IOutput>();

            input.SetupSequence(i => i.Get()).Returns(phase).Returns(inputValue);

            var amplifier = new IntCode(instructions, input.Object, output.Object);

            if(amplifier.Finished)
                return (int)output.Invocations[0].Arguments[0];
            return -1;
        }
    }
}
