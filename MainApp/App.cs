using ArvPoly.Core;
using ArvPoly.Core.SystemErrors;
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
            { 3, "Display Possible Errors"},
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
            Console.Clear();
            ConsoleMenuHelpers.DisplayMenu(menuOptions);

            int input = Utils.PromptForInt("Option", x => x >= 0 && x <= 3);

            Console.Clear();

            switch (input)
            {
                case 1:
                    AddVehicle();
                    break;
                case 2:
                    DisplayVehicles();
                    Console.WriteLine(ConsoleMenuHelpers.PRESS_ANY_TO_RETURN);
                    Console.ReadKey();
                    break;
                case 3:
                    DisplayPossibleErrors();
                    Console.WriteLine(ConsoleMenuHelpers.PRESS_ANY_TO_RETURN);
                    Console.ReadKey();
                    break;
                case 0:
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

        Console.WriteLine();

        string model = Utils.PromptForString("Model", x => x.Length > 2 && x.Length < 20, "Model must be between 2 and 20 characters");
        string brand = Utils.PromptForString("Brand", x => x.Length > 2 && x.Length < 20, "Brand must be between 2 and 20 characters");
        int year = Utils.PromptForInt("Year", x => x > 1886 && x < Validation.GetCurrentYear(), $"Year has to be between 1886 and {currentYear}");
        double weight = Utils.PromptForDouble("Weight", x => x > 0, "Weight has to be greater than 0");

        switch (vehicleType)
        {
            case VehicleType.Car:
                var c = _vehicleHandler.Create<Car>(model, brand, year, weight);
                c.PassengerSeats = Utils.PromptForInt("Passenger Seats", x => x >= 0 && x <= 100, "There's too many or too few passenger seats");
                break;
            case VehicleType.Motorcycle:
                var m = _vehicleHandler.Create<Motorcycle>(model, brand, year, weight);
                m.HasSideCar = Utils.PromptForString("Side car (y/n)", x => 
                    x.Equals("y", StringComparison.CurrentCultureIgnoreCase) || 
                    x.Equals("n", StringComparison.CurrentCultureIgnoreCase),
                    "Prompt only accepts the char y or n") == "y";
                break;
            case VehicleType.Truck:
                var t = _vehicleHandler.Create<Truck>(model, brand, year, weight);
                for (int i = 0; i < Random.Shared.Next(0, 3); i++)
                    t.AttachTrailer();
                break;
            case VehicleType.Boat:
                var b = _vehicleHandler.Create<Boat>(model, brand, year, weight);
                b.MaxKnots = Utils.PromptForInt("Max speed in knots", x => x >= 1 && x <= 200, "The max speed is invalid");
                break;
            default:
                Console.WriteLine("Something went wrong when adding your vehicle! Returning to main menu...");
                break;
        }
    }

    private void DisplayVehicles()
    {
        foreach(var vehicle in _vehicleHandler.GetAllVehicles())
        {
            Console.WriteLine(string.Join(", ", vehicle.Stats()));
            Console.WriteLine(vehicle.StartEngine());

            if (vehicle is ICleanable cleanVehicle)
                Console.WriteLine(cleanVehicle.Clean());
            Console.WriteLine();
        }
    }

    private void DisplayPossibleErrors()
    {
        foreach(SystemError error in Vehicle.PossibleErrors) 
            Console.WriteLine(error.ErrorMessage());
    }

    private VehicleType GetVehicleType()
    {
        ConsoleMenuHelpers.DisplayMenu(vehicleOptions);
        return (VehicleType)Utils.PromptForInt("VehicleType: ", x => x >= 1 && x <= 4);
    }


}
