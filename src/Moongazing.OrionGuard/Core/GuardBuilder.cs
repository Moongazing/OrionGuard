using Moongazing.OrionGuard.Exceptions;
using System.Text.RegularExpressions;

namespace Moongazing.OrionGuard.Core;

public class GuardBuilder<T> : IFluentGuardStep<T>
{
    public T Value { get; }
    private readonly string _parameterName;

    public GuardBuilder(T value, string parameterName)
    {
        Value = value;
        _parameterName = parameterName;
    }

    public IFluentGuardStep<T> NotNull()
    {
        if (Value is null)
            throw new NullValueException(_parameterName);
        return this;
    }

    public IFluentGuardStep<T> NotEmpty()
    {
        if (Value is string str && string.IsNullOrWhiteSpace(str))
            throw new EmptyStringException(_parameterName);
        return this;
    }

    public IFluentGuardStep<T> Length(int min, int max)
    {
        if (Value is string str && (str.Length < min || str.Length > max))
            throw new OutOfRangeException(_parameterName, min, max);
        return this;
    }

    public IFluentGuardStep<T> Matches(string pattern)
    {
        if (Value is string str && !Regex.IsMatch(str, pattern))
            throw new RegexMismatchException(_parameterName, pattern);
        return this;
    }
}