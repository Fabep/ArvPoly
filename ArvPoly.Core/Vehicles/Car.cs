namespace ArvPoly.Core.Vehicles;

public class Car : Vehicle, ICleanable
{
    private int _passengerSeats;

    public int PassengerSeats
    {
        get => _passengerSeats;
        set
        {
            (bool success, string? error) = Validation.ValidateIntLimit(value, 0, 100);
            if (!success)
                throw new ArgumentException($"{nameof(PassengerSeats)}: {error}");

            _passengerSeats = value;
        }
    }

    private bool IsClownCar => _passengerSeats > 10;

    public string Clean()
    {
        return "Cleaning the car...";
    }

    public override string StartEngine()
    {
        return "🚗 Vroom vroom!";
    }

    public override string[] Stats()
    {
        string carType = IsClownCar ? $"Clown car with {PassengerSeats} passenger seats" : $"Passenger Seats: {PassengerSeats}";
        return [.. base.Stats(), carType];
    }
}
