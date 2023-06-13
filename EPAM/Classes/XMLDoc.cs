using EPAM.Classes.VehicleParts;
using EPAM.Classes.Vehicles;
using System.Xml.Linq;
using EPAM.Classes.Exceptions;
using System.Reflection;


namespace EPAM.Classes
{
    internal class XMLDoc
    {
        internal List<Vehicle> VehicleList { get; set; }

        /// <summary>
        /// This class is designed to take a list of vehicles and create a XML specific documentation 
        /// </summary>
        /// <param name="vehicles">list of vehicles</param>
        public XMLDoc(List<Vehicle> vehicles)
        {
            VehicleList = vehicles;
        }

        /// <summary>
        /// Creates XML documentation for all vehicles which has Engine Volume more than 1.5
        /// File is saved as engineMoreThanOneHalf.xml in bin folder
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
        /// Creates XML documentation which includes engine infornation of buses and trucks
        /// File is saved as BusesTrucksEngineInfo.xml in bin folder
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
                        v.Engine.Volume,
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
        /// Creates XML documentation for all vehicles grouped by gear type
        /// File is saved as VehiclesGroupedByGears.xml in bin folder 
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

        /// <summary>
        /// We are creating XML element for each car seperatly.
        /// Here we throw Add exception when Car has null fields.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        private static XElement? XMLCarElement(Car car)
        {
            XElement vehic = new XElement("car");
            try
            {
                if (!CarValidation(car))
                {
                    throw new AddException();
                }

                XElement carSeats = new XElement("seats", car.Seats);
                XElement carCruiseControl = new XElement("cruise-control", car.HasCruiseControl.ToString());
                XElement carModel = new XElement("model", car.Model);
                XElement generalInfo = XMLGeneralElements(car);
                XAttribute carType = new XAttribute("car-type", car.CarType);

                vehic.Add(carType, carSeats, carModel, carCruiseControl, generalInfo);
                return vehic;
            }
            catch (AddException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
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

            XAttribute transmitionType = new XAttribute("type", vehicle.Transmission.Type);

            transmition.Add(transmitionGears, transmitionManufacturer, transmitionType);

            return transmition;
        }

        /// <summary>
        /// This method is used to find a specific property by name and value.
        /// It will throw GetAutoByParameterException when property does not exists
        /// or there are no objects, that have provided value.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="GetAutoByParameterException"></exception>
        /// <exception cref="ArgumentNullException"></exception>        
        internal Car? GetAutoByParameter(string parameter, string value)
        {
            PropertyInfo? property = typeof(Car).GetProperty(parameter);
            if (property == null)
            {
                throw new GetAutoByParameterException();
            }

            var cars = VehicleList.Where(v => v.GetType().Equals(typeof(Car))).Cast<Car>().ToList();
            if (cars.Count == 0)
            {
                throw new InvalidOperationException("List count is zero. Cannot perform operation.");
            }

            Car? car = cars.FirstOrDefault(x => property.GetValue(x)?.ToString() == value);
                
            if (car == null)
            {
                throw new GetAutoByParameterException(property.Name.ToString(), value);
            }

            return car;
        }

        /// <summary>
        /// Updates object in the list.
        /// Throws UpdateAutoException when "newCar" object has null fields.
        /// </summary>
        /// <param name="newCar"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        internal void UpdateAuto(Car newCar, string property, string value)
        {
            Car? car = GetAutoByParameter(property, value);

            //UpdateAutoException
            //newCar.Model = null;

            if (!CarValidation(newCar))
            {
                throw new UpdateAutoException();
            }

            car.Engine = newCar.Engine;
            car.Transmission = newCar.Transmission;
            car.Chassis = newCar.Chassis;
            car.HasCruiseControl = newCar.HasCruiseControl;
            car.CarType = newCar.CarType;
            car.Seats = newCar.Seats;
            car.Model = newCar.Model;

            //All Exceptions regurding finding element in collection is handeled by getAutoByParameter.
            //For case when we will try to attempt to replace a car with identifier (ID)
            //As it is mentioned in task, getAutoByParameterException will trigger.
            
        }

        /// <summary>
        /// Removes Car from the list.
        /// Throws RemoveAutoException when there is no element in the list to delete.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        internal void RemoveAuto(string property, string value)
        {
            int listLen = VehicleList.Count;
            Car? car = GetAutoByParameter(property, value);
            VehicleList = VehicleList.Where(x => x != car).ToList();

            if (VehicleList.Count == listLen)
            {
                throw new RemoveAutoException();
            }
        }

        internal void ShowVehicles()
        {
            foreach (var item in VehicleList)
            {
                Console.WriteLine(item + "\n\n");
            }
        }
        private static bool CarValidation(Car car)
        {
            var properties = car.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(car);
                if (value == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
