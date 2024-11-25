﻿namespace Moongazing.OrionGuard.Extensions;

public static class CollectionGuards
{
    public static void AgainstNullOrEmpty<T>(this IEnumerable<T> collection, string parameterName)
    {
        if (collection == null || !collection.Any())
        {
            throw new ArgumentException($"{parameterName} cannot be null or empty.", parameterName);
        }
    }

    public static void AgainstExceedingCount<T>(this IEnumerable<T> collection, int maxCount, string parameterName)
    {
        if (collection.Count() > maxCount)
        {
            throw new ArgumentException($"{parameterName} cannot contain more than {maxCount} items.", parameterName);
        }
    }

    public static void AgainstNullItems<T>(this IEnumerable<T> collection, string parameterName)
    {
        if (collection.Any(item => item == null))
        {
            throw new ArgumentException($"{parameterName} cannot contain null items.", parameterName);
        }
    }
}
