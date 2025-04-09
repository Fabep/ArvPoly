namespace ArvPoly.Core.Vehicles;

public class Car : Vehicle, ICleanable
{
    public string Clean()
    {
        return "Cleaning the car...";
    }

    public override string StartEngine()
    {
        return "🚗 Vroom vroom!";
    }
}
