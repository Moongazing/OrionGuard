namespace Moongazing.OrionGuard.Extensions;

public static class BooleanGuards
{
    public static void AgainstFalse(this bool value, string parameterName)
    {
        if (!value)
        {
            throw new ArgumentException($"{parameterName} cannot be false.", parameterName);
        }
    }

    public static void AgainstTrue(this bool value, string parameterName)
    {
        if (value)
        {
            throw new ArgumentException($"{parameterName} cannot be true.", parameterName);
        }
    }
}
