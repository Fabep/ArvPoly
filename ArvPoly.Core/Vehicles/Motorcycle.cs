namespace ArvPoly.Core.Vehicles;
public class Motorcycle : Vehicle, ICleanable
{
    public bool HasSideCar { get; set; }
    public string Clean()
    {
        return "The motorcycle is now squeaky clean!";
    }

    public override string StartEngine()
    {
        return "🏍️ Revving up the engine...";
    }

    public override string[] Stats()
    {
        return [.. base.Stats(), $"Sidecar: {HasSideCar}"];
    }
}
