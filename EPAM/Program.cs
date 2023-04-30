using EPAM.Classes.Vehicle_Parts;
using EPAM.Classes.Vehicles;
using System.ComponentModel.Design.Serialization;
using System.Xml.Linq;
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

            EngineMoreThanOneHalf(vehicles);
        }

        internal static void EngineMoreThanOneHalf(List<Vehicle> vehicles)
        {
            var moreThanOneHalf = vehicles.Where(v => v.Engine.Volume >= 1.5);
            var cars = moreThanOneHalf.Where(v => v.GetType().Equals(typeof(Car))).Cast<Car>().ToList();
            var buses = moreThanOneHalf.Where(v => v.GetType().Equals(typeof(Bus))).Cast<Bus>().ToList();
            var trucks = moreThanOneHalf.Where(v => v.GetType().Equals(typeof(Truck))).Cast<Truck>().ToList();
            var scooters = moreThanOneHalf.Where(v => v.GetType().Equals(typeof(Scooter))).Cast<Scooter>().ToList();

            XDocument xdoc = new XDocument();
            
            //root element
            XElement root = new XElement("vehicles");
            
            AddCarElements(cars, root);
            AddBusElements(buses, root);
            AddScooterElements(scooters, root);
            AddTruckElements(trucks, root);

            xdoc.Add(root);
            xdoc.Save("engineMoreThanOneHalf.xml");
        }

        internal static void BusesTrucksEngineInfo(List<Vehicle> vehicles)
        {
            var buses = vehicles.Where(v => v.GetType().Equals(typeof(Bus)))
                .Select(v =>
                    new { v.Engine.Power, v.Engine.Volume, v.Engine.Type, v.Engine.SerialNumber } ).ToList();
            
            var trucks = vehicles.Where(v => v.GetType().Equals(typeof(Truck)))
                .Select(v =>
                    new { v.Engine.Power, v.Engine.Volume, v.Engine.Type, v.Engine.SerialNumber }).ToList();

        }

        internal static void ThirdTask(List<Vehicle> vehicles)
        {
            var task3 = vehicles.GroupBy(v => v.Transmission.Gears);
        }


        internal static void AddCarElements(List<Car> cars, XElement root)
        {
            foreach (var car in cars)
            {
                XElement vehic = new XElement("car");
                XElement carSeats = new XElement("seats", car.Seats);
                XElement carCruiseControl = new XElement("cruise-control", car.HasCruiseControl.ToString());
                XElement generalInfo = GeneralElements(car);
                XAttribute carType = new XAttribute("type", car.CarType);

                vehic.Add(carType, carSeats, carCruiseControl, generalInfo);
                root.Add(vehic);
            }
        }
        internal static void AddBusElements(List<Bus> buses, XElement root)
        {
            foreach (var bus in buses)
            {
                XElement vehic = new XElement("bus");
                XElement busPeopleCapacity = new XElement("people-capacity", bus.MaximumPeopleCapacity);
                XElement busFare = new XElement("fare", bus.Fare);
                XElement generalInfo = GeneralElements(bus);
                XAttribute busType = new XAttribute("type", bus.BusType);
                XAttribute busNumber = new XAttribute("number", bus.Number);

                vehic.Add(busType,
                        busNumber,
                        busPeopleCapacity,
                        busFare,
                        generalInfo);

                root.Add(vehic);
            }
        }
        internal static void AddTruckElements(List<Truck> trucks, XElement root)
        {
            foreach (var truck in trucks)
            {
                XElement vehic = new XElement("truck");
                XElement truckCargo = new XElement("cargo", truck.Cargo);
                XElement truckTrunkVolume = new XElement("trunk-volume", truck.TrunkVolume);
                XElement generalInfo = GeneralElements(truck);

                vehic.Add(truckCargo, truckTrunkVolume, generalInfo);

                root.Add(vehic);
            }
        }
        internal static void AddScooterElements(List<Scooter> scooters, XElement root)
        {
            foreach (var scooter in scooters)
            {
                XElement vehic = new XElement("scooter");
                XElement scooterMaxSpeed = new XElement("max-speed", scooter.MaxSpeed);
                XElement scooterFuel = new XElement("fuel", scooter.Fuel);
                XElement generalInfo = GeneralElements(scooter);

                vehic.Add(scooterMaxSpeed, scooterFuel, generalInfo);

                root.Add(root);
            }
        }
        internal static XElement GeneralElements(Vehicle vehicle)
        {
            XElement root = new XElement("vehicle-parts");
            
            XElement engine = new XElement("engine");
            XElement enginePower = new XElement("power", vehicle.Engine.Power);
            XElement engineVolume = new XElement("volume", vehicle.Engine.Volume);
            XElement engineSerialNum = new XElement("serial-number", vehicle.Engine.SerialNumber);
            XElement engineType = new XElement("type", vehicle.Engine.Type);

            engine.Add(engineType);
            engine.Add(enginePower);
            engine.Add(engineVolume);
            engine.Add(engineSerialNum);

            XElement chassis = new XElement("chassis");
            XElement chassisWheels = new XElement("wheels", vehicle.Chassis.Wheels);
            XElement chassisTireWidth = new XElement("tire-width", vehicle.Chassis.TireWidth);
            XElement chassisLoadCapacity = new XElement("load-capacity", vehicle.Chassis.LoadCapacity);

            chassis.Add(chassisWheels);
            chassis.Add(chassisTireWidth);
            chassis.Add(chassisLoadCapacity);

            XElement transmition = new XElement("transmition");
            XElement transmitionGears = new XElement("gears", vehicle.Transmission.Gears);
            XElement transmitionManufacturer = new XElement("manufacturer", vehicle.Transmission.Manufacturer);
            XElement transmitionType = new XElement("type", vehicle.Transmission.Type);

            transmition.Add(transmitionGears);
            transmition.Add(transmitionManufacturer);
            transmition.Add(transmitionType);

            root.Add(engine);
            root.Add(chassis);
            root.Add(transmition);

            return root;
        }
    }
}