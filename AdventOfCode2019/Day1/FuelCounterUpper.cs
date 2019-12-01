namespace AdventOfCode2019.Day1
{
    using System.Linq;

    public class FuelCounterUpper
    {
        private readonly IFuelCalculator _fuelCalculator;

        public FuelCounterUpper(IFuelCalculator fuelCalculator)
        {
            _fuelCalculator = fuelCalculator;
        }

        public int Calculate(int[] mass)
        {
            return mass.Select(m => _fuelCalculator.Calculate(m)).Sum();
        }
    }
}