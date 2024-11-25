namespace Moongazing.OrionGuard.Utilities
{
    /// <summary>
    /// Provides commonly used regex patterns.
    /// </summary>
    public static class RegexPatterns
    {
        public const string Email = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public const string Url = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";
        public const string PhoneNumber = @"^\+?[1-9]\d{1,14}$";
    }
}
