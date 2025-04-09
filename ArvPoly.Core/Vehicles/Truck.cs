namespace ArvPoly.Core.Vehicles;

public class Truck : Vehicle
{
    private int _trailers;
    internal int Trailers 
    {
        get => _trailers;
        set
        {
            if (!Validation.ValidateIntLimit(value, -1, 3))
                throw new ArgumentOutOfRangeException(nameof(Trailers));
            _trailers = value;
        }
    }
    public override string StartEngine()
    {
        return "🚚 Engine starting slowly...";
    }

    public override string[] Stats()
    {
        return [.. base.Stats(), Trailers.ToString()];
    }

    public string AttachTrailer()
    {
        try
        {
            Trailers++;
            return "Succesfully attached a trailer!";
        }
        catch
        {
            return "Max number of trailers are already attached!";
        }
    }
    public string RemoveTrailer()
    {
        try
        {
            Trailers--;
            return "Succesfully removed a trailer!";
        }
        catch
        {
            return "No more trailers to remove!";
        }
    }
}
