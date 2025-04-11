using ArvPoly.Core;
using ArvPoly.Core.Vehicles;
using MainApp;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

VehicleHandler vh = new();

App app = new(vh);

app.Run();


