namespace AdventOfCode2019.Day4
{
    public class FuelDepotPasswordLengthRule : IFuelDepotPasswordValidationRule
    {
        public bool Validate(int password)
        {
            return password.ToString().Length == 6;
        }
    }
}