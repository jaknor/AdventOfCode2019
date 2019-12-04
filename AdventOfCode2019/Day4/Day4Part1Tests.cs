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
            var fuelDepotPassword = new FuelDepotPasswordValidator(123451, 123459);

            fuelDepotPassword.Valid(password).ShouldBe(shouldBeValid);
        }

        [Theory]
        [InlineData(111111,222222, 111110, false)]
        [InlineData(111111,222222, 111111, true)]
        [InlineData(111111,222222, 111112, true)]
        [InlineData(111111,222222, 222221, true)]
        [InlineData(111111,222222, 222222, true)]
        [InlineData(111111,222222, 222223, false)]
        public void OnlyPasswordWithinRangeValid(int lowerBound, int upperBound, int password, bool shouldBeValid)
        {
            var fuelDepotPasswordValidator = new FuelDepotPasswordValidator(lowerBound, upperBound);

            fuelDepotPasswordValidator.Valid(password).ShouldBe(shouldBeValid);
        }
    }
}
