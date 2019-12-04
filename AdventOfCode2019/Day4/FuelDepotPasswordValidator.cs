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
            var doubleDigitDetected = false;
            var passwordAsString = password.ToString();
            for (int i = 0; i < 6 - 1; i++)
            {
                doubleDigitDetected = passwordAsString[i] == passwordAsString[i + 1];
                if (doubleDigitDetected)
                {
                    break;
                }
            }

            return password.ToString().Length == 6 && password >= _lowerBound && password <= _upperBound && doubleDigitDetected;
        }
    }
}