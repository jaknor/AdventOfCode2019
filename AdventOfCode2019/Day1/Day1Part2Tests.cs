namespace AdventOfCode2019.Day1
{
    using Shouldly;
    using Xunit;

    public class Day1Part2Tests
    {
        private readonly AdvancedFuelCalculator _fuelCalculator;

        public Day1Part2Tests()
        {
            _fuelCalculator = new AdvancedFuelCalculator();
        }

        [Fact]
        public void CanCalculateFuelForMassWhereRequiredFuelDoesNotRequireAdditionalFuel()
        {
            var mass = 12;
            var expectedRequiredFuel = 2;

            var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }

        [Fact]
        public void CanCalculateFuelForMassWhereRequiredFuelRequiresOneAdditionalFuelCalculation()
        {
            var mass = 33;
            var fuelRequiredForMass = 9;
            var fuelRequiredForFuel = 1;
            var expectedRequiredFuel = fuelRequiredForMass + fuelRequiredForFuel;

            var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }
    }
}
