namespace ArvPoly.Core;

internal static class Validation
{
    internal static (bool success, string? error) ValidateStringLength(string value, int lowerLimit, int upperLimit)
    {
        if (value is null) return (false, "Value can't be null.");
        return (!(value.Length < lowerLimit || value.Length > upperLimit), "Length of the value is outside of the application limits.");
    }

    internal static (bool success, string? error) ValidateIntLimit(int value, int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
    {
        return (!(value < lowerLimit || value > upperLimit), "Size of the value is outside of the application limits.");
    }

    internal static (bool success, string? error) ValidateDoubleLimit(double value, double lowerLimit = double.MinValue, double upperLimit = double.MaxValue)
    {
        return (!(value < lowerLimit || value > upperLimit), "Size of the value is outside of the application limits.");
    }

    internal static int GetCurrentYear() => DateTime.Now.Year;

}
