namespace AdventOfCode2019.Day4
{
    public class FuelDepotPasswordDoubleDigitButNotPartOfLargerGroupRule : IFuelDepotPasswordValidationRule
    {
        public bool Validate(int password)
        {
            var passwordAsString = password.ToString();

            for (int i = 0; i < passwordAsString.Length - 1; i++)
            {
                var counter = 0;
                while (i < passwordAsString.Length - 1 && passwordAsString[i] == passwordAsString[i+1])
                {
                    i++;
                    counter++;
                }

                if (counter == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}