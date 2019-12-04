namespace AdventOfCode2019.Day4
{
    public class FuelDepotPasswordRangeRule : IFuelDepotPasswordValidationRule
    {
        private readonly int _lowerBound;
        private readonly int _upperBound;

        public FuelDepotPasswordRangeRule(int lowerBound, int upperBound)
        {
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        public bool Validate(int password)
        {
            return password >= _lowerBound && password <= _upperBound;
        }
    }
}