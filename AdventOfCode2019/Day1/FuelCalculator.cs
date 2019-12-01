namespace AdventOfCode2019.Day1
{
    public interface IFuelCalculator
    {
        int Calculate(int mass);
    }

    public class FuelCalculator : IFuelCalculator
    {
        public int Calculate(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}