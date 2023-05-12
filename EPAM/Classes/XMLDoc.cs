using EPAM.Classes.Vehicle_Parts;
using EPAM.Classes.Vehicles;
using System.Xml.Linq;

namespace EPAM.Classes
{
    internal class XMLDoc
    {
        internal List<Vehicle> VehicleList { get; set; }

        /// <summary>
        /// This class is designed to take a list of vehicles and create a XML specific documentation.
        /// </summary>
        /// <param name="vehicles">list of vehicles</param>
        public XMLDoc(List<Vehicle> vehicles)
        {
            VehicleList = vehicles;
        }

        /// <summary>
        /// Creates XML documentation for all vehicles which has Engine Volume more than 1.5.
        /// File is saved as engineMoreThanOneHalf.xml in bin folder.
        /// </summary>
        internal void EngineMoreThanOneHalf()
        {
            var moreThanOneHalf = VehicleList.Where(v => v.Engine.Volume >= 1.5);

            XDocument xdoc = new XDocument();
            XElement root = new XElement("vehicles");

            foreach (var vehicle in moreThanOneHalf)
            {
                if (vehicle.GetType().Equals(typeof(Bus)))
                {
                    root.Add(XMLBusElement((Bus)vehicle));
                }
                else if (vehicle.GetType().Equals(typeof(Car)))
                {
                    root.Add(XMLCarElement((Car)vehicle));
                }
                else if (vehicle.GetType().Equals(typeof(Truck)))
                {
                    root.Add(XMLTruckElement((Truck)vehicle));
                }
                else if (vehicle.GetType().Equals(typeof(Scooter)))
                {
                    root.Add(XMLScooterElement((Scooter)vehicle));
                }
            }
            xdoc.Add(root);
            xdoc.Save("engineMoreThanOneHalf.xml");
        }

        /// <summary>
        /// Creates XML documentation which includes engine infornation of buses and trucks.
        /// File is saved as BusesTrucksEngineInfo.xml in bin folder.
        /// </summary>
        internal void BusesTrucksEngineInfo()
        {
            var buses = VehicleList.Where(v => v.GetType().Equals(typeof(Bus)))
                .Select(v =>
                    new {
                        v.Engine.Power,
                        v.Engine.Volume,
                        v.Engine.Type,
                        v.Engine.SerialNumber
                    }).ToList();

            var trucks = VehicleList.Where(v => v.GetType().Equals(typeof(Truck)))
                .Select(v =>
                    new {
                        v.Engine.Power,
                        v.Engine.Type,
                        v.Engine.SerialNumber
                    }).ToList();

            XDocument xdoc = new XDocument();
            XElement root = new XElement("busses-and-trucks");

            foreach (var truck in trucks)
            {
                XElement truckRoot = new XElement("truck");
                truckRoot.Add(XMLEngineElement(truck.Power, truck.Type, truck.SerialNumber));
                root.Add(truckRoot);
            }

            foreach (var bus in buses)
            {
                XElement busRoot = new XElement("bus");
                busRoot.Add(XMLEngineElement(bus.Power, bus.Type, bus.SerialNumber));
                root.Add(busRoot);
            }

            xdoc.Add(root);
            xdoc.Save("BusesTrucksEngineInfo.xml");
        }

