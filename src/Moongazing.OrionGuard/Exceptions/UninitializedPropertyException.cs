namespace Moongazing.OrionGuard.Exceptions;

public class UninitializedPropertyException : Exception
{
    public UninitializedPropertyException(string parameterName, string propertyName)
        : base($"{parameterName} contains uninitialized property: {propertyName}.")
    {
    }
}