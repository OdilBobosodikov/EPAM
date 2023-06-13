using EPAM.Classes.VehicleParts;
using EPAM.Classes.Vehicles;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bus bus = new Bus(new Chassis(6, 315, 5000),
            new Engine(300, 6.7, EngineTypes.ESS, 222145),
            new Transmission(TransmissionTypes.Manual, "Pro Shift", 8));

            bus.SetBusProperties(45, 72, 14000, BusType.Transit);

            Car car = new Car(new Chassis(4, 90, 1500),
                new Engine(200, 2.55, EngineTypes.PHEV, 663155),
                new Transmission(TransmissionTypes.Automatic, "Pro Shift", 6));

            car.SetCarProperties(CarTypes.Universal, true, 5);

            Scooter scooter = new Scooter(new Chassis(4, 100, 500),
                new Engine(80, 3.1, EngineTypes.HEV, 543155),
                new Transmission(TransmissionTypes.Automatic, "Pro Shift"));

            scooter.SetScooterProperties(ScooterFuel.CNG, 86);

            Truck truck = new Truck(new Chassis(18, 450, 12000),
                new Engine(350, 12, EngineTypes.DSL, 144415),
                new Transmission(TransmissionTypes.CVT, "Green Rubber-Kennedy AG, LP", 12));

            truck.SetTruckProperties("Wheat", 5000);

            Console.WriteLine(bus);
            Console.WriteLine(car);
            Console.WriteLine(scooter);
            Console.WriteLine(truck);
        }
    }
}