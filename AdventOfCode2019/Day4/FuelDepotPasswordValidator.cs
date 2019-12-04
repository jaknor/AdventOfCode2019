namespace AdventOfCode2019.Day4
{
    public class FuelDepotPasswordValidator
    {
        private readonly int _lowerBound;
        private readonly int _upperBound;

        public FuelDepotPasswordValidator(int lowerBound, int upperBound)
        {
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        public bool Valid(int password)
        {
            return password.ToString().Length == 6 && password >= _lowerBound && password <= _upperBound;
        }
    }
}