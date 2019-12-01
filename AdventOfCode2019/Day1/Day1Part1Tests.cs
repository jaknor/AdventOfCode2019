namespace AdventOfCode2019.Day1
{
    using Shouldly;
    using Xunit;

    public class Day1Part1Tests
    {
        [Fact]
        public void CanCalculateFuelRequiredForMassDivisableByThree()
        {
            var mass = 12;
            var expectedRequiredFuel = 2;

            var requiredFuel = new FuelCalculator().Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }
    }
}
