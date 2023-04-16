using EPAM.Classes.Vehicle_Parts;
using EPAM.Classes.Vehicles;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bus bus = new Bus(new Chassis(6, 315, 5000),
            new Engine(300, 6.7, "ESS", 222145),
            new Transmission("Manual", "Pro Shift", 8));

            bus.SetBusProperties(45, 72, 14000, BusType.Transit);

            Car car = new Car(new Chassis(4, 90, 1500),
                new Engine(200, 2.55, "MHEV", 66315),
                new Transmission("Manual", "Pro Shift", 6));

            car.SetCarTypes(CarTypes.Universal, true, 5);

            Scooter scooter = new Scooter(new Chassis(3, 10, 500),
                new Engine(80, 3.1, "ICE", 54315),
                new Transmission("Automatic", "Pro Shift"));

            scooter.SetScooterProperties(ScooterFuel.CNG, 86);

            Truck truck = new Truck(new Chassis(18, 682.2, 12000),
                new Engine(350, 12, "Ignition", 14441),
                new Transmission("Manual", "Green Rubber-Kennedy AG, LP", 12));

            truck.SetTruckProperties("Wheat", 5000);

            Console.WriteLine(bus);
            Console.WriteLine(car);
            Console.WriteLine(scooter);
            Console.WriteLine(truck);
        }
    }
}