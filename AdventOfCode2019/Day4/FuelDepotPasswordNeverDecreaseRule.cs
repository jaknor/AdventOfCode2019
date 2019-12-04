namespace AdventOfCode2019.Day4
{
    public class FuelDepotPasswordNeverDecreaseRule : IFuelDepotPasswordValidationRule
    {
        public bool Validate(int password)
        {
            var passwordAsString = password.ToString();

            for (int i = 0; i < passwordAsString.Length - 1; i++)
            {
                if (int.Parse(passwordAsString[i + 1].ToString()) < int.Parse(passwordAsString[i].ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}