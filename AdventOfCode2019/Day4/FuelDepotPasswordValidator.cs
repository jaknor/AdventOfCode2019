namespace AdventOfCode2019.Day4
{
    using System.Collections.Generic;
    using System.Linq;

    public class FuelDepotPasswordValidator
    {
        private readonly List<IFuelDepotPasswordValidationRule> _rules;
        private readonly int _lowerBound;
        private readonly int _upperBound;

        public FuelDepotPasswordValidator(int lowerBound, int upperBound)
        {
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        public FuelDepotPasswordValidator(List<IFuelDepotPasswordValidationRule> rules)
        {
            _rules = rules;
        }

        public bool Valid(int password)
        {
            return _rules.Any() && _rules.All(r => r.Validate(password));
            
            
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