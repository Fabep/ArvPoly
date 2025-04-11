using ArvPoly.Core.SystemErrors;

namespace ArvPoly.Core.Vehicles;

public abstract class Vehicle
{
    public static SystemError[] PossibleErrors { get; } = 
        [new BrakeFailureError(), new EngineFailureError(), new TransmissionError()];

    private string _brand = null!;
    private string _model = null!;
    private int _year;
    private double _weight;

    internal string Brand 
    {
        get { return _brand; }
        set 
        {
            (bool success, string? error) = Validation.ValidateStringLength(value, 2, 20);
            if (!success)
                throw new ArgumentException($"{nameof(Brand)}: {error}");
            _brand = value; 
        }
    }

    internal string Model
    {
        get { return _model; }
        set
        {
            (bool success, string? error) = Validation.ValidateStringLength(value, 2, 20);
            if (!success)
                throw new ArgumentException($"{nameof(Model)}: {error}");
            _model = value;
        }
    }

    internal int Year
    {
        get { return _year; }
        set
        {
            (bool success, string? error) = Validation.ValidateIntLimit(value, 1886, Validation.GetCurrentYear());
            if (!success)
                throw new ArgumentException($"{nameof(Year)}: {error}");
            _year = value;
        }
    }

    internal double Weight
    {
        get { return _weight; }
        set 
        {
            (bool success, string? error) = Validation.ValidateDoubleLimit(value, lowerLimit: 0);
            if (!success)
                throw new ArgumentException($"{nameof(Year)}: {error}");
            _weight = value;
        }
    }
    public abstract string StartEngine();

    public virtual string[] Stats()
    {
        return [$"Model: {Model}", $"Brand: {Brand}", $"Year: {Year}", $"Weight: {Weight}"];
    }
    
}
