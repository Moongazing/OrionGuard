using Moongazing.OrionGuard.Core;

namespace Moongazing.OrionGuard.Demo.Profiles;

public static class CustomProfiles
{
    public static void SafeUsername(string value, string parameterName)
    {
        Guard.For(value, parameterName)
            .NotNull()
            .NotEmpty()
            .Length(3, 20)
            .Matches(@"^[a-zA-Z0-9_]+$");
    }
}
