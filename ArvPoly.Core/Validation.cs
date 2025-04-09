namespace ArvPoly.Core;

internal static class Validation
{
    internal static bool ValidateStringLength(string value, int lowerLimit, int upperLimit)
    {
        if (value is null) return false;
        return !(value.Length < lowerLimit || value.Length > upperLimit);
    }

    internal static bool ValidateIntLimit(int value, int lowerLimit, int upperLimit)
    {
        return !(value < lowerLimit || value > upperLimit);
    }

    internal static int GetCurrentYear() => DateTime.Now.Year;

}
