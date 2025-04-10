using ArvPoly.Core;
using ArvPoly.Core.Vehicles;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

VehicleHandler vh = new();

Vehicle vehicle = vh.Create<Truck>("", "Volvo", 2010, 5000);


if (VehicleHandler.TryGetAsTVehicle(vehicle, out Truck truck))
{
    Console.WriteLine(truck.AttachTrailer());
    Console.WriteLine(truck.AttachTrailer());
    Console.WriteLine(truck.AttachTrailer());
    Console.WriteLine(truck.AttachTrailer());
    Console.WriteLine(truck.RemoveTrailer());
}

Console.WriteLine(string.Join(", ", vehicle.Stats()));

Console.WriteLine(vehicle.StartEngine());