        /// <summary>
        /// Creates XML documentation for all vehicles grouped by gear type.
        /// File is saved as VehiclesGroupedByGears.xml in bin folder. 
        /// </summary>
        internal void VehiclesGroupedByGears()
        {
            var vehiclesGroupedByGears = VehicleList.GroupBy(v => v.Transmission.Type);
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
                        gear.Add(XMLBusElement((Bus)vehicle));
                    }
                    else if (vehicle.GetType().Equals(typeof(Car)))
                    {
                        gear.Add(XMLCarElement((Car)vehicle));
                    }
                    else if (vehicle.GetType().Equals(typeof(Truck)))
                    {
                        gear.Add(XMLTruckElement((Truck)vehicle));
                    }
                    else if (vehicle.GetType().Equals(typeof(Scooter)))
                    {
                        gear.Add(XMLScooterElement((Scooter)vehicle));
                    }
                }
                gear.Add(gearsNum);
                root.Add(gear);
            }
            xdoc.Add(root);
            xdoc.Save("VehiclesGroupedByGears.xml");
        }



        private static XElement XMLCarElement(Car car)
        {
            XElement vehic = new XElement("car");
            XElement carSeats = new XElement("seats", car.Seats);
            XElement carCruiseControl = new XElement("cruise-control", car.HasCruiseControl.ToString());
            XElement generalInfo = XMLGeneralElements(car);
            XAttribute carType = new XAttribute("car-type", car.CarType);

            vehic.Add(carType, carSeats, carCruiseControl, generalInfo);
            return vehic;
        }
        private static XElement XMLBusElement(Bus bus)
        {
            XElement vehic = new XElement("bus");
            XElement busPeopleCapacity = new XElement("people-capacity", bus.MaximumPeopleCapacity);
            XElement busFare = new XElement("fare", bus.Fare);
            XElement generalInfo = XMLGeneralElements(bus);
            XAttribute busType = new XAttribute("type", bus.BusType);
            XAttribute busNumber = new XAttribute("number", bus.Number);

            vehic.Add(busType,
                    busNumber,
                    busPeopleCapacity,
                    busFare,
                    generalInfo);
            return vehic;
        }
        private static XElement XMLTruckElement(Truck truck)
        {
            XElement vehic = new XElement("truck");
            XElement truckCargo = new XElement("cargo", truck.Cargo);
            XElement truckTrunkVolume = new XElement("trunk-volume", truck.TrunkVolume);
            XElement generalInfo = XMLGeneralElements(truck);

            vehic.Add(truckCargo, truckTrunkVolume, generalInfo);

            return vehic;
        }
        private static XElement XMLScooterElement(Scooter scooter)
        {
            XElement vehic = new XElement("scooter");
            XElement scooterMaxSpeed = new XElement("max-speed", scooter.MaxSpeed);
            XElement scooterFuel = new XElement("fuel", scooter.Fuel);
            XElement generalInfo = XMLGeneralElements(scooter);

            vehic.Add(scooterMaxSpeed, scooterFuel, generalInfo);

            return vehic;
        }

        private static XElement XMLGeneralElements(Vehicle vehicle)
        {
            XElement root = new XElement("vehicle-parts");

            root.Add(EngineElement(vehicle));
            root.Add(XMLChassisElement(vehicle));
            root.Add(XMLTransmitionElement(vehicle));

            return root;
        }

        private static XElement EngineElement(Vehicle vehicle)
        {
            XElement engine = new XElement("engine");
            XElement enginePower = new XElement("power", vehicle.Engine.Power);
            XElement engineVolume = new XElement("volume", vehicle.Engine.Volume);

            XAttribute engineType = new XAttribute("type", vehicle.Engine.Type);
            XAttribute engineSerialNum = new XAttribute("serial-number", vehicle.Engine.SerialNumber);

            engine.Add(engineType, enginePower, engineVolume, engineSerialNum);

            return engine;
        }
        private static XElement XMLEngineElement(double power, EngineTypes type, int serialNum)
        {
            XElement engine = new XElement("engine");
            XElement enginePower = new XElement("power", power);

            XAttribute engineType = new XAttribute("type", type);
            XAttribute engineSerialNum = new XAttribute("serial-number", serialNum);

            engine.Add(engineType, enginePower, engineSerialNum);

            return engine;
        }
        private static XElement XMLChassisElement(Vehicle vehicle)
        {
            XElement chassis = new XElement("chassis");
            XElement chassisWheels = new XElement("wheels", vehicle.Chassis.Wheels);
            XElement chassisTireWidth = new XElement("tire-width", vehicle.Chassis.TireWidth);
            XElement chassisLoadCapacity = new XElement("load-capacity", vehicle.Chassis.LoadCapacity);

            chassis.Add(chassisWheels, chassisTireWidth, chassisLoadCapacity);

            return chassis;
        }
        private static XElement XMLTransmitionElement(Vehicle vehicle)
        {
            XElement transmition = new XElement("transmition");
            XElement transmitionGears = new XElement("gears", vehicle.Transmission.Gears);
            XElement transmitionManufacturer = new XElement("manufacturer", vehicle.Transmission.Manufacturer);

            XAttribute? transmitionType = new XAttribute("type", vehicle.Transmission.Type);

            transmition.Add(transmitionGears, transmitionManufacturer, transmitionType);

            return transmition;
        }

    }
}
