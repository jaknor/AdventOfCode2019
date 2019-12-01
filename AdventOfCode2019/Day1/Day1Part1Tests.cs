namespace AdventOfCode2019.Day1
{
    using Shouldly;
    using Xunit;

    public class Day1Part1Tests
    {
        private FuelCalculator _fuelCalculator;

        public Day1Part1Tests()
        {
            _fuelCalculator = new FuelCalculator();
        }


        [Fact]
        public void CanCalculateFuelRequiredForMassDivisableByThree()
        {
            var mass = 12;
            var expectedRequiredFuel = 2;

            var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }

        [Fact]
        public void CanCalculateFuelRequiredForMassNotDivisableByThree()
        {
            var mass = 14;
            var expectedRequiredFuel = 2;

            var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }

        [Theory]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void CanCalculateFuelRequiredForLargerMass(int mass, int expectedRequiredFuel)
        {
            var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }
    }
}
