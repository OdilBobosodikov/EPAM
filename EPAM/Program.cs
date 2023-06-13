using EPAM.Classes;
using EPAM.Classes.VehicleParts;
using EPAM.Classes.Vehicles;
namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
            new Bus(new Chassis(6, 315, 5000),
                    new Engine(300, 6.7, EngineTypes.ESS, 222145),
                    new Transmission(TransmissionTypes.Manual, "Emco Gears", 8),
                    45, 72, 14000, BusTypes.School),
            new Car(new Chassis(4, 90, 1500),
                    new Engine(200, 2.55, EngineTypes.MHEV, 663154),
                    new Transmission(TransmissionTypes.Manual, "Pro Shift", 6),
                    CarTypes.Universal, true, 5),
                new Scooter(new Chassis(3, 66, 500),
                    new Engine(80, 1.49, EngineTypes.ESS, 543154),
                    new Transmission(TransmissionTypes.Automatic, "Pro Shift"),
                    ScooterFuelTypes.CNG, 86),
                new Scooter(new Chassis(2, 80, 600),
                    new Engine(65, 1.59, EngineTypes.ESS, 223145),
                    new Transmission(TransmissionTypes.Automatic, "Emco Gears"),
                    ScooterFuelTypes.CNG, 86),
                new Truck(new Chassis(18, 682.2, 12000),
                    new Engine(350, 12, EngineTypes.DSL, 144411),
                    new Transmission(TransmissionTypes.Automatic, "Green Rubber-Kennedy AG, LP", 12),
                    "Wheat", 5000)
            };

            XMLDoc doc = new XMLDoc(vehicles);
            doc.EngineMoreThanOneHalf();
            doc.BusesTrucksEngineInfo();
            doc.VehiclesGroupedByGears();
        }
    }
}