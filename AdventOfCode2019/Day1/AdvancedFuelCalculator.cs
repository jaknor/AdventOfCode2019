namespace AdventOfCode2019.Day1
{
    public class AdvancedFuelCalculator : IFuelCalculator
    {
        public int Calculate(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}