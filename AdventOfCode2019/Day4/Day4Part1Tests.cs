namespace AdventOfCode2019.Day4
{
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class Day4Part1Tests
    {
        [Fact]
        public void FuelDepotPasswordIsInvalidIfNoRules()
        {
            const int ValidPassword = 123345;

            var fuelDepotPasswordValidator = new FuelDepotPasswordValidator(new List<IFuelDepotPasswordValidationRule>());

            fuelDepotPasswordValidator.Valid(ValidPassword).ShouldBe(false);
        }

        [Fact]
        public void FuelDepotPasswordIsInvalidIfAnyRuleFail()
        {
            const int InvalidPassword = 123456;

            var fuelDepotPasswordValidator = new FuelDepotPasswordValidator(new List<IFuelDepotPasswordValidationRule>()
            {
                new ValidTestRule(),
                new InvalidTestRule()
            });

            fuelDepotPasswordValidator.Valid(InvalidPassword).ShouldBe(false);
        }

        [Fact]
        public void FuelDepotPasswordIsValidIfAllRulesAreValid()
        {
            const int ValidPassword = 123345;

            var fuelDepotPasswordValidator = new FuelDepotPasswordValidator(new List<IFuelDepotPasswordValidationRule>()
            {
                new ValidTestRule(),
                new ValidTestRule()
            });

            
            fuelDepotPasswordValidator.Valid(ValidPassword).ShouldBe(true);
        }
        
        [Theory]
        [InlineData(1, false)]
        [InlineData(12, false)]
        [InlineData(123, false)]
        [InlineData(1234, false)]
        [InlineData(12345, false)]
        [InlineData(123446, true)]
        [InlineData(1234567, false)]
        public void Only6DigitPasswordsAreValid(int password, bool shouldBeValid)
        {
            var fuelDepotPassword = new FuelDepotPasswordLengthRule();

            fuelDepotPassword.Validate(password).ShouldBe(shouldBeValid);
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
            var fuelDepotPasswordValidator = new FuelDepotPasswordRangeRule(lowerBound, upperBound);

            fuelDepotPasswordValidator.Validate(password).ShouldBe(shouldBeValid);
        }

        [Theory]
        [InlineData(123456, false)]
        [InlineData(113456, true)]
        [InlineData(122456, true)]
        [InlineData(123356, true)]
        [InlineData(123446, true)]
        [InlineData(123455, true)]
        public void DoubleDigitRequired(int password, bool shouldBeValid)
        {
            var fuelDepotPassword = new FuelDepotPasswordDoubleDigitRule();

            fuelDepotPassword.Validate(password).ShouldBe(shouldBeValid);
        }

        [Theory]
        [InlineData(120456, false)]
        [InlineData(121456, false)]
        [InlineData(122156, false)]
        [InlineData(122456, true)]
        [InlineData(123456, true)]
        public void NeverDecrease(int password, bool shouldBeValid)
        {
            var fuelDepotPassword = new FuelDepotPasswordNeverDecreaseRule();

            fuelDepotPassword.Validate(password).ShouldBe(shouldBeValid);
        }

        [Theory]
        [InlineData(111111, true)]
        [InlineData(223450, false)]
        [InlineData(123789, false)]
        public void AdventOfCodeTestData(int password, bool shouldBeValid)
        {
            var fuelDepotValidator = FuelDepotPasswordValidator.Create(100000, 999999);

            fuelDepotValidator.Valid(password).ShouldBe(shouldBeValid);
        }

        [Fact]
        public void FindValidPasswords()
        {
            int lowerBound = 240298, upperBound = 784956;

            var fuelDepotValidator = FuelDepotPasswordValidator.Create(lowerBound, upperBound);

            var validPasswords = 0;
            for (int i = lowerBound; i <= upperBound; i++)
            {
                validPasswords += fuelDepotValidator.Valid(i) ? 1 : 0;
            }

            validPasswords.ShouldBe(1150);
        }
    }

    public class InvalidTestRule : IFuelDepotPasswordValidationRule
    {
        public bool Validate(int password)
        {
            return false;
        }
    }

    public class ValidTestRule : IFuelDepotPasswordValidationRule
    {
        public bool Validate(int password)
        {
            return true;
        }
    }
}
