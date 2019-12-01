namespace AdventOfCode2019.Day1
{
    public class AdvancedFuelCalculator : IFuelCalculator
    {
        public int Calculate(int mass)
        {
            var fuelForMass = (mass / 3) - 2;
            var fuelForFuel = (fuelForMass / 3) - 2;

            if (fuelForFuel < 0)
            {
                fuelForFuel = 0;
            }

            return fuelForMass + fuelForFuel;
        }
    }
}