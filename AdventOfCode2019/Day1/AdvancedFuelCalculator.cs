namespace AdventOfCode2019.Day1
{
    public class AdvancedFuelCalculator : IFuelCalculator
    {
        public int Calculate(int mass)
        {
            var fuelRequired = (mass / 3) - 2;

            if (fuelRequired <= 0)
            {
                return 0;
            }

            return fuelRequired + Calculate(fuelRequired);
        }
    }
}