namespace Moongazing.OrionGuard.Extensions;

public static class EnvironmentGuards
{
    public static void AgainstMissingEnvironmentVariable(this string variableName)
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(variableName)))
        {
            throw new ArgumentException($"{variableName} is not set in the environment variables.");
        }
    }
}
