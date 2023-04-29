using EPAM.Classes.Vehicle_Parts;
using EPAM.Classes.Vehicles;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Bus(new Chassis(6, 315, 5000), new Engine(300, 6.7, "ESS", 222145), new Transmission("Manual", "Pro Shift", 8), 45, 72, 14000, BusType.Transit),
                new Car(new Chassis(4, 90, 1500), new Engine(200, 2.55, "MHEV", 66315), new Transmission("Manual", "Pro Shift", 6), CarTypes.Universal, true, 5),
                new Scooter(new Chassis(3, 10, 500), new Engine(80, 1.49, "ICE", 54315), new Transmission("Automatic", "Pro Shift"), ScooterFuel.CNG, 86),
                new Truck(new Chassis(18, 682.2, 12000), new Engine(350, 12, "Ignition", 14441), new Transmission("Manual", "Green Rubber-Kennedy AG, LP", 12), "Wheat", 5000)
            };

            var test1 = vehicles.Where(v=> v.Engine.Volume >= 1.5);
            var test2 = vehicles.Where(v => v.GetType().Equals(typeof(Bus)));
            foreach (var vehicle in test2)
            {
                Console.WriteLine(vehicle);
                Console.WriteLine($"={vehicle.GetType()}=");
            }
            
        }
    }
}