namespace ArvPoly.Core.Vehicles;
public class Boat : Vehicle
{
    private int _maxKnots;
    public int MaxKnots 
    {
        get => _maxKnots;
        set
        {
            (bool success, string? error) = Validation.ValidateIntLimit(value, 1, 200);
            if (!success)
                throw new ArgumentException($"{nameof(MaxKnots)}: {error}");
            _maxKnots = value;
        }
    }
    public override string StartEngine()
    {
        return $"🚤 Splash splosh! The boat is starting to accelerate to it's max speed of {MaxKnots} knots";
    }

    public override string[] Stats()
    {
        return [.. base.Stats(), MaxKnots.ToString()];
    }
}
