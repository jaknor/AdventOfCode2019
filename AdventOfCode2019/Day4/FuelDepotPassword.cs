namespace AdventOfCode2019.Day4
{
    public class FuelDepotPassword
    {
        public FuelDepotPassword(int password)
        {
            Valid = password.ToString().Length == 6;
        }

        public bool Valid { get; }
    }
}