namespace AdventOfCode2019.Day4
{
    using System.Collections.Generic;
    using System.Linq;

    public class FuelDepotPasswordValidator
    {
        private readonly List<IFuelDepotPasswordValidationRule> _rules;
        public FuelDepotPasswordValidator(List<IFuelDepotPasswordValidationRule> rules)
        {
            _rules = rules;
        }

        public bool Valid(int password)
        {
            return _rules.Any() && _rules.All(r => r.Validate(password));
        }

        public static FuelDepotPasswordValidator Create(int lowerBound, int upperBound)
        {
            return new FuelDepotPasswordValidator(new List<IFuelDepotPasswordValidationRule>
            {
                new FuelDepotPasswordLengthRule(),
                new FuelDepotPasswordRangeRule(lowerBound, upperBound),
                new FuelDepotPasswordDoubleDigitRule(),
                new FuelDepotPasswordNeverDecreaseRule()
            });
        }
    }
}