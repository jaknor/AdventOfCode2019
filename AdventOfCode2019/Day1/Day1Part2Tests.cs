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

        [Fact]
        public void CanCalculateFuelForMassWhereRequiredFuelRequiresOneAdditionalFuelButAdditionalCalculationDoesNotRequireFuel()
        {
            var mass = 32;
            var fuelRequiredForMass = 8;
            var fuelRequiredForFuel = 0;
            var expectedRequiredFuel = fuelRequiredForMass + fuelRequiredForFuel;

            var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }

        [Fact]
        public void CanCalculateFuelForMassWhereRequiredFuelRequiresTwoAdditionalFuelCalculations()
        {
            var mass = 105;
            var fuelRequiredForMass = 33;
            var fuelRequiredForFuel1 = 9;
            var fuelRequiredForFuel2 = 1;
            var expectedRequiredFuel = fuelRequiredForMass + fuelRequiredForFuel1 + fuelRequiredForFuel2;

            var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }

        [Theory]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void CanCalculateFuelForLargerMass(int mass, int expectedRequiredFuel)
        {
           var requiredFuel = _fuelCalculator.Calculate(mass);

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }

        [Fact]
        public void FullInput()
        {
            var input = new CalendarLineInput("Day1\\Day1Input.txt");
            var expectedRequiredFuel = 5209504;

            var requiredFuel = new FuelCounterUpper(_fuelCalculator).Calculate(input.Read());

            requiredFuel.ShouldBe(expectedRequiredFuel);
        }
    }
}
