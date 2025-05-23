namespace FeshShop.Common.Guard;

using System.Runtime.CompilerServices;

public static class Ensure
{
    public static void NotNull(
        object value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (value is null) 
            throw new ArgumentNullException(paramName);
    }

    public static void NotNullOrWhiteSpace(
        string value,
        string? message = null,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message ?? "The value can not be null", paramName);
    }
}
