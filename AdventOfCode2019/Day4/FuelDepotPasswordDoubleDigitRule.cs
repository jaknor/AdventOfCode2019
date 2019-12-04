namespace AdventOfCode2019.Day4
{
    public class FuelDepotPasswordDoubleDigitRule : IFuelDepotPasswordValidationRule
    {
        public bool Validate(int password)
        {
            var passwordAsString = password.ToString();

            for (int i = 0; i < passwordAsString.Length-1; i++)
            {
                if (passwordAsString[i] == passwordAsString[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}