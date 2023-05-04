using EPAM.Classes.Vehicle_Parts;
using EPAM.Classes.Vehicles;
using System.Xml.Linq;
namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Bus(new Chassis(6, 315, 5000), new Engine(300, 6.7, EngineTypes.ESS, 222145), new Transmission(TransmissionTypes.Manual, "Emco Gears", 8), 45, 72, 14000, BusType.Transit),
                new Car(new Chassis(4, 90, 1500), new Engine(200, 2.55, EngineTypes.MHEV, 66315), new Transmission(TransmissionTypes.Manual, "Pro Shift", 6), CarTypes.Universal, true, 5),
                new Scooter(new Chassis(3, 10, 500), new Engine(80, 1.49, EngineTypes.ESS, 54315), new Transmission(TransmissionTypes.Automatic, "Pro Shift"), ScooterFuel.CNG, 86),
                new Scooter(new Chassis(4, 8, 600), new Engine(65, 1.59, EngineTypes.ESS, 223145), new Transmission(TransmissionTypes.Automatic, "Emco Gears"), ScooterFuel.CNG, 86),
                new Truck(new Chassis(18, 682.2, 12000), new Engine(350, 12, EngineTypes.DSL, 14441), new Transmission(TransmissionTypes.Automatic, "Green Rubber-Kennedy AG, LP", 12), "Wheat", 5000)
            };

            EngineMoreThanOneHalf(vehicles);
            BusesTrucksEngineInfo(vehicles);
            VehiclesGroupedByGears(vehicles);
        }

        internal static void EngineMoreThanOneHalf(List<Vehicle> vehicles)
        {
            var moreThanOneHalf = vehicles.Where(v => v.Engine.Volume >= 1.5);

            XDocument xdoc = new XDocument();
            XElement root = new XElement("vehicles");
            
            foreach (var vehicle in moreThanOneHalf)
            {
                if (vehicle.GetType().Equals(typeof(Bus)))
                {
                    root.Add(AddBusElement((Bus)vehicle));
                }
                else if (vehicle.GetType().Equals(typeof(Car)))
                {
                    root.Add(AddCarElement((Car)vehicle));
                }
                else if (vehicle.GetType().Equals(typeof(Truck)))
                {
                    root.Add(AddTruckElement((Truck)vehicle));
                }
                else if (vehicle.GetType().Equals(typeof(Scooter)))
                {
                    root.Add(AddScooterElement((Scooter)vehicle));
                }
            }
            xdoc.Add(root);
            xdoc.Save("engineMoreThanOneHalf.xml");
        }
        internal static void BusesTrucksEngineInfo(List<Vehicle> vehicles)
        {
            var buses = vehicles.Where(v => v.GetType().Equals(typeof(Bus)))
                .Select(v =>
                    new {v.Engine.Power,
                            v.Engine.Volume,
                            v.Engine.Type,
                            v.Engine.SerialNumber}).ToList();
            
            var trucks = vehicles.Where(v => v.GetType().Equals(typeof(Truck)))
                .Select(v =>
                    new {v.Engine.Power,
                            v.Engine.Type,
                            v.Engine.SerialNumber}).ToList();

            XDocument xdoc = new XDocument();
            XElement root = new XElement("busses-and-trucks");

            foreach (var truck in trucks)
            {
                XElement truckRoot = new XElement("truck");
                truckRoot.Add(EngineElement(truck.Power, truck.Type, truck.SerialNumber));
                root.Add(truckRoot);
            }

            foreach (var bus in buses)
            {
                XElement busRoot = new XElement("bus");
                busRoot.Add(EngineElement(bus.Power, bus.Type, bus.SerialNumber));
                root.Add(busRoot);
            }

            xdoc.Add(root);
            xdoc.Save("BusesTrucksEngineInfo.xml");
        }
        internal static void VehiclesGroupedByGears(List<Vehicle> vehicles)
        {
            var vehiclesGroupedByGears = vehicles.GroupBy(v => v.Transmission.Type);
            
            XDocument xdoc = new XDocument();
            XElement root = new XElement("vehicles");

            foreach (var gears in vehiclesGroupedByGears)
            {
                XElement gear = new XElement("gears");
                XAttribute gearsNum = new XAttribute("gears-type", gears.Key);

                foreach (var vehicle in gears)
                {
                    if (vehicle.GetType().Equals(typeof(Bus)))
                    {
                        gear.Add(AddBusElement((Bus)vehicle));
                    }
                    else if (vehicle.GetType().Equals(typeof(Car)))
                    {
                        gear.Add(AddCarElement((Car)vehicle));
                    }
                    else if (vehicle.GetType().Equals(typeof(Truck)))
                    {
                        gear.Add(AddTruckElement((Truck)vehicle));
                    }
                    else if (vehicle.GetType().Equals(typeof(Scooter)))
                    {
                        gear.Add(AddScooterElement((Scooter)vehicle));
                    }
                }
                gear.Add(gearsNum);
                root.Add(gear);
            }
            xdoc.Add(root);
            xdoc.Save("VehiclesGroupedByGears.xml");
        }



        internal static XElement AddCarElement(Car car)
        {
            XElement vehic = new XElement("car");
            XElement carSeats = new XElement("seats", car.Seats);
            XElement carCruiseControl = new XElement("cruise-control", car.HasCruiseControl.ToString());
            XElement generalInfo = GeneralElements(car);
            XAttribute carType = new XAttribute("car-type", car.CarType);

            vehic.Add(carType, carSeats, carCruiseControl, generalInfo);
            return vehic;
        }
        internal static XElement AddBusElement(Bus bus)
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
            return vehic;
        }
        internal static XElement AddTruckElement(Truck truck)
        {
            XElement vehic = new XElement("truck");
            XElement truckCargo = new XElement("cargo", truck.Cargo);
            XElement truckTrunkVolume = new XElement("trunk-volume", truck.TrunkVolume);
            XElement generalInfo = GeneralElements(truck);

            vehic.Add(truckCargo, truckTrunkVolume, generalInfo);

            return vehic;
        }
        internal static XElement AddScooterElement(Scooter scooter)
        {
            XElement vehic = new XElement("scooter");
            XElement scooterMaxSpeed = new XElement("max-speed", scooter.MaxSpeed);
            XElement scooterFuel = new XElement("fuel", scooter.Fuel);
            XElement generalInfo = GeneralElements(scooter);
            
            vehic.Add(scooterMaxSpeed, scooterFuel, generalInfo);
            
            return vehic;
        }

        internal static XElement GeneralElements(Vehicle vehicle)
        {
            XElement root = new XElement("vehicle-parts");

            root.Add(EngineElement(vehicle));
            root.Add(ChassisElement(vehicle));
            root.Add(TransmitionElement(vehicle));

            return root;
        }

        internal static XElement EngineElement(Vehicle vehicle)
        {
            XElement engine = new XElement("engine");
            XElement enginePower = new XElement("power", vehicle.Engine.Power);
            XElement engineVolume = new XElement("volume", vehicle.Engine.Volume);
            
            XAttribute engineType = new XAttribute("type", vehicle.Engine.Type);
            XAttribute engineSerialNum = new XAttribute("serial-number", vehicle.Engine.SerialNumber);

            engine.Add(engineType, enginePower, engineVolume, engineSerialNum);

            return engine;
        }
        internal static XElement EngineElement(double power, EngineTypes type, int serialNum)
        {
            XElement engine = new XElement("engine");
            XElement enginePower = new XElement("power", power);

            XAttribute engineType = new XAttribute("type", type);
            XAttribute engineSerialNum = new XAttribute("serial-number", serialNum);

            engine.Add(engineType, enginePower, engineSerialNum);

            return engine;
        }
        internal static XElement ChassisElement(Vehicle vehicle)
        {
            XElement chassis = new XElement("chassis");
            XElement chassisWheels = new XElement("wheels", vehicle.Chassis.Wheels);
            XElement chassisTireWidth = new XElement("tire-width", vehicle.Chassis.TireWidth);
            XElement chassisLoadCapacity = new XElement("load-capacity", vehicle.Chassis.LoadCapacity);

            chassis.Add(chassisWheels, chassisTireWidth, chassisLoadCapacity);
            
            return chassis;
        }
        internal static XElement TransmitionElement(Vehicle vehicle)
        {
            XElement transmition = new XElement("transmition");
            XElement transmitionGears = new XElement("gears", vehicle.Transmission.Gears);
            XElement transmitionManufacturer = new XElement("manufacturer", vehicle.Transmission.Manufacturer);

            XAttribute transmitionType = new XAttribute("type", vehicle.Transmission.Type);

            transmition.Add(transmitionGears, transmitionManufacturer, transmitionType);
            
            return transmition;
        }
    }
}