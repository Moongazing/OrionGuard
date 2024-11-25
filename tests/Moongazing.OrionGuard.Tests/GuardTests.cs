
using Moongazing.OrionGuard.Core;
using Moongazing.OrionGuard.Exceptions;
using Moongazing.OrionGuard.Extensions;
using Xunit;

namespace Moongazing.OrionGuard.Tests;

public class GuardTests
{
    [Fact]
    public void AgainstNull_ShouldThrowNullValueException_WhenValueIsNull()
    {
        // Arrange
        object testObject = null;

        // Act & Assert
        Assert.Throws<NullValueException>(() => Guard.AgainstNull(testObject, nameof(testObject)));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void AgainstNullOrEmpty_ShouldThrowEmptyStringException_WhenStringIsNullOrWhitespace(string testString)
    {
        // Act & Assert
        Assert.Throws<EmptyStringException>(() => Guard.AgainstNullOrEmpty(testString, nameof(testString)));
    }

    [Theory]
    [InlineData(5, 10, 20)]
    [InlineData(-1, 0, 10)]
    public void AgainstOutOfRange_ShouldThrowOutOfRangeException_WhenValueIsOutOfRange(int value, int min, int max)
    {
        // Act & Assert
        Assert.Throws<OutOfRangeException>(() => Guard.AgainstOutOfRange(value, min, max, nameof(value)));
    }

    [Fact]
    public void AgainstInvalidEmail_ShouldThrowInvalidEmailException_WhenEmailIsInvalid()
    {
        // Arrange
        string invalidEmail = "invalid-email";

        // Act & Assert
        Assert.Throws<InvalidEmailException>(() => invalidEmail.AgainstInvalidEmail(nameof(invalidEmail)));
    }

    //[Fact]
    //public void AgainstNegativeDecimal_ShouldThrowOutOfRangeException_WhenValueIsNegative()
    //{
    //    // Arrange
    //    decimal negativeValue = -1m;

    //    // Act & Assert
    //    Assert.Throws<OutOfRangeException>(() => Guard.AgainstNegativeDecimal(negativeValue, nameof(negativeValue)));
    //}

    [Theory]
    [InlineData(0.0, -1.0, 1.0)]
    [InlineData(-10.0, -15.0, -5.0)]
    public void AgainstOutOfRange_ForDouble_ShouldThrowOutOfRangeException_WhenValueIsOutOfRange(double value, double min, double max)
    {
        // Act & Assert
        Assert.Throws<OutOfRangeException>(() => Guard.AgainstOutOfRange(value, min, max, nameof(value)));
    }

    //[Fact]
    //public void AgainstInvalidEnum_ShouldThrowInvalidEnumValueException_WhenEnumIsInvalid()
    //{
    //    // Arrange
    //    TestEnum invalidEnum = (TestEnum)999;

    //    // Act & Assert
    //    Assert.Throws<InvalidEnumValueException>(() => Guard.AgainstInvalidEnum(invalidEnum, nameof(invalidEnum)));
    //}

    [Fact]
    public void AgainstRegexMismatch_ShouldThrowRegexMismatchException_WhenPatternDoesNotMatch()
    {
        // Arrange
        string testValue = "abc123";
        string pattern = @"^\d+$"; // Only digits allowed

        // Act & Assert
        Assert.Throws<RegexMismatchException>(() => testValue.AgainstRegexMismatch(pattern, nameof(testValue)));
    }

    [Theory]
    [InlineData("abc123", @"^[a-z]+$")] // Only lowercase letters allowed
    [InlineData("123456", @"^\D+$")]    // No digits allowed
    public void AgainstRegexMismatch_WithMultiplePatterns_ShouldThrowRegexMismatchException(string value, string pattern)
    {
        // Act & Assert
        Assert.Throws<RegexMismatchException>(() => value.AgainstRegexMismatch(pattern, nameof(value)));
    }

    //[Fact]
    //public void AgainstPastDate_ShouldThrowPastDateException_WhenDateIsInPast()
    //{
    //    // Arrange
    //    DateTime pastDate = DateTime.Now.AddDays(-1);

    //    // Act & Assert
    //    Assert.Throws<PastDateException>(() => Guard.AgainstPastDate(pastDate, nameof(pastDate)));
    //}

    //[Fact]
    //public void AgainstFutureDate_ShouldThrowFutureDateException_WhenDateIsInFuture()
    //{
    //    // Arrange
    //    DateTime futureDate = DateTime.Now.AddDays(1);

    //    // Act & Assert
    //    Assert.Throws<FutureDateException>(() => Guard.AgainstFutureDate(futureDate, nameof(futureDate)));
    //}
}

public enum TestEnum
{
    ValidValue1 = 1,
    ValidValue2 = 2
}