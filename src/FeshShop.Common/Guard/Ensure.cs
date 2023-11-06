using System;
using System.Runtime.CompilerServices;

namespace FeshShop.Common.Guard;

public static class Ensure
{
    public static void NotNull(
        object value,
        [CallerArgumentExpression(nameof(value))] string paramName = null)
    {
        if (value == null) 
            throw new ArgumentNullException(paramName);
    }

    public static void NotNullOrWhiteSpace(
        string value,
        string message = null,
        [CallerArgumentExpression(nameof(value))] string paramName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message ?? "The value can not be null", paramName);
    }
}
