namespace AdventOfCode2019.Day4
{
    using Shouldly;
    using Xunit;

    public class Day4Part1Tests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(12, false)]
        [InlineData(123, false)]
        [InlineData(1234, false)]
        [InlineData(12345, false)]
        [InlineData(123456, true)]
        [InlineData(1234567, false)]
        public void Only6DigitPasswordsAreValid(int password, bool shouldBeValid)
        {
            var fuelDepotPassword = new FuelDepotPassword(password);

            fuelDepotPassword.Valid.ShouldBe(shouldBeValid);
        }
    }
}
