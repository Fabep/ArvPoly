using ArvPoly.Core;
using ArvPoly.Core.Vehicles;
using lex.Helpers;

namespace MainApp;
internal class App
{

    private readonly VehicleHandler _vehicleHandler;

    private readonly Dictionary<int, string> menuOptions;
    private readonly Dictionary<int, string> vehicleOptions;
    private bool _isAlive;
    public App(VehicleHandler vehicleHandler)
    {
        _vehicleHandler = vehicleHandler;
        menuOptions = new()
        {
            { 1, "Add a vehicle" },
            { 2, "List vehicles"},
            { 0, "Exit"},
        };

        vehicleOptions = new()
        {
            { 1, "Car" },
            { 2, "Motorcycle" },
            { 3, "Truck" },
            { 4, "Boat" },
        };
    }
    internal void Run()
    {

        _isAlive = true;

        do
        {
            ConsoleMenuHelpers.DisplayMenu(menuOptions);

            int input = Utils.PromptForInt("Option", x => x >= 0 && x <= 2);

            Console.Clear();

            switch (input)
            {
                case 1:
                    AddVehicle();
                    break;
                case 2:
                    DisplayVehicles();
                    break;
                case 3:
                    _isAlive = false;
                    break;
            }


        }   
        while (_isAlive);
    }


    private void AddVehicle()
    {
        int currentYear = Validation.GetCurrentYear();
        VehicleType vehicleType = GetVehicleType();

        string model = Utils.PromptForString("Model", x => x.Length > 2 && x.Length < 20, "Model must be between 2 and 20 characters");
        string brand = Utils.PromptForString("Brand", x => x.Length > 2 && x.Length < 20, "Brand must be between 2 and 20 characters");
        int year = Utils.PromptForInt("Year", x => x > 1886 && x < Validation.GetCurrentYear(), $"Year has to be between 1886 and {currentYear}");
        double weight = Utils.PromptForDouble("Weight", x => x > 0, "Weight has to be greater than 0");

        switch (vehicleType)
        {
            case VehicleType.Car:
                _vehicleHandler.Create<Car>(model, brand, year, weight);

                break;
            case VehicleType.Motorcycle:
                _vehicleHandler.Create<Motorcycle>(model, brand, year, weight);

                break;
            case VehicleType.Truck:
                _vehicleHandler.Create<Truck>(model, brand, year, weight);

                break;
            case VehicleType.Boat:
                _vehicleHandler.Create<Boat>(model, brand, year, weight);

                break;
        }

    }

    private void DisplayVehicles()
    {
        foreach(var vehicle in _vehicleHandler.GetAllVehicles())
        {
            Console.WriteLine(string.Join(", ", vehicle.Stats()));
            Console.WriteLine(vehicle.StartEngine());
        }
    }

    private VehicleType GetVehicleType()
    {
        ConsoleMenuHelpers.DisplayMenu(vehicleOptions);
        return (VehicleType)Utils.PromptForInt("VehicleType: ", x => x >= 1 && x <= 4);
    }


}
