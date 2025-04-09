using ArvPoly.Core.Vehicles;

namespace ArvPoly.Core;

public class VehicleHandler
{
    private const string VEHICLE = "Vehicle";
    private List<Vehicle> Vehicles { get; set; } = [];
    public Vehicle Create<T>(string model, string brand, int year, double weight)
        where T : Vehicle
    {
        if (typeof(T).Name is VEHICLE)
            throw new ArgumentException("Generic entry T can not be of type Vehicle.");

        T vehicle = Activator.CreateInstance<T>();

        UpdateModel(vehicle, model);
        UpdateBrand(vehicle, brand);
        UpdateYear(vehicle, year);
        UpdateWeight(vehicle, weight);

        Vehicles.Add(vehicle);
        return vehicle;
    }

    public bool UpdateModel(Vehicle vehicle, string newModel)
    {
        try
        {
            vehicle.Model = newModel;
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool UpdateBrand(Vehicle vehicle, string newBrand)
    {
        try
        {
            vehicle.Brand= newBrand;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateYear(Vehicle vehicle, int newYear)
    {
        try
        {
            vehicle.Year = newYear;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateWeight(Vehicle vehicle, double newWeight)
    {
        try
        {
            vehicle.Weight = newWeight;
            return true;
        }
        catch
        {
            return false;
        }
    }
    public Vehicle[] GetAllCars()
    {
        return [.. Vehicles];
    }

    public static bool TryGetAsTVehicle<TVehicle>(Vehicle vehicle, out TVehicle tVehicle)
        where TVehicle : Vehicle
    {
        tVehicle = null!;
        if (typeof(TVehicle).Name is VEHICLE) return false;

#pragma warning disable CS8601 // Possible null reference assignment.
        tVehicle = vehicle as TVehicle;
#pragma warning restore CS8601 // Possible null reference assignment.

        if (tVehicle is null) return false;

        return true;
    } 
}
