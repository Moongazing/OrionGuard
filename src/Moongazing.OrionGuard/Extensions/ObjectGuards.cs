namespace Moongazing.OrionGuard.Extensions;

public static class ObjectGuards
{
    public static void AgainstNull(this object obj, string parameterName)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(parameterName, $"{parameterName} cannot be null.");
        }
    }

    public static void AgainstUninitializedProperties<T>(this T obj, string parameterName)
    {
        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            if (property.GetValue(obj) == null)
            {
                throw new ArgumentException($"{parameterName} contains uninitialized property: {property.Name}.", parameterName);
            }
        }
    }
}
