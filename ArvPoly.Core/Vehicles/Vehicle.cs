namespace ArvPoly.Core.Vehicles;

public abstract class Vehicle
{
    private string _brand = null!;
    private string _model = null!;
    private int _year;
    private double _weight;

    internal string Brand 
    {
        get { return _brand; }
        set 
        { 
            if (!Validation.ValidateStringLength(value, 2, 20))
                throw new ArgumentOutOfRangeException(nameof(Brand));
            _brand = value; 
        }
    }

    internal string Model
    {
        get { return _model; }
        set
        {
            if (!Validation.ValidateStringLength(value, 2, 20))
                throw new ArgumentOutOfRangeException(nameof(Model));
            _model = value;
        }
    }

    internal int Year
    {
        get { return _year; }
        set
        {
            if (!Validation.ValidateIntLimit(value, 1886, Validation.GetCurrentYear()))
                throw new ArgumentOutOfRangeException(nameof(Year));
            _year = value;
        }
    }

    internal double Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }
    public abstract string StartEngine();

    public virtual string[] Stats()
    {
        return [Model, Brand, Year.ToString(), Weight.ToString()];
    }
    
}
