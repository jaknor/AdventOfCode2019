namespace AdventOfCode2019.Day1
{
    using System.Linq;
    using Shouldly;
    using Xunit;

    public class Day1Part1Tests
    {
        private readonly FuelCalculator _fuelCalculator;

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

        [Fact]
        public void CalculateFuelRequiredForMultipleElfs()
        {
            var mass = new int[] { 12, 14, 1969, 100756 };
            var expectedFuelForEachMass = new int[] { 2, 2, 654, 33583 };

            var requiredFuel = new FuelCounterUpper(_fuelCalculator).Calculate(mass);

            requiredFuel.ShouldBe(expectedFuelForEachMass.Sum());
        }
    }
}
